using System.ComponentModel.DataAnnotations;

namespace QuanLyTTNgoaiNgu.Models
{
    public class TAIKHOAN
    {
        [Key]
        public int MaTaiKhoan { get; set; }

        [Required]
        [StringLength(20)]
        public string TenDangNhap{ get; set; }
        [Required]
        [StringLength(10)]
        public string MatKhau { get; set; }
     
        [Required]
        [StringLength(20)]
        public string VaiTro { get; set; }

 
    }
}
