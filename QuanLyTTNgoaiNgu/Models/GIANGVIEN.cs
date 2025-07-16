using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyTTNgoaiNgu.Models
{
    public class GIANGVIEN
    {

        [Key]
        public int MaGiangVien { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }
        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(10)]
        public string ChuyenMon { get; set; }
        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [ForeignKey("TAIKHOAN")]
        [Required]
        public int MaTaiKhoan { get; set; }
      

        public virtual ICollection<LOPHOC>?LOPHOCs { get; set; }


    }
}
