using CareOrganisationDataLibrary.Models;

namespace CareOrganisationDataLibrary.Data
{
    public interface ICareHomeData
    {
        Task<int> CreateCareHome(CareHomesModel CareHome);
        Task<List<CareHomesModel>> GetCareHomesAll();
    }
}