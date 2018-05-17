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
            ViewData["Message"] = "Your application description page.";
            string path = Path.Combine(Environment.CurrentDirectory, @"docs\");
            var files = Directory.GetFiles(path).ToList();
            var ble = "";
            if (files.Any()) { 
            foreach (var file in files)
            {
                ble = ble + "-----" + file;
            } }
            //ViewData["Files"] = ble;
            var model = new Files { Stuff = path };
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
