using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_111.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Kostumer = new HashSet<Kostumer>();
        }

        public int IdGender { get; set; }

        [Required(ErrorMessage = "Nama Gender wajib diisi")]
        public string NamaGender { get; set; }

        public ICollection<Kostumer> Kostumer { get; set; }
    }
}
