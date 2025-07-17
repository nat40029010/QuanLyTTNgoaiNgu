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

        [ForeignKey("KHOAHOC")]
        [Required]
        public int MaKhoaHoc {  get; set; }
        public ICollection<PHIEUDANGKY>? PHIEUDANGKYs { get; set; }
        public virtual GIANGVIEN? GIANGVIEN { get; set; }

        public virtual KHOAHOC? KHOAHOC { get; set; }
        public virtual ICollection<KETQUAHOCTAP>? KETQUAHOCTAPs{ get; set; }

    }
}
