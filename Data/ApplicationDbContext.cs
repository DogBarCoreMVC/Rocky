using Microsoft.EntityFrameworkCore;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {//Create Constructor และเรียกใช้ความสามารถของ SuperClass DbContextOptions เพื่อส่ง Class ApplicationDbContext ให้เรียกใช้งานได้ // base คือการบอกให้โปรแกรมกลับไปทำงานที่ (options)

        }

        public DbSet<Category> CategoryTbl { get; set; }
        //Create Properties ตามด้วย Class Category ที่เราสร้างไว้และกำหนดข้อมูลให้แล้ว CategoryTbl จะใช้เป็นชื่อ table
    }
}
