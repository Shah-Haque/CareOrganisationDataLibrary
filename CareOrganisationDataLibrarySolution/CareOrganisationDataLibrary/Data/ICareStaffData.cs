using CareOrganisationDataLibrary.Models;

namespace CareOrganisationDataLibrary.Data
{
    public interface ICareStaffData
    {
        Task<int> CreateCareStaff(CareStaffModel careStaff);
        Task<int> DeleteCareStaff(int StaffID);
        Task<List<CareStaffModel>> GetCareStaffAll();
        Task<CareStaffModel> GetCareStaffByID(int StaffID);
        Task<int> UpdateCareStaff(int StaffID, string FirstName, string LastName, string JobTitle, decimal AnnualSalary);
    }
}