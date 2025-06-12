using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Rezyser { get; set; }
        public string Gatunek { get; set; }
        public int Rok_wydania { get; set; }
    }
}
