using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTTNgoaiNgu.Models
{
    public class QUANTRIVIEN
    {
        [Key]
        public int MaQuanTriVien {  get; set; }

        [Required]
        [StringLength(20)]
        public string TenQuanTriVien { get; set; }

        [ForeignKey("TAIKHOAN")]
        [Required]
        public int MaTaiKhoan {  get; set; }

         public virtual TAIKHOAN? TAIKHOANS { get; set; }
    }
}
