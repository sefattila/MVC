using _05_MVC_ViewModel.Models.Enums;

namespace _05_MVC_ViewModel.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BithDate { get; set; }
        public Department Department { get; set; }
        public WorkingType WorkingType { get; set; }
    }
}
