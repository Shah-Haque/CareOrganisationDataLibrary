using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareOrganisationDataLibrary.DB
{
    public class SQLDB : IDataAccess
    {
        private readonly IConfiguration _Config;

        public SQLDB(IConfiguration Config)
        {
            _Config = Config;
        }

        public async Task<List<T>> LoadData<T, U>(string StoredProcedure,
        U Parameters, string ConnectionStringName)
        {
            string ConnectionString = _Config.GetConnectionString(ConnectionStringName);

            //This opens a new connection to sql server through a using 
            //method which will close the connection when the instance of the application
            //closes
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                var rows = await connection.QueryAsync<T>
                (
                    StoredProcedure,
                    Parameters,
                    commandType: CommandType.StoredProcedure
                );

                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string StoredProcedure,
        T Parameters, string ConnectionStringName)
        {
            string ConnectionString = _Config.GetConnectionString(ConnectionStringName);

            //This opens a new connection to sql server through a using 
            //method which will close the connection when the instance of the application
            //closes
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync
                (
                     StoredProcedure,
                     Parameters,
                     commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
