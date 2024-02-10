
namespace CareOrganisationDataLibrary.DB
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string StoredProcedure, U Parameters, string ConnectionStringName);
        Task<int> SaveData<T>(string StoredProcedure, T Parameters, string ConnectionStringName);
    }
}