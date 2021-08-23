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

        [Required(ErrorMessage = "ใส่ข้อมูลหมวดหมู่สินค้า")]
        [Display(Name = "หมวดหมู่สินค้า")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "ใส่ข้อมูลลำดับหมวดหมู่สินค้า")]
        [Display(Name = "ลำดับหมวดหมู่สินค้า")]
        [Range(1,int.MaxValue,ErrorMessage = "ลำดับที่ใส่ได้คือ 1 ขึ้นไป (ดูลำดับหมวดหมู่สินค้า กดปุ่ม Back)")]
        public int DisplayOrder { get; set; }
    }
}
