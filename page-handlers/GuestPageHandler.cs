﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResortStudio.page_handlers
{
    internal class GuestPageHandler : PageManager
    {
        public override int CurrentPage { get; set; }
        public override int MaxPage { get; set; }
        public override int MaxItemAmountInPage { get; set; }

        public GuestPageHandler(int initialPage, int maxPageAmount, int maxItemAmount)
        {
            CurrentPage = initialPage;
            MaxPage = maxPageAmount;
            MaxItemAmountInPage = maxItemAmount;
        }

        public override async Task HandleNextPage(PageChangeDelegate callback)
        {
            if (CurrentPage == MaxPage)
            {
                MessageBox.Show("You are already in last page!");
            }
            else
            {
                CurrentPage++;
                await callback();
            }
        }

        public override async Task HandlePreviousPage(PageChangeDelegate callback)
        {
            if (CurrentPage == 1)
            {
                MessageBox.Show("You are already in first page!");
            }
            else
            {
                CurrentPage--;
                await callback();
            }
        }
    }
}
