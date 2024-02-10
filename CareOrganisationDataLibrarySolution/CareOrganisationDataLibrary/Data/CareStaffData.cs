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
    public class CareStaffData : ICareStaffData
    {
        private readonly IDataAccess _DataAccess;
        private readonly ConnectionStringData _ConnectionString;

        public CareStaffData(IDataAccess DataAccess, ConnectionStringData ConnectionString)
        {
            _DataAccess = DataAccess;
            _ConnectionString = ConnectionString;
        }

        public async Task<int> CreateCareStaff(CareStaffModel careStaff)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("CareHomeID", careStaff.CareHomeID);
            p.Add("FirstName", careStaff.FirstName);
            p.Add("LastName", careStaff.LastName);
            p.Add("DateOfBirth", careStaff.DateOfBirth);
            p.Add("JobTitle", careStaff.JobTitle);
            p.Add("AnnualSalary", careStaff.AnnualSalary);
            p.Add("StaffID", System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

            await _DataAccess.SaveData("dbo.spCreateCareStaff", p, _ConnectionString.SqlConnectionName);

            return p.Get<int>("StaffID");
        }

        public Task<List<CareStaffModel>> GetCareStaffAll()
        {
            return _DataAccess.LoadData<CareStaffModel, dynamic>
            (
                "dbo.spSelectAllCareStaff",
                new { },
                _ConnectionString.SqlConnectionName
            );
        }

        public Task<int> UpdateCareStaff(int StaffID,
        string FirstName, string LastName, string JobTitle,
        decimal AnnualSalary)
        {
            return _DataAccess.SaveData
            (
                "dbo.spUpdateCareStaff",
                new
                {
                    Id = StaffID,
                    FirstName,
                    LastName,
                    JobTitle,
                    AnnualSalary
                },
                _ConnectionString.SqlConnectionName
            );
        }

        public Task<int> DeleteCareStaff(int StaffID)
        {
            return _DataAccess.SaveData
            (
                 "dbo.spRemoveCareStaff",
                  new
                  {
                      Id = StaffID
                  },
                  _ConnectionString.SqlConnectionName
            );
        }

        public async Task<CareStaffModel> GetCareStaffByID(int StaffID)
        {
            var recs = await _DataAccess.LoadData<CareStaffModel, dynamic>("dbo.spGetCareStaffByID",
               new
               {
                   Id = StaffID
               },
               _ConnectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
    }
}