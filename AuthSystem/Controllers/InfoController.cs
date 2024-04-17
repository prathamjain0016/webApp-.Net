using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using AuthSystem.Models;
using AuthSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public InfoController(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //create
        [HttpGet]
        public IActionResult Index()
        {
            var userID = _userManager.GetUserId(HttpContext.User);
            var information = _context.Information.Where(i => i.UserId == userID).ToList();
            return View(information);
        }


        [HttpGet]
        public IActionResult Create()
        {
           
            return View(new InfoViewModel());
        }

        [HttpPost]
        public IActionResult Create(InfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userID = _userManager.GetUserId(HttpContext.User);
                var information = new info() {
                    Title = model.Title,
                    Url = model.Url,
                    UserId =  userID
                };
                
                _context.Information.Add(information);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Info");
            }

            return View(model);
        }

        //edit
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var userID = _userManager.GetUserId(HttpContext.User);
            var information = _context.Information.FirstOrDefault(n => n.id == Id);
            if(information.UserId==userID)
            {
                var model = new InfoViewModel()
                {
                    id = information.id,
                    Title=information.Title,
                    Url= information.Url,   
                    CreatedDate = information.CreatedDate,
                    UserId=userID
                };
                return View(model);
            }
            else
            {
                return Content("You are not authorized");
            }
           
        }

        [HttpPost]
        public IActionResult Edit(InfoViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var userID = _userManager.GetUserId(HttpContext.User);
                if (model.UserId == userID) 
                {
                    var information = new info
                    {
                        id=model.id,
                        Title=model.Title,
                        Url = model.Url,
                        CreatedDate=model.CreatedDate,
                        UserId = model.UserId
                    };
                    _context.Information.Update(information);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("You are not authorized");
                }
            }
            return View(model);
        }


        public IActionResult Delete(int Id) 
        {
            if(Id== 0)
            {
                return Content("Id is null invalid operation");
            }
            var userID = _userManager.GetUserId(HttpContext.User);
            var information = _context.Information.FirstOrDefault(n => n.id == Id);

            if(information.UserId == userID)
            {
                _context.Information.Remove(information);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return Content("You are not authorized");
        }

    }
}
