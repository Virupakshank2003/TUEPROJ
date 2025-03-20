
using Dapper;
using System.Data;
using TUEPROJ.Domain;

namespace TUEPROJ.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;
        public UserRepository(IDbConnection dbConnection)
        {
                _dbConnection = dbConnection;
        }


        public async Task<int> AddUserAsync(User user)
        {
            string sql = @"
                INSERT INTO dbo.Users (Name, Email, Role, Status) 
                VALUES (@Name, @Email, @Role, @Status); 
                SELECT CAST(SCOPE_IDENTITY() AS INT);"; 

            var userId = await _dbConnection.ExecuteScalarAsync<int>(sql, new
            {
                user.Name,
                user.Email,
                Role = user.Role.ToString(), 
                user.Status
            });

            return userId;





        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var query = "SELECT Id, Name, Email, Role, Status FROM Users";
            return await _dbConnection.QueryAsync<User>(query);
        }


        public async Task<IEnumerable<User>> SearchUsersAsync(string searchTerm)
        {
            var sql = "SELECT * FROM Users Where Name LIKE @Search OR Email LIKE @Search";
            var users = await _dbConnection.QueryAsync<User>(sql, new { Search = $"%{searchTerm}%" });
            return users;
        }

       
    }
}
