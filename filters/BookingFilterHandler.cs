using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResortStudio.filters
{
    internal class BookingFilterHandler : FilterManager
    {
        public override string CurrentFilterState { get; set; }
        public override List<string> Filters { get; set; }

        public BookingFilterHandler(string initialState, List<string> filters)
        {
            CurrentFilterState = initialState;
            Filters = filters;
        }

        public override void OnFilterChange()
        {
            MessageBox.Show("Filter Changed! Current filter:{0}",CurrentFilterState);
        }
    }
}
