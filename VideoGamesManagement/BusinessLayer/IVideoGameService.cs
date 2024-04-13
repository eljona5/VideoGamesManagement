using Microsoft.AspNetCore.Mvc;
using VideoGamesManagement.DataLayer.Entities;

namespace VideoGamesManagement.BusinessLayer
{
    public interface IVideoGameService
    {
        public List<VideoGame> FilterVideoGame([FromQuery] string? name, [FromQuery] int? size, [FromQuery] string? studio);
        public void UpdateVideoGame(VideoGame videoGame);
        public void DeleteVideoGames(VideoGame videoGame);
        public void AddVideoGame(VideoGame videoGame);
        public VideoGame VideoGameById(int id);
        public List<VideoGame> GetAllVideoGame();
    }
}
