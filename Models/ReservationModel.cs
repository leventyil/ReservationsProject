using System.ComponentModel.DataAnnotations;

namespace ReservationProject.Models
{
    public class ReservationModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen bir işletme seçin.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "İsim boş bırakılamaz.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Lütfen bir tarih seçin.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Lütfen kişi sayısı girin.")]
        public int CustomerCount { get; set; }

        [Required(ErrorMessage = "Lütfen masa numarası girin.")]
        public int TableNo { get; set; }
    }
}
