using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.DAL;
using System.Collections.Generic;

namespace CustomerAnalyticSystem.BLL.Services
{
    public class PreferencesService
    {
        public List<PreferencesBaseModel> GetBasePreferencesModel()
        {
            BestMapper map = new();
            var service = new PreferencesRepository();
            var dto = service.GetAllPreferences();
            List<PreferencesBaseModel> result = map.MapFromPreferencesDTOToPreferenceBaseModel(dto);
            return result;
        }
    }
}
