
using Dapper;
using System.Data;
using System.Globalization;
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
        ///////////////// SEARCH + FILTER BY SEARCH + GET ALL THE USERS
        public async Task<(IEnumerable<User>Users,int TotalCount)> GetUsersWithSearchAsync(string?searchTerm,int page,int pageSize)
        {
            //string a = "kuggi0";
            string baseQuery = "SELECT Id, Name, Email, Role, Status FROM dbo.Users";
            string countQuery = "SELECT COUNT(*) FROM dbo.Users";

            var parameters = new DynamicParameters();
            parameters.Add("Offset", (page - 1) * pageSize);
            parameters.Add("PageSize", pageSize);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                baseQuery += " WHERE Name LIKE @Search OR Email LIKE @Search";
                countQuery += " WHERE Name LIKE @Search OR Email LIKE @Search";
                parameters.Add("Search", $"%{searchTerm}%");
            }

            baseQuery += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

            var users = await _dbConnection.QueryAsync<User>(baseQuery, parameters);
            var totalCount = await _dbConnection.ExecuteScalarAsync<int>(countQuery, parameters);

            return (users, totalCount);
        }
        ///////// GET THE USER BY ID
        public async Task<User> GetByIdAsync(int id)
        {
            string query = "Select Id,Name,Email,Role,Status from Users WHERE Id=@Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }

        ////////////// 
        public async Task UpdateAsync(User user)
        {
            string query = "UPDATE Users SET Status = @Status WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { user.Status, user.Id });

        }

        public async Task DeleteAsync(User user)
        {
            string query = "DELETE FROM Users WHERE Id = @Id;";
            await _dbConnection.ExecuteAsync(query, new { Id = user.Id });
        }




    }
}
