using App.Back.Domain.State.Komentari.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Domain
{
    public class Komentar
    {
        int Id { get; set; }
        public StanjeKomentara Stanje { get; set; }
        public bool OdustaoOdPisanja { get; set; }
        public bool PodRazmatranjem { get; set; }
        public bool OdobrioKomentar { get; set; }
    }
}
