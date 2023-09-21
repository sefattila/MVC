using System.ComponentModel.DataAnnotations;

namespace _03_MVC_Views.Models
{
    public class MessageSave
    {
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        [Display(Name ="Adınızı Giriniz")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadınızı Giriniz")]
        public string LastName { get; set; }
        [Display(Name = "Konuyu Giriniz")]
        public string Subject { get; set; }
        [Display(Name = "Mesajı Giriniz")]
        [DataType(DataType.MultilineText)]
        public string Konu { get; set; }
    }
}
