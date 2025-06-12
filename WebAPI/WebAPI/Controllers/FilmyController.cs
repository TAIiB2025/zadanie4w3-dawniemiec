using DAL.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
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
        private readonly IValidator<FilmPostDTO> _validator;

        public FilmyController(IFilmyService filmyService, IValidator<FilmPostDTO> validator)
        {
            _filmyService = filmyService;
            _validator = validator;
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
        //public void Put([FromBody] FilmPostDTO filmPostDTO, int id)
        //{
        //    _filmyService.put(filmPostDTO, id);
        //}

        public async Task<IActionResult> Put([FromBody] FilmPostDTO filmPostDTO, int id)
        {
            ValidationResult valRes = await _validator.ValidateAsync(filmPostDTO);
            if (valRes.IsValid)
            {
                _filmyService.put(filmPostDTO, id);
                return Ok("Film zaktualizowany");
            }
            else
            {
                valRes.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            _filmyService.deleteById(id);
        }
    }
}
