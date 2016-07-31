using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TTF.Data;
using TTF.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace TTF.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var quip = new Quip();
            quip.Name = "Testing!";

            var quips = new List<Quip>();

            // quips.Add(new Quip{
            //     Url = "",
            //     Name = "",
            //     Title = "",
            //     Image = "",
            //     Video= "",
            //     User
            // });

            _context.Quips.Add(quip);
            _context.SaveChanges();

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public String Test()
        {
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync("https://quipvid.com/api/quips").Result;

            var quips = JsonConvert.DeserializeObject<List<Quip>>(json);
            _context.Quips.AddRange(quips);
            _context.SaveChanges();

            var hey = "123";

            return hey;
        }
    }
}
