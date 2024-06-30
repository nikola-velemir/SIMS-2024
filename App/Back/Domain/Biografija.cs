﻿namespace App.Back.Domain
{
    public class Biografija
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public List<int> Slike { get; set; }

        public Biografija(int id, string tekst, List<Picture> slike)
        {
            Tekst = tekst;
            Slike = new List<int>(id);
            Id = id;
            AddSlikeId(slike);
        }
        private void AddSlikeId(List<Picture> slike)
        {
            foreach (Picture slika in slike)
            {
                if (Slike.Count != 0 && Slike.Contains(slika.Id)) { continue; }
                Slike.Add(slika.Id);
            }
        }
        public Biografija(int id, string tekst, List<int> slike)
        {
            Tekst = tekst;
            Slike = slike;
            Id = id;
        }
        public Biografija(Biografija other)
        {
            Tekst = other.Tekst;
            Slike = other.Slike;
            Id = other.Id;
        }

    }
}
