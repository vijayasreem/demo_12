namespace sacral.Service
{
    public interface IUserStoryService
    {
        Task<UserStoryModel> GetUserStoryAsync(int id);
        Task<List<UserStoryModel>> GetAllUserStoriesAsync();
        Task CreateUserStoryAsync(UserStoryModel userStory);
        Task UpdateUserStoryAsync(UserStoryModel userStory);
        Task DeleteUserStoryAsync(int id);
    }
}