using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.filters
{
    internal class GuestFilterHandler : FilterManager
    {
        public override string CurrentFilterState { get; set; }
        public override List<string> Filters { get; set; }

        public GuestFilterHandler(string initialFilter, List<string> filters) {
            CurrentFilterState = initialFilter;
            Filters = filters;
        }
        public override void OnFilterChange()
        {
            throw new NotImplementedException();
        }
    }
}
