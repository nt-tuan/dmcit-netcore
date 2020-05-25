using DMCIT.Core.Entities.Core;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Data;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.Accounts;
using DMCIT.Web.Configurations;
using DmcSupport.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ICoreRepository _icore;
        private readonly ApiConfiguration _configuration;

        public AccountController(SignInManager<AppUser> signinManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
            ICoreRepository icore, IOptions<ApiConfiguration> conf)
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _icore = icore;
            _configuration = conf.Value;
            //_logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> Signin(LoginModel user)
        {

            var appuser = await _userManager.FindByEmailAsync(user.Username);
            if (appuser == null)
            {
                appuser = await _userManager.FindByNameAsync(user.Username);
            }

            //If wrong user
            if (appuser == null)
            {
                return BadRequest();
            }
            var s = await _signinManager.PasswordSignInAsync(appuser, user.Password, user.Remember, lockoutOnFailure: false);
            if (s.IsNotAllowed)
            {
                return BadRequest(new
                {
                    message = "Tài khoản của bạn không được phép đăng nhập"
                });
            }
            if (s.IsLockedOut)
            {
                return BadRequest(new
                {
                    message = "Tài khoản của bạn đã bị khóa"
                });
            }
            if (!s.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Tên tài khoản hoặc mật khẩu không đúng"
                });
            }
            else
            {

                return new UserModel(appuser, (string)await GenerateJwtToken(user.Username, appuser));
            }
        }

        [AllowAnonymous]
        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            await _signinManager.SignOutAsync();
            return Ok(new { data = true });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<bool>> Register(RegisterEmployeeUserAnonymouseModel model)
        {
            var employee = await _icore.GetEmployeeByCode(model.employeeCode);
            var person = await _icore.GetPersonById(employee.PersonId);
            if (employee == null || person == null || person.Birthday.Value.Date != model.birthday.Date)
            {
                return BadRequest("INVALID EMPLOYEE INFORMATION");
            }

            var appuser = new AppUser
            {
                UserName = employee.Code.ToUpper(),
                EmployeeId = employee.GetId(),
                Email = model.email,
                PhoneNumber = model.phone
            };

            var r = await _userManager.CreateAsync(appuser, model.password);
            var mlist = new List<string>();
            if (!r.Succeeded)
            {
                var messages = r.Errors.Select(u => u.Description).ToArray();
                return BadRequest(messages);
            }
            else
            {
                return Ok(true);
            }
        }

        [HttpPost]
        [HttpPost]
        [Route("forceRegisterEmployee")]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeUserModel model)
        {
            var employee = await _icore.GetEmployeeById(model.employeeId);
            var appuser = new AppUser
            {
                UserName = employee.Code.ToUpper(),
                EmployeeId = employee.GetId(),
                Email = model.email,
                PhoneNumber = model.phone
            };
            var r = await _userManager.CreateAsync(appuser, model.password);
            var mlist = new List<string>();
            if (!r.Succeeded)
            {
                var messages = r.Errors.Select(u => u.Description).ToArray();
                return BadRequest(messages);
            }
            else
            {
                return Ok(true);
            }
        }


        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> AccountList(TableParameter<UserFilterModel, AppUser> model)
        {
            var eP = model.ToEntityParam();
            var accounts = await _icore.GetUserList(eP);
            var data = new List<UserModel>();
            var count = await _icore.GetUserCount(eP);
            foreach (var item in accounts)
            {
                var ditem = new UserModel(item)
                {
                    roles = await _userManager.GetRolesAsync(item)
                };
                data.Add(ditem);
            }

            return Ok(new BaseListModel<UserModel>(data, model.page, model.pageSize, count));
        }

        [HttpPost]
        [Route("details/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();
            return Ok(new ResponseModel(new UserModel(user)));
        }

        [HttpPost("lock/{id}")]
        public async Task<ActionResult<bool>> LockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            var rs = await _userManager.SetLockoutEnabledAsync(user, true);
            user = await _userManager.FindByIdAsync(id);
            var rs1 = await _userManager.SetLockoutEndDateAsync(user, new DateTime(2100, 1, 1));
            if (rs.Succeeded && rs1.Succeeded)
                return true;
            return BadRequest(rs.Errors.Concat(rs1.Errors).Select(u => $"{u.Code}: {u.Description}"));
        }

        [HttpPost("unlock/{id}")]
        public async Task<ActionResult<bool>> UnlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var rs = await _userManager.SetLockoutEnabledAsync(user, true);
            user = await _userManager.FindByIdAsync(id);
            var rs1 = await _userManager.SetLockoutEndDateAsync(user, new DateTime(1900, 1, 1));
            if (rs.Succeeded && rs1.Succeeded)
                return true;
            return BadRequest(rs.Errors.Concat(rs1.Errors).Select(u => $"{u.Code}: {u.Description}"));
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> Update(UpdateUserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.id);
            if (user == null) return NotFound();
            user.EmployeeId = model.employeeId;
            await _userManager.UpdateAsync(user);
            var aroles = await _userManager.GetRolesAsync(user);
            user = await _userManager.FindByIdAsync(model.id);
            await _userManager.RemoveFromRolesAsync(user, aroles);

            user = await _userManager.FindByIdAsync(model.id);
            if (model.roles != null)
                await _userManager.AddToRolesAsync(user, model.roles);

            return true;
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<ActionResult<bool>> ChangePassword(RegisterModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            var rs = await _userManager.ChangePasswordAsync(user, model.password, model.newPassword);
            if (rs.Succeeded)
                return true;
            else
                return BadRequest(rs.Errors.Select(u => $"{u.Code}: {u.Description}"));
        }

        [HttpPost]
        [Route("reset/{id}")]
        public async Task<ActionResult<string>> ResetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return NotFound();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var password = GenerateRandomPassword(_userManager.Options.Password);
            var result = await _userManager.ResetPasswordAsync(user, token, password);

            if (result.Succeeded)
                return password;
            else
                return BadRequest(result.Errors.Select(u => new { code = $"{u.Code}: {u.Description}" }));
        }

        [HttpPost]
        [Route("roles/{id}")]
        public async Task<ActionResult<List<RoleModel>>> Roles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return BadRequest();

            var roleNames = await _userManager.GetRolesAsync(user);
            var roles = await GetRoleEntities(roleNames);

            return roles.Select(u => new RoleModel(u)).ToList();
        }

        [HttpPost]
        [Route("allroles")]
        public async Task<ActionResult<List<RoleModel>>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles.Select(u => new RoleModel(u)).ToList();
        }

        [HttpPost]
        [Route("myroles")]
        public async Task<ActionResult<List<RoleModel>>> GetMyRoles()
        {
            var user = await _userManager.GetUserAsync(User);
            var rolesName = await _userManager.GetRolesAsync(user);
            var roles = await GetRoleEntities(rolesName);
            return roles.Select(u => new RoleModel(u)).ToList();
        }

        [HttpPost]
        [Route("authenticated")]
        public async Task<ActionResult<bool>> IsAuthenticated()
        {
            var user = await _userManager.GetUserAsync(User);
            return user != null;
        }


        [HttpPost]
        public async Task<ActionResult> AssignUserRole(string id, UserRolesModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
            for (var i = 0; i < model.RolesNewAssigned.Count; i++)
            {
                await _userManager.AddToRoleAsync(user, model.RolesNewAssigned[i]);
            }
            return Ok();
        }

        private async Task<ICollection<AppRole>> GetRoleEntities(ICollection<string> names)
        {
            var roles = new List<AppRole>();
            foreach (var i in names)
            {
                var role = await _roleManager.FindByNameAsync(i);
                if (role != null)
                    roles.Add(role);
            }
            return roles;
        }

        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
        "abcdefghijkmnopqrstuvwxyz",    // lowercase
        "0123456789",                   // digits
        "!@$?_-"                        // non-alphanumeric
    };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        private async Task<object> GenerateJwtToken(string email, AppUser user)
        {
            return await Task.Run(() =>
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

                var key = new SymmetricSecurityKey(ApiConfiguration.GetJWTSecretKey());
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration.JwtExpireDays));

                var token = new JwtSecurityToken(
                    _configuration.JwtIssuer,
                    _configuration.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            });
        }

    }
}