using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTTNgoaiNgu.Models
{
    public class HOCVIEN
    {
        [Key]
        public int MaHocVien { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }
        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string DiaChi { get; set; }

        [ForeignKey("TAIKHOAN")]
        [Required]
        public int MaTaiKhoan { get; set; }

        public virtual ICollection<PHIEUDANGKY>? PHIEUDANGKYs { get; set; }
        public virtual ICollection<KETQUAHOCTAP>? KETQUAHOCTAPs { get; set; }
    }
}
