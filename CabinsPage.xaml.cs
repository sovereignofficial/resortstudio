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
using ResortStudio.entity;
using ResortStudio.filters;
using ResortStudio.page_handlers;
using System.Threading;
using Postgrest;

namespace ResortStudio
{
    public partial class CabinsPage : Page
    {
        Supabase.Client supabase;
        private CabinService cabinService;
        private CabinsFilterHandler cabinsFilter;
        private CabinsPageHandler cabinsPageHandler;
        private Cabin globalSelectedCabin;

        public CabinsPage(Supabase.Client supabaseClient)
        {
            InitializeComponent();
            supabase = supabaseClient;
            cabinService = new CabinService();

            int maxItem = 5;
            int currPage = 1;
            int maxPage = 1;
            cabinsPageHandler = new CabinsPageHandler(currPage, maxPage, maxItem);

            string initialFilter = "all";
            List<string> filters = new List<string>() { "all", "discount", "noDiscount" };
            cabinsFilter = new CabinsFilterHandler(initialFilter, filters);
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GetAllCabins(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private async void GetAllCabins(object sender, RoutedEventArgs e)
        {
            if (cabinsFilter.CurrentFilterState != "all")
            {
                cabinsPageHandler.CurrentPage= 1;
                cabinsFilter.CurrentFilterState = cabinsFilter.Filters[0];
                FilterBtnAll.Style = Application.Current.Resources["PrimaryButton"] as Style;
                FilterBtnDiscount.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnNoDiscount.Style = Application.Current.Resources["SecondaryButton"] as Style;
            }
            int totalRecords = await supabase.From<Cabin>()
                     .Count(Constants.CountType.Exact, CancellationToken.None);
            int maxPage = (int)Math.Ceiling((double)totalRecords / cabinsPageHandler.MaxItemAmountInPage);
            cabinsPageHandler.MaxPage = maxPage;
            List<Cabin> cabins = await cabinService.GetAllCabins(supabase, cabinsPageHandler.CurrentPage, cabinsPageHandler.MaxItemAmountInPage);
            CabinTable.ItemsSource = cabins;
            tbPageInfo.DataContext = $"Showing {cabinsPageHandler.CurrentPage} of {cabinsPageHandler.MaxPage} pages.";

        }

        private async void GetCabinsWithoutDiscount(object sender, RoutedEventArgs e)
        {
            if (cabinsFilter.CurrentFilterState != "noDiscount")
            {
                cabinsPageHandler.CurrentPage= 1;
                cabinsFilter.CurrentFilterState = cabinsFilter.Filters[2];
                FilterBtnAll.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnDiscount.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnNoDiscount.Style = Application.Current.Resources["PrimaryButton"] as Style;
            }
            int totalRecords = await supabase.From<Cabin>()
                                 .Where(cabin => cabin.Discount == 0)
                                 .Count(Constants.CountType.Exact, CancellationToken.None);
            int maxPage = (int)Math.Ceiling((double)totalRecords / cabinsPageHandler.MaxItemAmountInPage);
            cabinsPageHandler.MaxPage = maxPage;
            List<Cabin> cabins = await cabinService.GetAllCabinsIfDiscount(supabase, false, cabinsPageHandler.CurrentPage, cabinsPageHandler.MaxItemAmountInPage);
            CabinTable.ItemsSource = cabins;
            tbPageInfo.DataContext = $"Showing {cabinsPageHandler.CurrentPage} of {cabinsPageHandler.MaxPage} pages.";


        }

        private async void GetCabinsWithDiscount(object sender, RoutedEventArgs e)
        {
            if (cabinsFilter.CurrentFilterState != "discount")
            {
                cabinsPageHandler.CurrentPage = 1;
                cabinsFilter.CurrentFilterState = cabinsFilter.Filters[1];
                FilterBtnAll.Style = Application.Current.Resources["SecondaryButton"] as Style;
                FilterBtnDiscount.Style = Application.Current.Resources["PrimaryButton"] as Style;
                FilterBtnNoDiscount.Style = Application.Current.Resources["SecondaryButton"] as Style;
            }
            int totalRecords = await supabase.From<Cabin>()
                     .Where(cabin => cabin.Discount > 0)
                     .Count(Constants.CountType.Exact, CancellationToken.None);
            int maxPage = (int)Math.Ceiling((double)totalRecords / cabinsPageHandler.MaxItemAmountInPage);
            cabinsPageHandler.MaxPage = maxPage;
            List<Cabin> cabins = await cabinService.GetAllCabinsIfDiscount(supabase, true, cabinsPageHandler.CurrentPage, cabinsPageHandler.MaxItemAmountInPage);
            CabinTable.ItemsSource = cabins;
            tbPageInfo.DataContext = $"Showing {cabinsPageHandler.CurrentPage} of {cabinsPageHandler.MaxPage} pages.";

        }

        private async void PreviousBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (cabinsFilter.CurrentFilterState)
                {
                    case "all":
                        await cabinsPageHandler.HandlePreviousPage(async () => GetAllCabins(sender, e));
                        break;
                    case "discount":
                        await cabinsPageHandler.HandlePreviousPage(async () => GetCabinsWithDiscount(sender, e));
                        break;
                    case "noDiscount":
                        await cabinsPageHandler.HandlePreviousPage(async () => GetCabinsWithoutDiscount(sender, e));
                        break;


                    default:
                        await cabinsPageHandler.HandlePreviousPage(async () => GetAllCabins(sender, e));
                        break;
                }
                tbPageInfo.DataContext = $"Showing {cabinsPageHandler.CurrentPage} of {cabinsPageHandler.MaxPage} pages.";
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
                switch (cabinsFilter.CurrentFilterState)
                {
                    case "all":
                        await cabinsPageHandler.HandleNextPage(async () => GetAllCabins(sender, e));
                        break;
                    case "discount":
                        await cabinsPageHandler.HandleNextPage(async () => GetCabinsWithDiscount(sender, e));
                        break;
                    case "noDiscount":
                        await cabinsPageHandler.HandleNextPage(async () => GetCabinsWithoutDiscount(sender, e));
                        break;


                    default:
                        await cabinsPageHandler.HandleNextPage(async () => GetAllCabins(sender, e));
                        break;
                }
                tbPageInfo.DataContext = $"Showing {cabinsPageHandler.CurrentPage} of {cabinsPageHandler.MaxPage} pages.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void UpdateCabin(object sender, RoutedEventArgs e)
        {
            try
            {
                if (globalSelectedCabin != null)
                {
                    await cabinService.UpdateCabin(supabase, globalSelectedCabin);
                    MessageBox.Show($"{globalSelectedCabin.Name} updated successfully.");
                    GetAllCabins(sender, e);
                }
                else
                {
                    throw new Exception("Something went wrong!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RemoveCabin(object sender, RoutedEventArgs e)
        {
            try
            {
                if (globalSelectedCabin != null)
                {
                    await cabinService.RemoveCabin(supabase, globalSelectedCabin.Id);
                    MessageBox.Show($"{globalSelectedCabin.Name} removed successfully.");
                    GetAllCabins(sender, e);
                }
                else
                {
                    throw new Exception("Something went wrong!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddCabin(object sender, RoutedEventArgs e)
        {
            var addCabinWindow = new AddCabinWindow(supabase);
            addCabinWindow.Show();
        }


        private void CabinTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                globalSelectedCabin = CabinTable.SelectedItem as Cabin;
                if (globalSelectedCabin != null)
                {
                    this.DataContext = globalSelectedCabin;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbFull_Checked(object sender, RoutedEventArgs e)
        {
            globalSelectedCabin.IsFull = true;
        }

        private void cbFull_Unchecked(object sender, RoutedEventArgs e)
        {
            globalSelectedCabin.IsFull = false;
        }
    }
}
