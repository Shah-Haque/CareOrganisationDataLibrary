using CareOrganisationDataLibrary.DB;
using CareOrganisationDataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareOrganisationDataLibrary.Data
{
    public class CareQualificationData : ICareQualificationData
    {
        private readonly IDataAccess _DataAccess;
        private readonly ConnectionStringData _ConnectionString;

        public CareQualificationData(IDataAccess DataAccess, ConnectionStringData ConnectionString)
        {
            _DataAccess = DataAccess;
            _ConnectionString = ConnectionString;
        }

        public async Task<int> CreateQualification(CareQualificationModel CareQualification)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("StaffID", CareQualification.StaffID);
            p.Add("QualificationType", CareQualification.QualificationType);
            p.Add("Grade", CareQualification.Grade);
            p.Add("AttainmentDate", CareQualification.AttainmentDate);
            p.Add("QualificationID", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            await _DataAccess.SaveData("dbo.spCreateCareQualification", p, _ConnectionString.SqlConnectionName);

            return p.Get<int>("QualificationID");
        }

        public Task<List<CareQualificationModel>> GetAllQualifications()
        {
            return _DataAccess.LoadData<CareQualificationModel, dynamic>
            (
                "dbo.spSelectAllQualifications",
                new { },
                _ConnectionString.SqlConnectionName
            );
        }

        public Task<int> UpdateQualification(int QualificationID,
        string QualificationType, string grade, DateTime AttainmentDate)
        {
            return _DataAccess.SaveData
            (
                "dbo.spUpdateCareQualification",
                new
                {
                    Id = QualificationID,
                    QualificationType,
                    Grade = grade,
                    AttainmentDate
                },
                _ConnectionString.SqlConnectionName
            );
        }

        public Task<int> DeleteQualification(int QualificationID)
        {
            return _DataAccess.SaveData
            (
                 "dbo.spRemoveCareQualification",
                new
                {
                    Id = QualificationID
                },
                _ConnectionString.SqlConnectionName
           );
        }

        public async Task<CareQualificationModel> GetQualificationByID(int QualificationID)
        {
            var recs = await _DataAccess.LoadData<CareQualificationModel, dynamic>("dbo.spGetCareQualificationByID",
            new
            {
                Id = QualificationID
            },
            _ConnectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
    }
}