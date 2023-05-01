using Microsoft.AspNetCore.Mvc;
using ThreeLayerArchitecture.ASP.Net.BAL;
using ThreeLayerArchitecture.ASP.Net.DAL;
using ThreeLayerArchitecture.ASP.Net.Models;

namespace ThreeLayerArchitecture.ASP.Net.Controllers
{
    public class UserController : Controller
    {

       private readonly IUserRePository userRePository;

        public UserController(IUserRePository _userRePository) 
        {
            this.userRePository = _userRePository;
        }
        public IActionResult Index()
        {

            var userVM=userRePository.GetAllUsers();
            return View(userVM);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            UserRegistrationViewModel UserVM=new UserRegistrationViewModel();

            UserVM.TermsConditions = false;

          
            ViewBag.GenderList = userRePository.GetAllGenders();
            ViewBag.CategoryList = userRePository.GetAllCategories();
            return View("UserRegistration", UserVM);
        }
        [HttpPost]
        public IActionResult Registration(UserRegistrationViewModel userVM)
        {

            



            if(userVM.TermsConditions == false)
            {
                ModelState.AddModelError("TermsConditions", "please accpt terms and conditions " );
            }
            if (userVM.Category == null)
            {
                ModelState.AddModelError("TermsConditions", "please accpt Category ");
            }

            if (ModelState.IsValid== true)
            {
                userRePository.CreateNewUser(userVM);
            }


            
            ViewBag.GenderList = userRePository.GetAllGenders();
            ViewBag.CategoryList = userRePository.GetAllCategories();
            return View("UserRegistration", userVM);
        }

        public IActionResult IsEmailIdValid(string EmailId)
        {
            MvcfirstContext db = new MvcfirstContext();
            var isEmailIdPresentInDB = db.Users.Any(u => u.EmailId == EmailId);
            if (isEmailIdPresentInDB == true)
            {
                return Json("the Email id is present in the databse please choose another email id");
            }
            else
            {
                return Json(true);
            }


        }
        [HttpGet]
        public IActionResult Delete( int Id)
        {

          
            userRePository.DeleteUser(Id);
            return RedirectToAction("Index");



        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var userVM=userRePository.GetSingleUser(Id);

            ViewBag.GenderList = userRePository.GetAllGenders();
            ViewBag.CategoryList = userRePository.GetAllCategories();
            return View(userVM);
        }
        [HttpPost]
        public IActionResult Update(UserUpdateViewModel userUVM)
        {
            if (ModelState.IsValid == true)
            {
                userRePository.UpdateUser(userUVM);
                return RedirectToAction("Index");
            }


            ViewBag.GenderList = userRePository.GetAllGenders();
            ViewBag.CategoryList = userRePository.GetAllCategories();
            return View(userUVM);
        }

    }
}
