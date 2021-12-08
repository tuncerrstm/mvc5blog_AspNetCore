﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> countries = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                     Text = "Bir Şehir Seçiniz.."
                 },
                new SelectListItem
                 {
                     Text = "Ankara",
                     Value = 1.ToString()
                 },
                new SelectListItem
                 {
                     Text = "İstanbul",
                     Value = 2.ToString()
                 },
                new SelectListItem
                 {
                     Text = "İzmir",
                     Value = 3.ToString()
                 },
                new SelectListItem
                 {
                     Text = "Edirne",
                     Value = 4.ToString()
                 },
                new SelectListItem
                 {
                     Text = "Bursa",
                     Value = 5.ToString()
                 },
                new SelectListItem
                 {
                     Text = "Tekirdağ",
                     Value = 6.ToString()
                 }
            }.ToList();
            ViewBag.item = countries;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            p.WriterStatus = true;
            p.WriterAbout = "Test Page";
            wm.WriterAdd(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
