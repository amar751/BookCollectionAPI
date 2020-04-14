using BookCollectionMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookCollectionMain.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            IEnumerable<BooksModel> bookList;
            HttpResponseMessage response = BookCollectionClass.Client.GetAsync("Books").Result;
            bookList = response.Content.ReadAsAsync<IEnumerable<BooksModel>>().Result;
            return View(bookList);
        }
        [HttpGet]
        public ActionResult SaveUpdate(int id = 0)
        {
            if (id == 0)
                return View(new BooksModel());
            else
            {
                HttpResponseMessage response = BookCollectionClass.Client.GetAsync("Doctors/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<BooksModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult SaveUpdate(BooksModel booksModel)
        {
            if (booksModel.ID == 0)
            {
                HttpResponseMessage response = BookCollectionClass.Client.PostAsJsonAsync("Books", booksModel).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = BookCollectionClass.Client.PutAsJsonAsync("Books/" + booksModel.ID, booksModel).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = BookCollectionClass.Client.DeleteAsync("Books/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}