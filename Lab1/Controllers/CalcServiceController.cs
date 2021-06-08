using System;
using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;
namespace Lab1.Controllers {
    public class CalcServiceController : Controller {
        private Random _random = new Random();
        private readonly IServiceInjection serviceInjection;
        private int _x;
        private int _y;
        private string _sum;
        private string _dif;
        private string _mult;
        private string _div;
        public CalcServiceController(IServiceInjection _service) {
            serviceInjection = _service;
            _x = _random.Next() % 11;
            _y = _random.Next() % 11;
            _sum = $"{_x} + {_y} = {_x + _y}";
            _dif = $"{_x} - {_y} = {_x - _y}";
            _mult = $"{_x} * {_y} = {_x * _y}";
            _div = _y != 0 ? $"{_x} /  {_y} = {_x / _y}" : "Division by zero";
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult PassUsingModel() {
            var model = new CalcModel(_x, _y, _sum, _dif, _mult, _div);
            return View(model);
        }

        public IActionResult PassUsingViewData() {
            ViewData["X"] = _x;
            ViewData["Y"] = _y;
            ViewData["Sum"] = _sum;
            ViewData["Dif"] = _dif;
            ViewData["Mult"] = _mult;
            ViewData["Div"] = _div;
            return View();
        }

        public IActionResult PassUsingViewBag() {
            ViewBag.X = _x;
            ViewBag.Y = _y;
            ViewBag.Sum = _sum;
            ViewBag.Dif = _dif;
            ViewBag.Mult = _mult;
            ViewBag.Div = _div;
            return View();
        }

        public IActionResult AccessServiceDirectly() {
            return View(serviceInjection.Calculate());
        }
    }
}
