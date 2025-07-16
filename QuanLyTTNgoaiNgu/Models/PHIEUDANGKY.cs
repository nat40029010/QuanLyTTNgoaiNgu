using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTTNgoaiNgu.Models
{
    public class PHIEUDANGKY
    {
        [Key]
        public int MaDangKy {  get; set; }

        [Required]
        public DateTime NgayDangKy { get; set; }

        [Required]
        [ForeignKey("HOCVIEN")]
        public int MaHocVien {  get; set; }

        [Required]
        [ForeignKey("LOPHOC")]
        public int MaLopHoc {  get; set; }
        public virtual LOPHOC ? LOPHOCs {  get; set; }
    }
}
