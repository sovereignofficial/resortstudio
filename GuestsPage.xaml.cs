using Postgrest;
using ResortStudio.entity;
using ResortStudio.filters;
using ResortStudio.page_handlers;
using ResortStudio.services;
using Supabase;
using System;
using System.Collections.Generic;
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

    public partial class GuestsPage : Page
    {
        private Supabase.Client supabase;
        private GuestService service;
        private GuestPageHandler pageHandler;
        private GuestFilterHandler filterHandler;

        public GuestsPage(Supabase.Client sc)
        {
            InitializeComponent();
            supabase = sc;
            service = new GuestService();

            int maxItem = 5;
            int currPage = 1;
            int maxPage = 1;
            pageHandler = new GuestPageHandler(currPage, maxPage, maxItem);

            string initialFilter = "all";
            List<string> filters = new List<string>() { "all", "search" };
            filterHandler = new GuestFilterHandler(initialFilter, filters);
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await GetAllGuests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task GetAllGuests()
        {
            try
            {
                if (filterHandler.CurrentFilterState != "all")
                {
                    pageHandler.CurrentPage = 1;
                    filterHandler.CurrentFilterState = filterHandler.Filters[0];
                    SearchAll.Style = Application.Current.Resources["PrimaryButton"] as Style;
                }
                int totalRecords = await supabase.From<Guest>()
                                                    .Count(Constants.CountType.Exact, CancellationToken.None);
                int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
                pageHandler.MaxPage = maxPage;
                List<Guest> guests = await service.GetAllGuests(supabase, pageHandler.CurrentPage, pageHandler.MaxItemAmountInPage);
                GuestsTable.ItemsSource = guests;
                tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private async void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && tbSearchGuest.Text.Trim() != "")
                {
                    if (filterHandler.CurrentFilterState != "search")
                    {
                        pageHandler.CurrentPage = 1;
                        filterHandler.CurrentFilterState = filterHandler.Filters[1];
                        SearchAll.Style = Application.Current.Resources["SecondaryButton"] as Style;
                    }
                    int totalRecords = await supabase.From<Guest>()
                                     .Where(guest => guest.FullName.Contains(tbSearchGuest.Text))
                                    .Count(Constants.CountType.Exact, CancellationToken.None);
                    int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
                    pageHandler.MaxPage = maxPage;
                    List<Guest> guests = await service.GetAllGuestsByName(supabase, pageHandler.CurrentPage, pageHandler.MaxPage, tbSearchGuest.Text);

                    GuestsTable.ItemsSource = guests;
                    tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void PreviousBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (filterHandler.CurrentFilterState)
                {
                    case "all":
                        await pageHandler.HandlePreviousPage(async () => await GetAllGuests());
                        break;

                    case "search":
                        int totalRecords = await supabase.From<Guest>()
                                                     .Where(guest => guest.FullName.Contains(tbSearchGuest.Text))
                                                    .Count(Constants.CountType.Exact, CancellationToken.None);
                        int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
                        pageHandler.MaxPage = maxPage;
                        async Task searchRequest()
                        {
                            List<Guest> guests = await service.GetAllGuestsByName(supabase, pageHandler.CurrentPage, pageHandler.MaxPage, tbSearchGuest.Text);
                            GuestsTable.ItemsSource = guests;
                        }
                        await pageHandler.HandlePreviousPage(async () => await searchRequest());
                        tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
                        break;
                    default:
                        await pageHandler.HandlePreviousPage(async () => await GetAllGuests());
                        break;
                }
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
                        await pageHandler.HandleNextPage(async () => await GetAllGuests());
                        break;

                    case "search":
                        int totalRecords = await supabase.From<Guest>()
                                                     .Where(guest => guest.FullName.Contains(tbSearchGuest.Text))
                                                    .Count(Constants.CountType.Exact, CancellationToken.None);
                        int maxPage = (int)Math.Ceiling((double)totalRecords / pageHandler.MaxItemAmountInPage);
                        pageHandler.MaxPage = maxPage;
                        async Task searchRequest()
                        {
                            List<Guest> guests = await service.GetAllGuestsByName(supabase, pageHandler.CurrentPage, pageHandler.MaxPage, tbSearchGuest.Text);
                            GuestsTable.ItemsSource = guests;
                        }
                        await pageHandler.HandleNextPage(async () => await searchRequest());
                        tbPageInfo.DataContext = $"Showing {pageHandler.CurrentPage} of {pageHandler.MaxPage} pages.";
                        break;
                    default:
                        await pageHandler.HandleNextPage(async () => await GetAllGuests());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SearchAll_Click(object sender, RoutedEventArgs e)
        {
            await GetAllGuests();
        }
    }
}
