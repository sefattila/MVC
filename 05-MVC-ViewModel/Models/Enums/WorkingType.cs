using System.ComponentModel.DataAnnotations;

namespace _05_MVC_ViewModel.Models.Enums
{
    public enum WorkingType
    {
        [Display(Name ="Tam Zamanlı")]
        FullTime=1,
        [Display(Name = "Yarı Zamanlı")]
        PartTime,
        [Display(Name = "Proje Bazlı")]
        ProjectBased,
        [Display(Name = "Serbest Zamanlı")]
        Freelance
    }
}
