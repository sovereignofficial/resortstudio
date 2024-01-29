using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.entity
{
    public class BookingGridItem :Booking
    {
        public string FormattedDates
        {
            get
            {
                return $"{StartDate.ToString("dd MMMM yyyy")} - {EndDate.ToString("dd MMMM yyyy")}";
            }
        }

        public string Amount
        {
            get
            {
                return $"${TotalPrice}";
            }
        }

    }
}
