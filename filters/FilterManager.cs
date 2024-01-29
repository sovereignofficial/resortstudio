using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.filters
{
    abstract class FilterManager
    {
        public abstract string CurrentFilterState { get; set; }
        public abstract List<string> Filters { get; set; }

        public abstract void OnFilterChange();
    }
}
