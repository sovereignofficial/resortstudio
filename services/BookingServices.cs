using ResortStudio.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using System.Threading;
using Postgrest;
using System.Windows;
using System.Collections;
using Newtonsoft.Json;

namespace ResortStudio.services
{
    public class BookingService
    {
        public async Task<List<BookingGridItem>> GetAllBookings(Supabase.Client supabase, int currentPage, int pageContentSize)
        {
            CabinService cabinService = new CabinService();
            GuestService guestService = new GuestService();

            int startIndex = (currentPage - 1) * pageContentSize;
            int endIndex = startIndex + pageContentSize - 1;


            var bookings = await supabase.From<BookingGridItem>()
                .Range(startIndex, endIndex)
                .Get();

            return bookings.Models;
        }

        public async Task<List<BookingGridItem>> GetAllBookingsWithStatus(Supabase.Client supabase, int currentPage, int pageContentSize,string status)
        {
            CabinService cabinService = new CabinService();
            GuestService guestService = new GuestService();

            int startIndex = (currentPage - 1) * pageContentSize;
            int endIndex = startIndex + pageContentSize - 1;


            var bookings = await supabase.From<BookingGridItem>()
                .Where((booking)=> booking.Status == status)
                .Range(startIndex, endIndex)
                .Get();

            return bookings.Models;
        }

        public async Task<Booking> GetBookingById(Supabase.Client supabase, int bookingId)
        {
            try
            {
                var bookingResult = await supabase.From<Booking>()
                   .Where(x => x.Id == bookingId)
                   .Get();

                if (bookingResult != null && bookingResult.Model != null)
                {
                    return bookingResult.Model;
                }
                else
                {
                    throw new Exception("No booking found with the provided ID.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> CreateBooking(Supabase.Client supabase, Booking newBooking)
        {
            try
            {
                var createBookingResult = await supabase.From<Booking>()
                    .Insert(newBooking);

                return createBookingResult.Models.Count > 0;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> UpdateBooking(Supabase.Client supabase, Booking updatedBooking)
        {
            try
            {
                var bookingUpdate = new Booking
                {
                    Id = updatedBooking.Id,
                    CreatedAt = updatedBooking.CreatedAt,
                    StartDate = updatedBooking.StartDate,
                    EndDate = updatedBooking.EndDate,
                    CheckInDate = updatedBooking.CheckInDate,
                    CheckOutDate = updatedBooking.CheckOutDate,
                    NumNights = updatedBooking.NumNights,
                    NumGuests = updatedBooking.NumGuests,
                    CabinPrice = updatedBooking.CabinPrice,
                    ExtrasPrice = updatedBooking.ExtrasPrice,
                    TotalPrice = updatedBooking.TotalPrice,
                    Status = updatedBooking.Status,
                    HasBreakfast = updatedBooking.HasBreakfast,
                    IsPaid = updatedBooking.IsPaid,
                    Observations = updatedBooking.Observations,
                    CabinId = updatedBooking.CabinId,
                    GuestId = updatedBooking.GuestId
                };

                var updateBookingResult = await supabase.From<Booking>()
                    .Where(booking => booking.Id == updatedBooking.Id)
                    .Update(bookingUpdate);

                return updateBookingResult.Models.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public async Task<bool> RemoveBooking(Supabase.Client supabase, int bookingId)
        {
            try
            {
                await supabase.From<Booking>()
                    .Where(x => x.Id == bookingId)
                    .Delete();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
