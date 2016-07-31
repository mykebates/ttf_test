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
    public class QuipsController : Controller
    {
        ApplicationDbContext _context;

        public QuipsController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var quips = _context.Quips.ToList();
            return View(quips);
        }
    }
}
