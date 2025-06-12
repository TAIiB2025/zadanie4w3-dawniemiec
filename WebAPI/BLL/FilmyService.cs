using DAL.Entities;
using IBL;
using IBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BLL
{
    public class FilmyService : IFilmyService
    {
        private static int IdGen = 1;
        private static List<Film> filmy =
            [
                new Film() { Id = IdGen++, Tytul = "Incepcja", Rezyser = "Christopher Nolan", Gatunek = "Sci-Fi", Rok_wydania = 2010 },
                new Film() { Id = IdGen++,Tytul = "Parasite", Rezyser = "Bong Joon-ho", Gatunek = "Dramat", Rok_wydania = 2019 },
                new Film() { Id = IdGen++, Tytul= "Skazani na Shawshank", Rezyser= "Frank Darabont", Gatunek= "Dramat", Rok_wydania= 1994 },
                new Film() { Id =IdGen++, Tytul= "Matrix", Rezyser= "Lana i Lilly Wachowski", Gatunek= "Sci-Fi", Rok_wydania= 1999 },
                new Film() { Id = IdGen++, Tytul= "Gladiator", Rezyser= "Ridley Scott", Gatunek= "Historyczny", Rok_wydania= 2000}
            ];

        public void deleteById(int id)
        {
            Film? film = filmy.Find(x => x.Id == id);
            if (film != null)
            {
                filmy.Remove(film);
            }
            else
            {
                throw new ApplicationException("Nie ma takiego filmu");
            }
        }

        public IEnumerable<Film> get()
        {
            return filmy.Select(k => new Film()
            {
                Id = k.Id,
                Tytul = k.Tytul,
                Rezyser = k.Rezyser,
                Gatunek = k.Gatunek,
                Rok_wydania = k.Rok_wydania
            });
        }

        public Film getById(int id)
        {
            Film? ksiazka = filmy.Find(k => k.Id == id);
            if (ksiazka is null)
            {
                throw new ApplicationException($"Brak filmu o podanym id: {id}");
            }
            return ksiazka;
        }

        public void post(FilmPostDTO film)
        {
            Film filmToAdd = new Film
            {
                Id = IdGen++,
                Tytul = film.Tytul,
                Rezyser = film.Rezyser,
                Gatunek = film.Gatunek,
                Rok_wydania = film.Rok_wydania

            };
            filmy.Add(filmToAdd);
        }

        public void put(FilmPostDTO film, int id)
        {
            Film? filmToUpdate = filmy.Find(k => k.Id == id);
            if (filmToUpdate is null)
            {
                throw new ApplicationException("Brak filmu o podanym id");
            }

            filmToUpdate.Tytul = film.Tytul;
            filmToUpdate.Rezyser = film.Rezyser;
            filmToUpdate.Gatunek = film.Gatunek;
            filmToUpdate.Rok_wydania = film.Rok_wydania;

        }

    }
}
