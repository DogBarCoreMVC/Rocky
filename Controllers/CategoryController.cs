using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;//Dependency Injection / readonly เป็น properties

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;//Object db รับค่าข้อมูลมาจาก Class ApplicationDbContext ที่อยู่ใน Method ConfiguretionServices แล้วนำข้อมูลมาเก็บไว้ใน _db
        }

        public IActionResult Index()
        {
            IEnumerable<Category> ObjList = _db.CategoryTbl;//เอาข้อมูลที่ได้จาก CategoryTbl ไปเก็บไว้ที่ ObjList
            return View(ObjList);//แสดงข้อมูลใน ObjList
        }
    }
}
