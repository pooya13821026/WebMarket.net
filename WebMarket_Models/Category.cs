using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarket_Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "پر کردن این فیلد اجباریست")]
        [DisplayName("عنوان دسته")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ترتیب نمایش را مشخص کنید")]
        [DisplayName("ترتیب نمایش")]
        [Range(1, 100, ErrorMessage = "ترتیب نمایش باید بین 1 تا 100 باشد")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
