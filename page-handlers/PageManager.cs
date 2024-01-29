using ResortStudio.services;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ResortStudio
{
    abstract class PageManager
    {
        public abstract int CurrentPage { get; set; }
        public abstract int MaxPage { get; set; }
        public abstract int MaxItemAmountInPage { get; set; }
        public delegate Task PageChangeDelegate();
        public abstract Task HandlePreviousPage(PageChangeDelegate callback);
        public abstract Task HandleNextPage(PageChangeDelegate callback);
    }
}
