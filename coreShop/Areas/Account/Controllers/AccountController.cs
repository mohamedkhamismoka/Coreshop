using coreShop.BL.interfaces;
using coreShop.BL.VM;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace coreShop.Areas.Account.Controllers
{[Area("Account")]
    public class AccountController : Controller
    {
        //using microsoft identity to achieve security 
        // private to be hidden
        //readonly to assign in constructor to achieve DI
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signmanager;
        private readonly ILogger<AccountController> logger;
        private readonly ICart cart;


        //for dependency injection
        public AccountController(UserManager<ApplicationUser> userman, SignInManager<ApplicationUser> signman, ILogger<AccountController> logger, ICart cart)
        {
            this.usermanager = userman;
            this.signmanager = signman;
            this.logger = logger;
            this.cart = cart;
        }
        //register actions
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationVM reg)

        {
            if (ModelState.IsValid)
            {     int cart_id=cart.create(); 
                var user = new ApplicationUser();
                user.Email = reg.mail;
                user.UserName = reg.mail;
                user.address = reg.address;
                user.cart_id= cart_id;
                user.isActive = true;
                var res = await usermanager.CreateAsync(user, reg.password);
                if (res.Succeeded)
                {

                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(reg);
        }


        //****************************************************************************

        //login actions
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM log)
        {
            if (ModelState.IsValid)
            {
                var result = await signmanager.PasswordSignInAsync(log.mail, log.password, false, false);

                if (result.Succeeded)
                { ApplicationUser USER = await usermanager.FindByEmailAsync(log.mail);
                    var cartid=USER.cart_id;
                    return RedirectToAction("Index", "Client", new { area = "Client" ,id=cartid});
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password Attempt");

                }


            }

            return View(log);




        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginVM log)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await usermanager.FindByEmailAsync(log.mail);
                var result = await signmanager.PasswordSignInAsync(log.mail, log.password, log.RememberMe, false);

                if (result.Succeeded && user != null && (await usermanager.IsInRoleAsync(user, "Admin") || await usermanager.IsInRoleAsync(user, "SuperAdmin")))

                {

                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password Attempt");

                }


            }

            return View(log);


        }
        [HttpGet]
        public IActionResult Logout(){
            signmanager.SignOutAsync();
            return RedirectToAction("Login");

            }
    }
}
