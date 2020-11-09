using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalKendaraan_111.Models
{
    public partial class Kendaraan
    {
        public Kendaraan()
        {
            Peminjaman = new HashSet<Peminjaman>();
        }

        public int IdKendaraan { get; set; }

        [Required(ErrorMessage = "Nama Kendaraan wajib diisi")]
        public string NamaKendaraan { get; set; }

        [Required(ErrorMessage = "No Polisi wajib diisi")]
        public string NoPolisi { get; set; }

        [Required(ErrorMessage = "No STNK wajib diisi")]
        public string NoStnk { get; set; }


        public int? IdJenisKendaraan { get; set; }


        public string Ketersediaan { get; set; }

        public JenisKendaraan IdJenisKendaraanNavigation { get; set; }
        public ICollection<Peminjaman> Peminjaman { get; set; }
    }
}
