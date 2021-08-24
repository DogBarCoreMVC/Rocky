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

        //GET - SELECT
        public IActionResult Index()//แสดงข้อมูลที่มีอยู่ใน DataBase
        {
            IEnumerable<Category> ObjList = _db.CategoryTbl;//เอาข้อมูลที่ได้จาก CategoryTbl ไปเก็บไว้ที่ ObjList
            return View(ObjList);//แสดงข้อมูลใน ObjList
        }

        //GET - INSERT
        public IActionResult Create()//ใส่ข้อมูลลง DataBase
        {
            return View();
        }

        //POST - INSERT
        [HttpPost] //กำหนด attribute เพื่อใช้ในการรับข้อมูล
        [ValidateAntiForgeryToken] //ความปลอดภัย
        public IActionResult Create(Category Obj)
        {
            if (ModelState.IsValid)//ตรวจสอบข้อมูลที่รับเข้ามาต้องครบถ้วย ถ้สไม่ครบจะไม่เข้าเงื่อนไข
            {
                _db.CategoryTbl.Add(Obj);//รับข้อมูลจาก Object Obj ด้วย Method Add
                _db.SaveChanges();//บันทึกลง DataBase
                return RedirectToAction("Index");//ทำการเปลี่ยนเส้นทางให้กลับไปที่ Method Index เพื่อทำการแสดงข้อมูล
            }
            return View(Obj);
        }

        
        public IActionResult Edit(int? id)//ค่าที่ int สามารถเป็นค่าว่างได้ ?
        {
            if(id == null || id == 0)//null คือค่าว่าง
            {
                return NotFound();//ฟ้อง error
            }
            var UseEnter = _db.CategoryTbl.Find(id);//ส่งค่า id ไปที่ UseEnter
            if(UseEnter == null)//null คือค่าว่าง
            {
                return NotFound();//ฟ้อง error
            }
            return View(UseEnter);
        }

        //Updata
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category CatEdit)
        {
            if (ModelState.IsValid)
            {
                _db.CategoryTbl.Update(CatEdit);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CatEdit);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var UseEnter = _db.CategoryTbl.Find(id);
            if(UseEnter == null)
            {
                return NotFound();
            }
            return View(UseEnter);
        }

        public IActionResult Deleted(int? id)
        {
            var UseEnter = _db.CategoryTbl.Find(id);
            if (ModelState.IsValid)
            {
                var UserEnter = _db.CategoryTbl.Find(id);
                _db.CategoryTbl.Remove(UserEnter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(UseEnter);
        }
    }
}
