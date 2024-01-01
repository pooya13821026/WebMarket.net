using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarket_Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="عنوان اجباریست")]
        [DisplayName("عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "توضیحات اجباریست")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "شابک اجباریست")]
        [DisplayName("شابک")]
        [MaxLength(20)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "نام نویسنده اجباریست")]
        [DisplayName("نام نویسنده")]
        [MaxLength(100)]
        public string Auther { get; set; }

        [Required(ErrorMessage = "لیست قیمت ها اجباریست")]
        [DisplayName("لیست قیمت ها")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "قیمت اجباریست")]
        [DisplayName("قیمت")]
        public double Price { get; set; }

        [Required(ErrorMessage = "قیمت 50 عدد اجباریست")]
        [DisplayName("قیمت 50 عدد")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "قیمت 100 عدد اجباریست")]
        [DisplayName("قیمت 100")]
        public double Price100 { get; set; }

        [DisplayName("عکس")]
        public string Img { get; set; }

        [Required(ErrorMessage = "دسته اجباریست")]
        [DisplayName("دسته")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
