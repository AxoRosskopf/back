using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Npgsql;
using Dapper;

namespace Infrastructure.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<T>> ExecuteQueryAsync<T>(string sql, object? param = null)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return (await connection.QueryAsync<T>(sql, param)).ToList();
        }

        public async Task<int> ExecuteCommandAsync<T>(string sql, object? param = null)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, param);
        }
    }
}
