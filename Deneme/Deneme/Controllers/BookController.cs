using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deneme.Data;
using Deneme.Models;
using Elfie.Serialization;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Deneme.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration configuration;
        private IConfiguration? _configuration;

        public BookController(IConfiguration _configuration)
        {
            this._configuration = configuration;
        }

        // GET: Book
        public IActionResult Index()
        {
              return View();
                          
        }               
        // GET: Book/AddOrEdit/5
        public IActionResult AddOrEdit(int? id)
        {
            BookViewModel bookViewModel = new BookViewModel();
            return View(bookViewModel);
        }

        // POST: Book/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("KitapId,Baslik,Yazar,Fiyat")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("BookAddOrEdit", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("KitapId", bookViewModel.KitapId);
                    sqlCmd.Parameters.AddWithValue("Başlık", bookViewModel.Baslik);
                    sqlCmd.Parameters.AddWithValue("Yazar", bookViewModel.Yazar);
                    sqlCmd.Parameters.AddWithValue("Fiyat", bookViewModel.Fiyat);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
