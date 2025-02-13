
namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        Task<List<T>> ExecuteQueryAsync<T>(string sql, object? param = null);
        Task<int> ExecuteCommandAsync<T>(string sql, object? param = null);
    }
}
