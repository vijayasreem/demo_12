using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sacral.DataAccess;
using sacral.DTO;

namespace sacral.Service
{
    public class UserStoryService : IUserStoryService
    {
        private readonly IUserStoryRepository _userStoryRepository;

        public UserStoryService(IUserStoryRepository userStoryRepository)
        {
            _userStoryRepository = userStoryRepository;
        }

        public async Task<UserStoryModel> GetUserStoryAsync(int id)
        {
            return await _userStoryRepository.GetUserStoryAsync(id);
        }

        public async Task<List<UserStoryModel>> GetAllUserStoriesAsync()
        {
            return await _userStoryRepository.GetAllUserStoriesAsync();
        }

        public async Task CreateUserStoryAsync(UserStoryModel userStory)
        {
            await _userStoryRepository.CreateUserStoryAsync(userStory);
        }

        public async Task UpdateUserStoryAsync(UserStoryModel userStory)
        {
            await _userStoryRepository.UpdateUserStoryAsync(userStory);
        }

        public async Task DeleteUserStoryAsync(int id)
        {
            await _userStoryRepository.DeleteUserStoryAsync(id);
        }
    }

    public interface IUserStoryService
    {
        Task<UserStoryModel> GetUserStoryAsync(int id);
        Task<List<UserStoryModel>> GetAllUserStoriesAsync();
        Task CreateUserStoryAsync(UserStoryModel userStory);
        Task UpdateUserStoryAsync(UserStoryModel userStory);
        Task DeleteUserStoryAsync(int id);
    }
}