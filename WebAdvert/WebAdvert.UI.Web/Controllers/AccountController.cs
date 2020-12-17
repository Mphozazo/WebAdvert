using System.Threading.Tasks;
using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAdvert.UI.Web.Models;

namespace WebAdvert.UI.Web.Controllers
{
    public class Account : Controller
    {
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;

        public Account(SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager,
            CognitoUserPool pool)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _pool = pool;
        }

        public  async Task<IActionResult> SignUp()
        {
            var model = new SignUpModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model )
        {
            if (!ModelState.IsValid) return View();

            var user = _pool.GetUser(model.Email);
            // user exists
            if (user.Status != null)
            {
                ModelState.AddModelError("UserExists", "There's user already exists with email address.");
                return View(model);
            }
            // attributes setup 
            user.Attributes.Add(CognitoAttribute.Name.AttributeName ,model.Email);
            user.Attributes.Add(CognitoAttribute.Gender.AttributeName, model.Gender.ToString());
            user.Attributes.Add(CognitoAttribute.PhoneNumber.AttributeName, model.PhoneNumber);
            // create user profile 
            var createdUser = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);

            if (createdUser.Succeeded)
            {
                RedirectToAction("Confirmation");
            }
            return View();
        }
    }
}