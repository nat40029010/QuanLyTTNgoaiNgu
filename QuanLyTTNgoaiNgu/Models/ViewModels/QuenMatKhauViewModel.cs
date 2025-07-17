using System.ComponentModel.DataAnnotations;

namespace QuanLyTTNgoaiNgu.Models.ViewModels
{
    public class QuenMatKhauViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email đã đăng ký")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        public string Email { get; set; }

        public string? MatKhauHienThi { get; set; }
    }
}
