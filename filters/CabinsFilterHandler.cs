using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.filters
{
    internal class CabinsFilterHandler : FilterManager
    {
        public override string CurrentFilterState { get; set; }
        public override List<string> Filters { get; set; }

        public CabinsFilterHandler(string currentFilter, List<string> filters)
        {
            CurrentFilterState = currentFilter;
            Filters = filters;
        }

        public override void OnFilterChange()
        {
          
        }
    }
}
