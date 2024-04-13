using Microsoft.AspNetCore.Mvc;
using System;
using VideoGamesManagement.DataLayer.Entities;
using VideoGamesManagement.DataLayer.Repositories;

namespace VideoGamesManagement.BusinessLayer
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _videoGameRepository;
        public VideoGameService( IVideoGameRepository videoGameRepository)
        { 
            _videoGameRepository = videoGameRepository;
        }
        public List<VideoGame> GetAllVideoGame()
        {
            
            var games = _videoGameRepository.GetAllVideoGames();
            return games;
        }

        public VideoGame VideoGameById(int id)
        {
           
            var videogame = _videoGameRepository.GetAllVideoGames();

            var videogameid = _videoGameRepository.GetAllVideoGames()
                                        .Where(p => p.ID == id)
                                         .FirstOrDefault();
            return videogameid;
        }

        public void AddVideoGame(VideoGame videoGame)
        {
            _videoGameRepository.AddVideoGames(videoGame);  
        }

        public void DeleteVideoGames(VideoGame videoGame)
        {
            
            _videoGameRepository.DeleteVideoGames(videoGame);
        }

        public void UpdateVideoGame(VideoGame videoGame)
        {

            _videoGameRepository.UpdateVideoGame(videoGame);
        }

        public List<VideoGame> FilterVideoGame([FromQuery] string? name, [FromQuery] int? size, [FromQuery] string? studio)
        {
           
           var videogame = _videoGameRepository.GetAllVideoGames();
            if (!string.IsNullOrEmpty(name))
            {
                videogame = videogame.Where(p => p.Name.Contains(name))
                   .ToList();
            }
            if (size != 0 && size != null)
            {
                videogame = videogame.Where(p => p.Size == size).ToList();
            }
            if (!string.IsNullOrEmpty(studio))
            {
                videogame = videogame.Where(p => p.Studio.Contains(studio))
                   .ToList();
            }
            return videogame;
        }                      
    }

}
