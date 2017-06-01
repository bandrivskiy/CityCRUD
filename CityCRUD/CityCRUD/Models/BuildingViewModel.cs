using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityCRUD.Models
{
    public class BuildingViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        [Required]
        public bool Allow { get; set; }
    }
}