using Microsoft.AspNetCore.Mvc;
using OnlineShopDB;

namespace WebShobGleb.Controllers
{
    public class ImageController : Controller
    {
        private readonly DataBaseContext _databaseContext;
        public ImageController(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult GetImage(Guid id)
        {
            var image = _databaseContext.Images.FirstOrDefault(i => i.ProductId == id);
            if (image == null)
            {
                return NotFound();
            }

            return File(image.Data, image.ContentType);
        }
    }
}
