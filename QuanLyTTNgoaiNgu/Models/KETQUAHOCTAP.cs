using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTTNgoaiNgu.Models
{
    public class KETQUAHOCTAP
    {
        [Key]
        public int MaKetQua {  get; set; }

        [Required]
        public float Diem {  get; set; }

        [Required]
        public float ChuyenCan {  get; set; }

        [Required]
        [ForeignKey("HOCVIEN")]
        public int MaHocVien { get; set; }
        [Required]
        [ForeignKey("LOPHOC")]
        public int MaLopHoc { get; set; }

    }
}
