using _15_MVC_Role.Models;
using _15_MVC_Role.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _15_MVC_Role.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.Select(u => new UserListVM
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
            }).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
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
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else if (result.IsLockedOut)
                {

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Hatalı Giriş");
                }
            }
            else
            {
                ModelState.AddModelError("Kullanıcı Bulunamadı", "Hatalı Giriş");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(IdentityRole model)
        {
            var role = new IdentityRole();
            role.Name = model.Name;
            var result = await _roleManager.CreateAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles.Select(x => new IdentityRole
            {
                Id = x.Id,
                Name = x.Name,
            });

            return View(roles);
        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityRole model = new IdentityRole();
                model.Id = role.Id;
                model.Name = role.Name;

                return View(model);
            }
            else return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(IdentityRole model)
        {
            var role= await _roleManager.FindByIdAsync(model.Id);

            if(role.Name!=model.Name)
                role.Name=model.Name;

            IdentityResult result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result=await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> AddRole(string id)
        {
            UserRoleVM roleVM = new UserRoleVM();
            roleVM.Id = id;
            roleVM.Roles = await _roleManager.Roles.ToListAsync();

            return View(roleVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserRoleVM model)
        {
            AppUser user = await _userManager.FindByIdAsync(model.Id);
            var result = await _userManager.AddToRoleAsync(user, model.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
