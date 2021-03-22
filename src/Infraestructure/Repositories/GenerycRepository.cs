using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Application.Repositories
{
    /// <summary>
    /// GenerycRepository Repository Abstractions
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public abstract class GenerycRepository
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Contructor GeneryRepository 
        /// </summary>
        /// <param name="configuration">Injection Configuration Settings</param>
        protected GenerycRepository(IConfiguration configuration) => _configuration = configuration;

        /// <summary>
        /// Method get connection database
        /// </summary>
        /// <param name="dbConnection">Connection string configuration settings</param>
        /// <returns></returns>
        private SqliteConnection GetConnection(string dbConnection) => new SqliteConnection(dbConnection);

        /// <summary>
        /// GetAsync data of Ienumerable from database orm dapper 
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="NameProcedureOrQueryString">Name procedure or query string</param>
        /// <param name="parameters">parameters object querys </param>
        /// <param name="typeCommand">type execution database</param>
        /// <returns>IEnuerable de generic objects</returns>
        public async Task<IEnumerable<TOutput>> GetAsync<TOutput>(string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            using var connection = GetConnection(this._configuration.GetConnectionString("connection"));
            var cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
            connection.Open();
            if (parameters != null)
                cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
            return await connection.QueryAsync<TOutput>(cmd);
        }

        /// <summary>
        /// Get first or default entity
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="NameProcedureOrQueryString">Name procedure or query string</param>
        /// <param name="parameters">parameters object querys </param>
        /// <param name="typeCommand">type execution database</param>
        /// <returns>Get entity first or default</returns>
        public async Task<TOutput> GetAsyncFirst<TOutput>(
           string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            using var connection = GetConnection(this._configuration.GetConnectionString("connection"));
            var cmd = new CommandDefinition(NameProcedureOrQueryString, null, null, null, typeCommand);
             connection.Open();
            if (parameters != null)
                cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
            return await connection.QueryFirstOrDefaultAsync<TOutput>(cmd);
        }
    }
}
