using System.Web.Mvc;
using Movies.Entities;
using Movies.Services;

namespace Movies.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly DatabaseContext _db = new DatabaseContext();

        [HttpGet]
        public ActionResult Index(string category)
        {
            var viewModel = ShoppingCartService.GetAllByCategory(_db, category);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, string selectedCategory)
        {
            return RedirectToAction("Index", new { category = selectedCategory });
        }
        
        [HttpGet]
        public ActionResult Add(int id)
        {
            ShoppingCartService.AddMovie(_db, id);

            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            ShoppingCartService.RemoveMovie(_db, id);

            return Redirect(Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
