using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_111.Models
{
    public partial class Kostumer
    {
        public Kostumer()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdCostumer { get; set; }

        [Required(ErrorMessage = "Nama Customer tidak boleh kosong" )]
        public string NamaCostumer { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "nik hanya boleh diisi dengan angka")]
        public string Nik { get; set; }

        [Required(ErrorMessage = "Alamat wajib diisi")]
        public string Alamat { get; set; }

        [MinLength(10, ErrorMessage = "No HP minimal 10 angka")]
        [MaxLength(13, ErrorMessage = "No HP maksimal 13 angka")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "no Hp hanya boleh diisi dengan angka")]
        [Required(ErrorMessage = "No Hp wajib diisi")]
        public string NoHp { get; set; }

        public int? IdGender { get; set; }

        public Gender IdGenderNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
