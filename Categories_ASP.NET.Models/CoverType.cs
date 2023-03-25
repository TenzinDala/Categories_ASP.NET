using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories_ASP.NET.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Cover Type")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
