using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTTNgoaiNgu.Data;

namespace QuanLyTTNgoaiNgu.Controllers
{
    public class TAIKHOANsController : Controller
    {
        private readonly QuanLyTTNgoaiNguContext _context;

        public TAIKHOANsController(QuanLyTTNgoaiNguContext context)
        {
            _context = context;
        }
        {
        }

        {
            {
            }

            {


        }

        {
            }
            return View(tAIKHOAN);
        }

        {
            }

            {
        }

        // POST: TAIKHOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
                    {


            {
            }


            {
            }

        }

    }
}
