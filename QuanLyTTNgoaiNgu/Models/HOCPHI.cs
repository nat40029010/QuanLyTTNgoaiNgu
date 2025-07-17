using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTTNgoaiNgu.Models
{
    public class HOCPHI
    {
        [Key]
        public int MaHocPhi {  get; set; }

        [Required]
        [ForeignKey("PHIEUDANGKY")]
        public int MaDangKy {  get; set; }

        [Required]
        public DateTime NgayNop { get; set; }

        [Required]
        public bool TrangThai {  get; set; }

        public virtual PHIEUDANGKY? PHIEUDANGKY { get; set; }
    }
}
