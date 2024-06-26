﻿namespace App.Domain
{
    public class TipUcesnika
    {
        public string Tip { get; set; } 
        public int Id { get; set; }
        public TipUcesnika(string tip, int id)
        {
            Tip = tip;
            Id = id;
        }
        public TipUcesnika(TipUcesnika other)
        {
            Tip = other.Tip;
            Id = other.Id;
        }
    }
}
