using System;
using System.Collections.Generic;

namespace RentalKendaraan_111.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Kostumer = new HashSet<Kostumer>();
        }

        public int IdGender { get; set; }
        public string NamaGender { get; set; }

        public ICollection<Kostumer> Kostumer { get; set; }
    }
}
