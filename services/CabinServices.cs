using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResortStudio.entity;

namespace ResortStudio.services
{
    class CabinService
    {
        public async Task<List<Cabin>> GetAllCabins(Client supabase, int currentPage, int pageContentSize)
        {
            int startIndex = (currentPage - 1) * pageContentSize;
            int endIndex = startIndex + pageContentSize - 1;
            var cabins = await supabase.From<Cabin>()
                 .Range(startIndex, endIndex)
                 .Get();
            return cabins.Models;
        }
        public async Task<List<Cabin>> GetAllCabinsIfDiscount(Client supabase, bool justDiscount, int currentPage, int pageContentSize)
        {
            int startIndex = (currentPage - 1) * pageContentSize;
            int endIndex = startIndex + pageContentSize - 1;
            if (justDiscount)
            {
                var cabins = await supabase.From<Cabin>()
                                         .Where(cabin => cabin.Discount > 0)
                                         .Range(startIndex, endIndex)
                                         .Get();
                return cabins.Models;
            }
            else
            {
                var cabins = await supabase.From<Cabin>()
                                         .Where(cabin => cabin.Discount == 0)
                                         .Range(startIndex, endIndex)
                                         .Get();
                return cabins.Models;
            }
        }

        public async Task<Cabin> GetCabinById(Client supabase, int cabinId)
        {
            try
            {
                var cabinResult = await supabase.From<Cabin>()
                   .Where(x => x.Id == cabinId)
                   .Get();

                if (cabinResult != null && cabinResult.Model != null)
                {
                    return cabinResult.Model;
                }
                else
                {
                    throw new Exception("No cabin found with the provided ID.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }



        public async Task<bool> CreateCabin(Client supabase, Cabin newCabin)
        {
            try
            {
                var createCabinResult = await supabase.From<Cabin>()
                    .Insert(newCabin);

                return createCabinResult.Models.Count > 0;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> UpdateCabin(Client supabase, Cabin updatedCabin)
        {
            try
            {
                var updateCabinResult = await supabase.From<Cabin>()
                    .Where(cabin => cabin.Id == updatedCabin.Id)
                    .Update(updatedCabin);

                // Check if the update was successful
                return updateCabinResult.Models.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


        public async Task<bool> RemoveCabin(Client supabase, int cabinId)
        {
            try
            {
                await supabase.From<Cabin>()
                    .Where(x => x.Id == cabinId)
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
