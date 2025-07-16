using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyTTNgoaiNgu.Models
{
    public class LOPHOC
    {
        [Key]
        public int MaLopHoc { get; set; }

        [Required]
        [StringLength(20)]
        public string TenLop { get; set; }

        [Required]
        public DateTime LichHoc { get; set; }

        [ForeignKey("GIANGVIEN")]
        [Required]
        public int MaGiangVien { get; set; }
        public ICollection<PHIEUDANGKY>? PHIEUDANGKYs { get; set; }
        public virtual GIANGVIEN? GIANGVIENs { get; set; }

        public virtual KHOAHOC? KHOAHOCs { get; set; }
      
    }
}
