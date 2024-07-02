using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Domain
{
    public class Band : MusicalNotion
    {
        public string Name { get; set; }
        public Biography Biography { get; set; }
        public Band() : base() { }
        public Band(int id, string description, Biography bio, int musicalGenreId, int profilePictureId) : base(id, description, musicalGenreId, profilePictureId)
        {
            Biography = bio;
        }
        public Band(Band other)
        {
            Id = other.Id;
            Name = other.Name;
            Description = other.Description;
            Biography = other.Biography;
            MusicalGenreId = other.MusicalGenreId;
            ProfileImageId = other.ProfileImageId;
        }

    }
}
