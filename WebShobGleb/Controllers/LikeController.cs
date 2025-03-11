using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Const;
using WebShobGleb.Mappers;
using WebShobGleb.Servises;

namespace WebShobGleb.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }
        public IActionResult Index()
        {
            var likeProducts = _likeService.GetUserLikeProducts(Constants.UserId);
            return View(likeProducts);
        }
        public IActionResult Add(int Id)
        {
            _likeService.AddLike(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _likeService.DeleteLike(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
