using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResortStudio.entity
{
    public enum BookingStatus
    {
        [Description("unconfirmed")]
        Unconfirmed,

        [Description("checked-in")]
        CheckedIn,

        [Description("checked-out")]
        CheckedOut
    }


    [Table("bookings")]
    public class Booking : BaseModel
    {
        private string _status = BookingStatus.Unconfirmed.ToString();

        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public string CreatedAt { get; set; }

        [Column("startDate")]
        public DateTime StartDate { get; set; }

        [Column("endDate")]
        public DateTime EndDate { get; set; }

        [Column("checkInDate")]
        public string CheckInDate { get; set; }

        [Column("checkOutDate")]
        public string CheckOutDate { get; set; }

        [Column("numNights")]
        public int NumNights { get; set; }

        [Column("numGuests")]
        public int NumGuests { get; set; }

        [Column("cabinPrice")]
        public double CabinPrice { get; set; }

        [Column("extrasPrice")]
        public double ExtrasPrice { get; set; }

        [Column("totalPrice")]
        public double TotalPrice { get; set; }

        [Column("status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value.ToString();
            }
        }

        [Column("hasBreakfast")]
        public bool HasBreakfast { get; set; }

        [Column("isPaid")]
        public bool IsPaid { get; set; }

        [Column("observations")]
        public string Observations { get; set; }

        [Column("cabinId")]
        public int CabinId { get; set; }

        [Column("guestId")]
        public int GuestId { get; set; }
    }
}
