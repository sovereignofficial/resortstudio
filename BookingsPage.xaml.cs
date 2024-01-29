using Newtonsoft.Json;
using Postgrest;
using ResortStudio.entity;
using ResortStudio.filters;
using ResortStudio.page_handlers;
using ResortStudio.services;
using Supabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ResortStudio
{
    public partial class BookingsPage : Page
    {
        Supabase.Client supabase;
        private BookingService service;
        private CabinService cabinService;
        private GuestService guestService;

        private BookingFilterHandler filterHandler;
        private BookingPageHandler pageHandler;
        private Booking globalSelectedBooking;
        private Settings appSettings;


        public BookingsPage(Supabase.Client sc, Settings settings)
        {
            InitializeComponent();
            supabase = sc;
            service = new BookingService();
            cabinService = new CabinService();
            guestService = new GuestService();
            appSettings = settings;


            string initialState = "all";
            List<string> filters = new List<string>() { "all", "unconfirmed", "checked-in", "checked-out" };
            filterHandler = new BookingFilterHandler(initialState, filters);
        }



        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Calculate maxPage dynamically
                int maxItemsPerPage = 10;
                int totalRecords = await supabase.From<Booking>()
                                                 .Count(Constants.CountType.Exact, CancellationToken.None);

                int maxPage = (int)Math.Ceiling((double)totalRecords / maxItemsPerPage);

                pageHandler = new BookingPageHandler(1, maxPage, maxItemsPerPage);
                GetAllBookings(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void BookingsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BookingGridItem selectedBooking = BookingsTable.SelectedItem as BookingGridItem;

                if (selectedBooking != null)
                {
                    globalSelectedBooking = selectedBooking;
                    Cabin cabinInfo = await cabinService.GetCabinById(supabase, globalSelectedBooking.CabinId);
                    Guest guestInfo = await guestService.GetGuestById(supabase, globalSelectedBooking.GuestId);

                    tbCabinImage.DataContext = cabinInfo.Image;
                    tbCabinPrice.DataContext = $"${globalSelectedBooking.NumNights * (cabinInfo.RegularPrice - cabinInfo.Discount)}";
                    tbBreakfastPrice.DataContext = globalSelectedBooking.HasBreakfast ? $"${appSettings.BreakfastPrice * globalSelectedBooking.NumNights * globalSelectedBooking.NumGuests}" : $"${0}";
                    tbCheckedIn.DataContext = globalSelectedBooking.Status;
                    tbDates.DataContext = selectedBooking.FormattedDates;
                    tbNumGuests.DataContext = globalSelectedBooking.NumGuests;
                    tbNumNights.DataContext = globalSelectedBooking.NumNights;
                    tbEmail.DataContext = guestInfo.Email;
                    tbGuestName.DataContext = guestInfo.FullName;
                    tbCabinName.DataContext = cabinInfo.Name;
                    tbTotalPrice.DataContext = $"${globalSelectedBooking.NumNights * (cabinInfo.RegularPrice - cabinInfo.Discount) + (globalSelectedBooking.HasBreakfast ? appSettings.BreakfastPrice * globalSelectedBooking.NumNights * globalSelectedBooking.NumGuests : 0)}";
                    tbPaid.DataContext = globalSelectedBooking.IsPaid ? "Paid." : "Not paid.";
                    cbBreakfastIncluded.IsChecked = globalSelectedBooking.HasBreakfast;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBreakfastInfo(object sender, RoutedEventArgs e)
        {
            BookingGridItem selectedBooking = BookingsTable.SelectedItem as BookingGridItem;

            if (selectedBooking != null && selectedBooking.Status == "unconfirmed")
            {
                globalSelectedBooking.HasBreakfast = (bool)cbBreakfastIncluded.IsChecked;
            }

        }

        private async void CheckInBooking(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking selectedBooking = BookingsTable.SelectedItem as Booking;
                if (selectedBooking.Status == "checked-in")
                {
                    throw new Exception("You can't update this booking since it's checked in!");
                }
                else if (selectedBooking.Status == "checked-out")
                {
                    throw new Exception("You can't update this booking since it's checked-out!");
                }
                else
                {
                    if (globalSelectedBooking != null)
                    {
                        globalSelectedBooking.Status = "checked-in";
                        globalSelectedBooking.TotalPrice = globalSelectedBooking.CabinPrice + (globalSelectedBooking.HasBreakfast ? appSettings.BreakfastPrice * globalSelectedBooking.NumNights * globalSelectedBooking.NumGuests : 0);
                        await service.UpdateBooking(supabase, globalSelectedBooking);
                        MessageBox.Show($"Booking {globalSelectedBooking.Id} checked in!", "Success");
                        GetAllBookings(sender, e);
                    }
                    else
                    {
                        throw new Exception("Something went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private async void CheckOutBooking(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking selectedBooking = BookingsTable.SelectedItem as Booking;
                if (selectedBooking.Status == "checked-out")
                {
                    throw new Exception("You can't update this booking since it's checked out!");
                }
                else if (selectedBooking.Status == "unconfirmed")
                {
                    throw new Exception("You can't update this booking since it's unconfirmed!");
                }
                else
                {
                    if (globalSelectedBooking != null)
                    {
                        globalSelectedBooking.Status = "checked-out";
                        await service.UpdateBooking(supabase, globalSelectedBooking);
                        MessageBox.Show($"Booking {globalSelectedBooking.Id} checked out!", "Success");
                        GetAllBookings(sender, e);
                    }
                    else
                    {
                        throw new Exception("Something went wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private async void RemoveBooking(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking selectedBooking = BookingsTable.SelectedItem as Booking;

                if (selectedBooking.Status == "checked-out")
                {
                    MessageBoxResult result = MessageBox.Show("Do you confirm that you want to remove this booking?", "Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        if (globalSelectedBooking != null)
                        {
                            await service.RemoveBooking(supabase, globalSelectedBooking.Id);
                            MessageBox.Show($"Booking {globalSelectedBooking.Id} removed!", "Success");
                            GetAllBookings(sender, e);
                        }
                        else
                        {
                            throw new Exception("Something went wrong!");
                        }
                    }
                }
                else
                {
                    throw new Exception("You can't remove this booking due to it's status not checked-out!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private async void GetAllBookings(object sender, RoutedEventArgs e)
        {
            if (filterHandler.CurrentFilterState != "all")
            {
                int totalRecords = await supabase.From<Booking>()
                                                 .Count(Constants.CountType.Exact, CancellationToken.None);

                int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
                pageHandler.MaxPage = maxPage;
                pageHandler.CurrentPage = 1;
                filterHandler.CurrentFilterState = filterHandler.Filters[0];
            }
            FilterBtnUnc.Style = Application.Current.Resources["SecondaryButton"] as Style;
            FilterBtnAll.Style = Application.Current.Resources["PrimaryButton"] as Style;
            FilterBtnChin.Style = Application.Current.Resources["SecondaryButton"] as Style;
            FilterBtnChout.Style = Application.Current.Resources["SecondaryButton"] as Style;


            List<BookingGridItem> bookings = await service.GetAllBookings(supabase, pageHandler.CurrentPage, pageHandler.MaxItemAmountInPage);
            BookingsTable.ItemsSource = bookings;
            tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
        }

        private async void GetUnconfirmedBookings(object sender, RoutedEventArgs e)
        {
            if (filterHandler.CurrentFilterState != "unconfirmed")
            {
                pageHandler.CurrentPage = 1;
                filterHandler.CurrentFilterState = filterHandler.Filters[1];
                FilterBtnUnc.Style = Application.Current.Resources["PrimaryButton"] as Style;
                FilterBtnAll.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnChin.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnChout.Style = Application.Current.Resources["SecondaryButton"] as Style;
            }
            int totalRecords = await supabase.From<Booking>()
                     .Where((booking) => booking.Status == filterHandler.CurrentFilterState)
                     .Count(Constants.CountType.Exact, CancellationToken.None);
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
            pageHandler.MaxPage = maxPage;


            List<BookingGridItem> bookings = await service.GetAllBookingsWithStatus(supabase, pageHandler.CurrentPage, pageHandler.MaxItemAmountInPage, filterHandler.CurrentFilterState);
            BookingsTable.ItemsSource = bookings;
            tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
        }

        private async void GetCheckedInBookings(object sender, RoutedEventArgs e)
        {
            if (filterHandler.CurrentFilterState != "checked-in")
            {
                pageHandler.CurrentPage = 1;
                filterHandler.CurrentFilterState = filterHandler.Filters[2];
                FilterBtnUnc.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnAll.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnChin.Style = Application.Current.Resources["PrimaryButton"] as Style;
                FilterBtnChout.Style = Application.Current.Resources["SecondaryButton"] as Style;
            }
            int totalRecords = await supabase.From<Booking>()
                     .Where((booking) => booking.Status == filterHandler.CurrentFilterState)
                     .Count(Constants.CountType.Exact, CancellationToken.None);
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
            pageHandler.MaxPage = maxPage;


            List<BookingGridItem> bookings = await service.GetAllBookingsWithStatus(supabase, pageHandler.CurrentPage, pageHandler.MaxItemAmountInPage, filterHandler.CurrentFilterState);
            BookingsTable.ItemsSource = bookings;
            tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
        }

        private async void GetCheckedOutBookings(object sender, RoutedEventArgs e)
        {
            if (filterHandler.CurrentFilterState != "checked-out")
            {
                pageHandler.CurrentPage = 1;
                filterHandler.CurrentFilterState = filterHandler.Filters[3];
                FilterBtnUnc.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnAll.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnChin.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnChout.Style = Application.Current.Resources["PrimaryButton"] as Style;
            }
            int totalRecords = await supabase.From<Booking>()
                     .Where((booking) => booking.Status == filterHandler.CurrentFilterState)
                     .Count(Constants.CountType.Exact, CancellationToken.None);
            int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
            pageHandler.MaxPage = maxPage;


            List<BookingGridItem> bookings = await service.GetAllBookingsWithStatus(supabase, pageHandler.CurrentPage, pageHandler.MaxItemAmountInPage, filterHandler.CurrentFilterState);
            BookingsTable.ItemsSource = bookings;
            tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
        }


        private async void PreviousBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (filterHandler.CurrentFilterState)
                {
                    case "all":
                        await pageHandler.HandlePreviousPage(async () => GetAllBookings(sender, e));
                        break;
                    case "unconfirmed":
                        await pageHandler.HandlePreviousPage(async () => GetUnconfirmedBookings(sender, e));
                        break;
                    case "checked-in":
                        await pageHandler.HandlePreviousPage(async () => GetCheckedInBookings(sender, e));
                        break;
                    case "checked-out":
                        await pageHandler.HandlePreviousPage(async () => GetCheckedOutBookings(sender, e));
                        break;

                    default:
                        await pageHandler.HandlePreviousPage(async () => GetAllBookings(sender, e));
                        break;
                }
                tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void NextBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (filterHandler.CurrentFilterState)
                {
                    case "all":
                        await pageHandler.HandleNextPage(async () => GetAllBookings(sender, e));
                        break;
                    case "unconfirmed":
                        await pageHandler.HandleNextPage(async () => GetUnconfirmedBookings(sender, e));
                        break;
                    case "checked-in":
                        await pageHandler.HandleNextPage(async () => GetCheckedInBookings(sender, e));
                        break;
                    case "checked-out":
                        await pageHandler.HandleNextPage(async () => GetCheckedOutBookings(sender, e));
                        break;

                    default:
                        await pageHandler.HandleNextPage(async () => GetAllBookings(sender, e));
                        break;
                }
                tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
