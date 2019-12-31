using Asteck.SurveyPlus.Models;
using Asteck.SurveyPlus.Service;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using static Asteck.SurveyPlus.Models.AccountViewModel;

namespace Asteck.SurveyPlus.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user  
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                        new
                        {
                            model.EmailId,
                            model.Address,
                            model.MobileNo                          
                        }
                    );
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            // If we got this far, something failed, redisplay form  
            return View(model);
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = WebSecurity.Login(model.Email, model.Password, persistCookie: model.RememberMe);

            if(result)
            {
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Invalid code.");
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}