using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Anh105.Models
{
    [Table ("Persons")]
    public class PersonsAnh
    {
        [Key]
        [Display(Name = "Mã khách hàng")]
        public string PersonID { get; set; }
        [Display(Name = "Tên Khách hàng")]
        public string PersonName {get; set;}

    }
}