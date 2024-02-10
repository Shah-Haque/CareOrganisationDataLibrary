using CareOrganisationDataLibrary.Models;

namespace CareOrganisationDataLibrary.Data
{
    public interface ICareQualificationData
    {
        Task<int> CreateQualification(CareQualificationModel CareQualification);
        Task<int> DeleteQualification(int QualificationID);
        Task<List<CareQualificationModel>> GetAllQualifications();
        Task<CareQualificationModel> GetQualificationByID(int QualificationID);
        Task<int> UpdateQualification(int QualificationID, string QualificationType, string grade, DateTime AttainmentDate);
    }
}