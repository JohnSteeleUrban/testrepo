using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnettest.Models;
using System.IO;
using System.Reflection;

namespace dotnettest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
             var ble = "";
            ViewData["Message"] = "Your application description page.";
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"docs/");
                //var path = Environment.CurrentDirectory;
                var dir = Directory.GetDirectories(path);
                var files = Directory.GetFiles(path).ToList();
                if (files.Any())
                {
                    foreach (var file in files)
                    {
                        ble = ble + "-----" + file;
                    }
                }
                ble = ble + "======================DIRECTORIES";

            }
           
            catch (Exception e)
            {
                ble = e.ToString();
            }
            var model = new Files { Stuff = ble };
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
