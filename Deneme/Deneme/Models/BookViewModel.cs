using System.ComponentModel.DataAnnotations;

namespace Deneme.Models
{
    public class BookViewModel
    {
        [Key]
        public int KitapId { get; set; }
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Yazar { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = "Birden büyük veya eşit olmak zorunda")]
        public int Fiyat { get; set; }
    }
}
