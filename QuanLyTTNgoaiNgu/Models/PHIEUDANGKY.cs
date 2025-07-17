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
        public virtual LOPHOC ? LOPHOC {  get; set; }
        public virtual HOCVIEN? HOCVIEN { get; set; }
        public virtual HOCPHI? HOCPHI { get; set; }
    }
}
