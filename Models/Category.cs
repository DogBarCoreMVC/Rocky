using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Category
    {
        [Key]//Primary key
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
