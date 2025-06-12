using DAL.Entities;
using IBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IFilmyService
    {
        public IEnumerable<Film> get();
        public Film getById(int id);
        public void deleteById(int id);
        public void put(FilmPostDTO filmPostDTO, int id);
        public void post(FilmPostDTO filmPostDTO);
    }
}
