using LiveCharts.Wpf;
using LiveCharts;
using ResortStudio.entity;
using ResortStudio.services;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Threading;

namespace ResortStudio
{
    public partial class DashboardPage : Page
    {
        Client supabase;
        private BookingService bs;

        public DashboardPage(Client sc)
        {
            InitializeComponent();
            supabase = sc;
            bs = new BookingService();
        }
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime ninetyDaysAgo = DateTime.Now.AddDays(-90);
            int totalCabins = await supabase.From<Cabin>()
         .Count(Postgrest.Constants.CountType.Exact, CancellationToken.None);
            List<BookingGridItem> bookings = await bs.GetAllBookings(supabase, 1, 1000);

            var filteredBookings = bookings
                .Where(b => b.StartDate >= ninetyDaysAgo && (b.Status == "checked-in" || b.Status == "checked-out"))
                .ToList();


            int occupiedCabins = filteredBookings.Where(b => b.Status == "checked-in").Count();

            double occupancyRate = Math.Round(((double)occupiedCabins / totalCabins) * 100,2);


            tbBookings.Text = filteredBookings.Count.ToString();
            tbCheckIn.Text = filteredBookings.Where(b => b.Status == "checked-in").ToList().Count.ToString();
            tbSales.Text = $"${filteredBookings.Sum(b => b.TotalPrice).ToString()}";
            tbOccupancy.Text = $"{occupancyRate}%";

            var salesData = new ChartValues<double>();
            foreach (BookingGridItem booking in filteredBookings)
            {
                salesData.Add(booking.TotalPrice);
            }
            SalesChart.Series = new SeriesCollection
                                                {
                                                    new LineSeries
                                                    {
                                                        Title = "Sales",
                                                        Values = salesData
                                                    }
                                                };
        }



    }
}
