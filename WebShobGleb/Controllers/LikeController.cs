using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Const;
using WebShobGleb.Repository;

namespace WebShobGleb.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        public IActionResult Index()
        {
            var likeProducts = _likeRepository.TryGetByUserId(Constants.UserId);
            return View(likeProducts);
        }
        public IActionResult Add(int Id)
        {
            _likeRepository.Add(Id, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
