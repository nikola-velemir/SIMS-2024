using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Domain
{
    public class MusicalGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MusicalGenre(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public MusicalGenre() { }

    }
}
