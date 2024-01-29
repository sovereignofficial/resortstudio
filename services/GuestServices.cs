using ResortStudio.entity;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortStudio.services
{
    public class GuestService
    {
        public async Task<List<Guest>> GetAllGuests(Client supabase, int currentPage, int pageContentSize)
        {
            int startIndex = (currentPage - 1) * pageContentSize;
            int endIndex = startIndex + pageContentSize - 1;
            var guests = await supabase.From<Guest>()
                .Range(startIndex, endIndex)
                 .Get();
            return guests.Models;
        }

        public async Task<List<Guest>> GetAllGuestsByName(Client supabase, int currentPage, int pageContentSize, string query)
        {
            int startIndex = (currentPage - 1) * pageContentSize;
            int endIndex = startIndex + pageContentSize - 1;
            var guests = await supabase.From<Guest>()
                .Where(guest => guest.FullName.Contains(query))
                .Range(startIndex, endIndex)
                 .Get();
            return guests.Models;
        }

        public async Task<Guest> GetGuestById(Client supabase, int guestId)
        {
            try
            {
                var guestResult = await supabase.From<Guest>()
                   .Where(x => x.Id == guestId)
                   .Get();

                if (guestResult != null && guestResult.Model != null)
                {
                    return guestResult.Model;
                }
                else
                {
                    throw new Exception("No guest found with the provided ID.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> CreateGuest(Client supabase, Guest newGuest)
        {
            try
            {
                var createGuestResult = await supabase.From<Guest>()
                    .Insert(newGuest);

                return createGuestResult.Models.Count > 0;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> UpdateGuest(Client supabase, Guest updatedGuest)
        {
            try
            {
                var updateGuestResult = await supabase.From<Guest>()
                    .Where(guest => guest.Id == updatedGuest.Id)
                    .Update(updatedGuest);

                // Check if the update was successful
                return updateGuestResult.Models.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public async Task<bool> RemoveGuest(Client supabase, int guestId)
        {
            try
            {
                await supabase.From<Guest>()
                    .Where(x => x.Id == guestId)
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
