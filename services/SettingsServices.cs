using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using ResortStudio.entity;

namespace ResortStudio.services
{
    public class SettingsService
    {
        public async Task<List<Settings>> GetAllSettings(Client supabase)
        {
            var settings = await supabase.From<Settings>()
                 .Get();
            return settings.Models;
        }

        public async Task<Settings> GetSettingById(Client supabase, int settingId)
        {
            try
            {
                var settingResult = await supabase.From<Settings>()
                   .Where(x => x.Id == settingId)
                   .Get();

                if (settingResult != null && settingResult.Model != null)
                {
                    return settingResult.Model;
                }
                else
                {
                    throw new Exception("No setting found with the provided ID.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> CreateSetting(Client supabase, Settings newSetting)
        {
            try
            {
                var createSettingResult = await supabase.From<Settings>()
                    .Insert(newSetting);

                return createSettingResult.Models.Count > 0;

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> UpdateSetting(Client supabase, Settings updatedSetting)
        {
            try
            {
                var updateSettingResult = await supabase.From<Settings>()
                    .Where(setting => setting.Id == updatedSetting.Id)
                    .Update(updatedSetting);

                // Check if the update was successful
                return updateSettingResult.Models.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public async Task<bool> RemoveSetting(Client supabase, int settingId)
        {
            try
            {
                await supabase.From<Settings>()
                    .Where(x => x.Id == settingId)
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
