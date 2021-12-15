using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Anh105.Models
{
    [Table ("TA105s")]
    public class TA105
    {
        [Key]
        [Display(Name = "Mã sinh viên")]
        [StringLength(20)]
        public string TAid { get; set; }
        [Display(Name = "Tên sinh viên ")]
        [StringLength(50)]
        public string TAName {get; set;}

       [Display(Name = "Phân biệt ")]
        [Required]
        public string TAGener {get; set;}
    }
}