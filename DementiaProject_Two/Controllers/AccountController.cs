using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DementiaProject_Two.Models;
using DementiaProject_Two.Models.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace DementiaProject_Two.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private IPasswordHasher<IdentityUser> _hasher;
        private Tokens _tokens;

        public AccountController(UserManager<IdentityUser> userManager, 
                                 SignInManager<IdentityUser> signInManager, 
                                 IPasswordHasher<IdentityUser> hasher,
                                 IOptions<Tokens> tokens)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hasher = hasher;
            _tokens = tokens.Value;
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Registration user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var newUser = new IdentityUser
            {
                Email = user.Email,
                UserName = user.Email
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                // handle this
                return View(user);
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login user, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //GetToken(user); - FIX WHEN GETTOKEN IS DONE
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login!");
                }
            }
            // we have to create the UserInformation object here through the api! <---------------- NOTICE!!!
            return View(user);

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("api")]
        public async Task<IActionResult> GetToken([FromBody] Login login)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user, user.PasswordHash, login.Password) == PasswordVerificationResult.Success)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokens.Key)), SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken
                        (
                            issuer: _tokens.Issuer,
                            audience: _tokens.Audience,
                            claims: claims,
                            expires: DateTime.UtcNow.AddDays(60),
                            signingCredentials: creds
                        );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e}");
            }
            return NotFound("Error: User not found");
        }
    }
}