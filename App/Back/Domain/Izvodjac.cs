﻿namespace App.Back.Domain
{
    public class Izvodjac : Osoba
    {
        public Izvodjac() : base() { }
        public Izvodjac(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol) : base(id, ime, prezime, jmbg, datumRodjenja, pol)
        {
        }
        public Izvodjac(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol, int idNaloga) : base(id, ime, prezime, jmbg, datumRodjenja, pol, idNaloga)
        {
        }
        public Izvodjac(Izvodjac other)
        {
            Ime = other.Ime;
            Prezime = other.Prezime;
            JMBG = other.JMBG;
            DatumRodjenja = other.DatumRodjenja;
            Pol = other.Pol;
            IdNaloga = other.IdNaloga;
        }
    }
}