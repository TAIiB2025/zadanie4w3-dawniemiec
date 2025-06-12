using DAL.Entities;
using IBL;
using IBL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmyController : ControllerBase
    {
        private readonly IFilmyService _filmyService;

        public FilmyController(IFilmyService filmyService)
        {
            _filmyService = filmyService;
        }

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _filmyService.get();
        }
        [HttpGet("{id}")]
        public Film GetById(int id)
        {
            return _filmyService.getById(id);
        }

        [HttpPost]
        public void Post([FromBody] FilmPostDTO filmPostDTO)
        {
            _filmyService.post(filmPostDTO);
        }
        [HttpPut("{id}")]
        public void Put([FromBody] FilmPostDTO filmPostDTO, int id)
        {
            _filmyService.put(filmPostDTO, id);
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            _filmyService.deleteById(id);
        }
    }
}
