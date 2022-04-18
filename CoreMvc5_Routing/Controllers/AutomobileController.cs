using CoreMvc5_Routing.Data;
using CoreMvc5_Routing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc5_Routing.Controllers
{
    public class AutomobileController : Controller
    {
        private readonly CarContext _ctx;

        public AutomobileController(CarContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var cars = await _ctx.Cars.OrderBy(x => x.Category).ToListAsync();
            return View(cars);
        }

        //與路由2「Car/Brand/{brand}」對應
        //以品牌找尋汽車
        public async Task<IActionResult> FindBrand(string brand)
        {
            List<Car> cars = null;
            if (string.IsNullOrEmpty(brand) || brand.Trim().ToUpper() == "ALL")
            {
                //找出所有品牌汽車
                cars = await (from c in _ctx.Cars
                              select c).ToListAsync();
                ViewData["Header"] = "所有品牌汽車";
            }
            else
            {
                //找出該品牌汽車
                cars = await (from c in _ctx.Cars
                              where c.Brand == brand
                              select c).ToListAsync();
                ViewData["Header"] = cars[0].Brand;
            }
            if (cars.Count == 0)
            {
                ViewData["ResultMessage"] = "找不到此品牌汽車";
                return View("Result");
                //return new StatusCodeResult(400);
                //return new StatusCodeResult((int)HttpStatusCode.Ambiguous);
            }
            return View(cars);
        }

        //與路由3「Car/Category/{cat}」對應
        //以分類查詢汽車
        public async Task<ActionResult> FindCategory(string cat)
        {
            cat = cat.Trim();
            if (string.IsNullOrEmpty(cat))
            {
                ViewData["ResultMessage"] = "請提供汽車分類名稱!";
                return View("Result");
            }
            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              where c.Category == cat
                              select c).ToListAsync();
            if (cars.Count == 0)
            {
                ViewData["ResultMessage"] = "找不到此類型的車!";
                return View("Result");
            }
            return View(cars);
        }

        public async Task<IActionResult> FindId(int? Id)
        {
            if (Id == null)
            {
                ViewData["ResultMessage"] = "請提供汽車Id!";
                return View("Result");
            }
            Car car = await _ctx.Cars.FindAsync(Id);
            if (car == null)
            {
                ViewData["ResultMessage"] = "查無此Id編號汽車!";
                return View("Result");
            }
            return View(car);
        }

        //與路由5「Car/Year/{year}」對應
        //以年份找尋汽車
        public async Task<ActionResult> FindYear(int? year)
        {
            if (year == null)
            {
                ViewData["ResultMessage"] = "找車請提供年份!";
                return View("Result");
            }
            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              where c.Year == year
                              orderby c.Brand
                              select c).ToListAsync();
            if (cars.Count == 0)
            {
                //return NotFound("Can not find any car of this year.");
                ViewData["ResultMessage"] = "找不到這年份的車!";
                return View("Result");
            }
            return View(cars);
        }

        //與路由6「Car/Brand-Year/{brand}-{year}」對應
        //以品牌及年份的組合找尋汽車
        public async Task<IActionResult> FindBrandYear(string brand, int year)
        {
            List<Car> cars = await (from c in _ctx.Cars
                                    where c.Brand == brand && c.Year == year
                                    select c).ToListAsync();
            if (cars.Count == 0)
            {
                ViewData["ResultMessage"] = "找不到此Brand-Year汽車";
                return View("Result");
            }
            ViewData["Header"] = brand;
            return View(cars);
        }

        //與路由7「Car/TopSales/{topnumber}」對應
        //查詢銷售前幾名汽車
        public async Task<IActionResult> TopSales(int topnumber)
        {
            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              orderby c.SoldNumber descending
                              select c).Take(topnumber).ToListAsync();
            if (cars.Count == 0)
            {
                ViewData["ResultMessage"] = "找不到Top Sales數據!";
                return View("Result");
            }
            ViewData["TopSales"] = topnumber;
            return View(cars);
        }

        //與路由8「Car/Price/{min}-{max}}」對應
        //查詢銷售前幾名汽車
        public async Task<IActionResult> Price(decimal min,decimal max )
        {
            //找出所有該類型汽車
            var cars = await _ctx.Cars.Where(c => c.Price >= min && c.Price <= max).OrderBy(c=>c.Price).ToListAsync();


            if (max < min)
            {
                cars = await _ctx.Cars.Where(c => c.Price <= min && c.Price >= max).OrderBy(c => c.Price).ToListAsync();
            }

            if (cars.Count == 0)
            {
                ViewData["ResultMessage"] = "找不到此價格區間數據!";
                return View("Result");
            }

            return View(cars);
        }
    }
}
