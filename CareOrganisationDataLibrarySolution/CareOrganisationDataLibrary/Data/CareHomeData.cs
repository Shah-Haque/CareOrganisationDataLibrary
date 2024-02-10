using CareOrganisationDataLibrary.DB;
using CareOrganisationDataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareOrganisationDataLibrary.Data
{
    public class CareHomeData : ICareHomeData
    {
        private readonly IDataAccess _DataAccess;
        private readonly ConnectionStringData _ConnectionString;

        public CareHomeData(IDataAccess DataAccess, ConnectionStringData ConnectionString)
        {
            _DataAccess = DataAccess;
            _ConnectionString = ConnectionString;
        }

        public async Task<int> CreateCareHome(CareHomesModel CareHomes)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("CareHome", CareHomes.careHome);
            p.Add("CareHomeDescription", CareHomes.careHomeDescription);
            p.Add("ID", DbType.Int32, direction: ParameterDirection.Output);

            await _DataAccess.SaveData("dbo.spCreateCareHome", p, _ConnectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }

        /// <summary>
        /// This will Select all Care Homes
        /// </summary>
        /// <returns></returns>
        public Task<List<CareHomesModel>> GetCareHomesAll()
        {
            return _DataAccess.LoadData<CareHomesModel, dynamic>
            (
                "dbo.spSelectAllCareHomes",
                new { },
                _ConnectionString.SqlConnectionName
            );
        }
    }
}