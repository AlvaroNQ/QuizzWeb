﻿using Microsoft.AspNetCore.Mvc;
using QuizzWeb.Models;
using System.Diagnostics;

namespace QuizWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new TextFile();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SaveQuiz() {
            return View();
        }
        public IActionResult SearchQuiz()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}