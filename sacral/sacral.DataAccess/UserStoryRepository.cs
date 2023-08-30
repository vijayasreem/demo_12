using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sacral
{
    public class UserStoryRepository : IUserStoryService
    {
        private readonly string _connectionString;

        public UserStoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserStoryModel> GetUserStoryAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM UserStory WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new UserStoryModel
                            {
                                Id = (int)reader["Id"],
                                Content = (string)reader["Content"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<UserStoryModel>> GetAllUserStoriesAsync()
        {
            var userStories = new List<UserStoryModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM UserStory";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            userStories.Add(new UserStoryModel
                            {
                                Id = (int)reader["Id"],
                                Content = (string)reader["Content"]
                            });
                        }
                    }
                }
            }

            return userStories;
        }

        public async Task CreateUserStoryAsync(UserStoryModel userStory)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO UserStory (Content) VALUES (@Content)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Content", userStory.Content);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateUserStoryAsync(UserStoryModel userStory)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE UserStory SET Content = @Content WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userStory.Id);
                    command.Parameters.AddWithValue("@Content", userStory.Content);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteUserStoryAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM UserStory WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    // Add repository classes for other models (AcceptanceCriteria, Document, Customer, etc.) here.
    // ...

    // Example connection string: "server=myServerAddress;database=myDatabase;user=myUser;password=myPassword"
    public class RepositoryContext
    {
        public UserStoryRepository UserStories { get; }
        // Add repository properties for other models here.
        // ...

        public RepositoryContext(string connectionString)
        {
            UserStories = new UserStoryRepository(connectionString);
            // Initialize other repositories here.
            // ...
        }
    }
}