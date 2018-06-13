using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class Room : BaseModel
    {
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Libelle")]
        public string Label { get; set; }

        [Required]
        [Range(0, 30)]
        [Display(Name = "Capacité")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Tarif")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public int UserID { get; set; }
    }
}
