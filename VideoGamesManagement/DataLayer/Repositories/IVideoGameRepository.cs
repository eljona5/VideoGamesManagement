using VideoGamesManagement.DataLayer.Entities;

namespace VideoGamesManagement.DataLayer.Repositories
{
    public interface IVideoGameRepository
    {
        public void AddVideoGames(VideoGame game);
        public void DeleteVideoGames(VideoGame game);
        public List<VideoGame> GetAllVideoGames();
        public VideoGame FindByID(int id);
        public void UpdateVideoGame(VideoGame game);
    }
}
