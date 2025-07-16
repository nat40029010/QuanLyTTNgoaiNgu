using System.ComponentModel.DataAnnotations;

namespace QuanLyTTNgoaiNgu.Models
{
    public class KHOAHOC
    {
        [Key]
        public int MaKhoaHoc { get; set; }

        [Required]
        [StringLength(20)]
        public string TenKhoaHoc { get; set; }
        [Required]
        public double MucHocPhi {  get; set; }
        [Required]
        [StringLength(50)]
        public string MoTa {  get; set; }

        public virtual ICollection<LOPHOC> ? LOPHOCs { get; set; }  
    }
}
