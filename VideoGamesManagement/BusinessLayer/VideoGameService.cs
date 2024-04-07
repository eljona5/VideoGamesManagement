using System;
using VideoGamesManagement.DataLayer.Entities;
using VideoGamesManagement.DataLayer.Repositories;

namespace VideoGamesManagement.BusinessLayer
{
    public class VideoGameService
    {
        public List<VideoGame> GetAllVideoGame()
        {
            var gamesRepository = new VideoGameRepository();
            var games = gamesRepository.GetAllVideoGames();
            return games;
        }
        public VideoGame VideoGameById(int id)
        {
            var gamesRepository = new VideoGameRepository();
            var videogame = gamesRepository.GetAllVideoGames();

            var videogameid = gamesRepository.GetAllVideoGames()
                                        .Where(p => p.ID == id)
                                         .FirstOrDefault();
            return videogameid;
        }
        public void AddVideoGame(VideoGame videoGame)
        {
            var gamesRepository = new VideoGameRepository();
             gamesRepository.AddVideoGames(videoGame);
            
        }

        public void DeleteVideoGames(VideoGame videoGame)
        {
            var gamesRepository = new VideoGameRepository();
            gamesRepository.DeleteVideoGames(videoGame);

        }

        public void UpdateVideoGame(VideoGame videoGame)
        {
            var gamesRepository = new VideoGameRepository();
            gamesRepository.UpdateVideoGame(videoGame);

        }
    }

}
