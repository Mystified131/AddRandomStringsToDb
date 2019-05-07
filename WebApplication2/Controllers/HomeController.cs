using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public static int editID;
        public static string editelement;
        static public string Searchstr;

        public IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Result()
        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (TheList.Count > 0)
            {
                ResultViewModel resultViewModel = new ResultViewModel();

                resultViewModel.TheList = TheList;

                return View(resultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            List<Listelement> TheList = context.Listelements.ToList();

            if (ModelState.IsValid)
            {
                if (resultViewModel.quant == 0)
                {
                    Random random = new Random();
                    resultViewModel.quant = random.Next(0, 100);

                }

                if (resultViewModel.leng == 0)
                {
                    Random random = new Random();
                    resultViewModel.leng = random.Next(1, 20);

                }

                RandomValue qbert = new RandomValue("qbert");

                resultViewModel.RandomKeys = qbert.RandomKeys(resultViewModel.quant, resultViewModel.leng); 

                foreach (string itm in resultViewModel.RandomKeys) {

                    Listelement newel = new Listelement(itm);

                    TheList.Add(newel);
                    context.Listelements.Add(newel);
                    context.SaveChanges();

                    resultViewModel.TheList = TheList;

                }

                return View(resultViewModel);
            }

            return Redirect("/Home/Error");

        }

        public IActionResult Delete()
        {

            List<Listelement> TheList = context.Listelements.ToList();

            foreach (Listelement itm in TheList)
            {
                context.Listelements.Remove(itm);
                context.SaveChanges();
            }


        
            return Redirect("/");
        }
    }

}

        
