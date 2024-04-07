using VideoGamesManagement.DataLayer.Entities;
using static VideoGamesManagement.DataLayer.DBContext.VideoGamesContext;
namespace VideoGamesManagement.DataLayer.Repositories
{
    public class VideoGameRepository
    {
        private readonly VideoGamesManagementDBContext _gamesManagementDBContext;
        public VideoGameRepository()
        {
            _gamesManagementDBContext = new VideoGamesManagementDBContext();
        }
        public void AddVideoGames(VideoGame game)
        {
            _gamesManagementDBContext.VideoGames.Add(game);
            _gamesManagementDBContext.SaveChanges();
        }
        // Get All video games
        public List<VideoGame> GetAllVideoGames()
        {
            var games = _gamesManagementDBContext.VideoGames.ToList();
            return games;
        }
        // Get By ID
        public VideoGame FindByID(int id)
        {
            try
            {
                var game = _gamesManagementDBContext.VideoGames.Where(p => p.ID == id)
                    .FirstOrDefault();
                return game;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        //Update
        //Remove
        public void DeleteVideoGames(VideoGame game)
        {
            try
            {
                _gamesManagementDBContext.VideoGames.Remove(game);
                _gamesManagementDBContext.SaveChanges();
                Console.WriteLine("Student removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message.ToString());
                throw ex;
            }
        }

        public void UpdateVideoGame(VideoGame game)
        {
            try
            {
                _gamesManagementDBContext.VideoGames.Update(game);
                _gamesManagementDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
