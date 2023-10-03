using _14_MVC_Identity.Models;
using _14_MVC_Identity.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _14_MVC_Identity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.Select(u => new UserListVM
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
            }).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };

                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null)
            {
                UserEditVM model = new UserEditVM();
                model.Id = model.Id;
                model.UserName = appUser.UserName;
                model.FirstName = appUser.FirstName;
                model.LastName = appUser.LastName;
                model.Email = appUser.Email;
                model.Phone = appUser.PhoneNumber;

                return View(model);
            }
            else
                return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser= await _userManager.FindByIdAsync(model.Id);

                //berlili alanlara güncelleme yapacaksak

                if (appUser.UserName!= model.UserName)  
                    appUser.UserName = model.UserName;
                if (appUser.FirstName != model.FirstName)
                    appUser.FirstName = model.FirstName;
                if (appUser.LastName != model.LastName)
                    appUser.LastName = model.LastName;
                if (appUser.Email != model.Email)
                    appUser.Email = model.Email;
                if (appUser.PhoneNumber != model.Phone)
                    appUser.PhoneNumber = model.Phone;

                IdentityResult result =await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                    return BadRequest();

            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            IdentityResult result = await _userManager.DeleteAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    //kullanıcı hesabı kitlendi
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Hatalı Giriş");
                }
            }
            else
            {
                ModelState.AddModelError("Kullanıcı Bulunamadı", "Lütfen Kayıt Olunuz");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
