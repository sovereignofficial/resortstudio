using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.entity
{
    [Table("settings")]
    public class Settings : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public string CreatedAt { get; set; }

        [Column("minBookingLength")]
        public int MinBookingLength { get; set; }

        [Column("maxBookingLength")]
        public int MaxBookingLength { get; set; }

        [Column("maxGuestsPerBooking")]
        public int MaxGuestsPerBooking { get; set; }

        [Column("breakfastPrice")]
        public int BreakfastPrice { get; set; }
    }
}
