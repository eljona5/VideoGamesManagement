using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGamesManagement.BusinessLayer;
using VideoGamesManagement.DataLayer.Entities;
using VideoGamesManagement.DataLayer.Repositories;

namespace VideoGamesManagement.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;
        public VideoGamesController (IVideoGameService  videoGameService)
        {
            _videoGameService = videoGameService;
        }

        [HttpGet("getallvideogames")]
        public List<VideoGame> GetVideoGames()
        {
            // var videogameService = new VideoGameService();
            var games = new List<VideoGame>();
            games = _videoGameService.GetAllVideoGame();

            return games;
        }

        [HttpGet("getbyid")]
        public VideoGame GetById([FromQuery] int id)
        {
            // var videogameService = new VideoGameService();
            var gameid = _videoGameService.VideoGameById(id);
            return gameid;
        }

        [HttpPost("addnewvideogame")]
        public IActionResult AddVideoGame([FromBody] VideoGame videogame)
        {
            // var videogameService = new VideoGameService();
            _videoGameService.AddVideoGame(videogame);
            return new OkObjectResult("Video Game was added succesfully");
        }

        [HttpDelete("deletevideogame")]
        public IActionResult DeleteVideoGames([FromQuery] int id)
        {
            // var videogameService = new VideoGameService();
            var videogameExists = _videoGameService.VideoGameById(id);
            if (videogameExists == null)
            {
                throw new Exception("Record does not existst");
            }
            _videoGameService.DeleteVideoGames(videogameExists);
            return new OkObjectResult("Video game was deleted succesfully");
        }

        [HttpPut("updatevideogame")]
        public IActionResult UpdateVideoGame([FromBody] VideoGame updatedVideoGame)
        {
            try
            {
                // var videogameService = new VideoGameService();
                var existingVideoGame = _videoGameService.VideoGameById(updatedVideoGame.ID);

                if (existingVideoGame == null)
                {
                    throw new Exception("Video game not found");
                }

                existingVideoGame.Name = updatedVideoGame.Name;
                existingVideoGame.Size = updatedVideoGame.Size;
                existingVideoGame.Studio = updatedVideoGame.Studio;
                _videoGameService.UpdateVideoGame(existingVideoGame);

                return new OkObjectResult("Video game updated successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the video game: {ex.Message}");
            }
        }

        [HttpGet("filtervideogames")]
        public List<VideoGame> FilterVideoGame([FromQuery] string? name, [FromQuery] int? size, [FromQuery] string? studio)
        {
            // var videogameService = new VideoGameService();
            var videogame = _videoGameService.FilterVideoGame(name,size,studio);
            
            return videogame;
        }

    }
}
    

        
   
