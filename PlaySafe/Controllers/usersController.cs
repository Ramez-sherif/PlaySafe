using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaySafe.Data;
using PlaySafe.Models;
using Microsoft.AspNetCore.Http;

namespace PlaySafe.Controllers
{
    public class usersController : Controller
    {
        private readonly dbContext _context;

        public usersController(dbContext context)
        {
            _context = context;
        }

        // GET: users
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.user.Include(u => u.userType);
            return View(await dbContext.ToListAsync());
        }

        // GET: users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .Include(u => u.userType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: users/Create
        public IActionResult Create()
        {
            ViewData["userTypeId"] = new SelectList(_context.Set<userType>(), "id", "id");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,userName,password,phoneNum")] registerViewModel register)
        {
            if (ModelState.IsValid)
            {
                var typeIsUser = _context.userType.Where(x => x.usersType == "player").FirstOrDefault();
                if(typeIsUser != null)
                {
                    var userType = HttpContext.Session.GetString("userType");

                    if (userType == "Admin") typeIsUser = _context.userType.Where(x => x.usersType == "Guard").FirstOrDefault();

                    else if (userType == "Owner") typeIsUser = _context.userType.Where(x => x.usersType == "Admin").FirstOrDefault();

                    else if (userType == "Guard") typeIsUser = _context.userType.Where(x => x.usersType == "Player").FirstOrDefault();

                    else return Redirect("/Home/Index");
               
                    user User = new user()
                    {
                        id = Guid.NewGuid(),
                        userTypeId = typeIsUser.id,
                        name = register.name,
                        userName = register.userName,
                        password = register.password,
                        createdDate = DateTime.Now,
                        phoneNum = register.phoneNum
                    };
                    _context.user.Add(User);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(register);
        }
        // GET: users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["userTypeId"] = new SelectList(_context.Set<userType>(), "id", "id", user.userTypeId);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,userTypeId,name,userName,password,createdDate,phoneNum")] user user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(user.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["userTypeId"] = new SelectList(_context.Set<userType>(), "id", "id", user.userTypeId);
            return View(user);
        }

        // GET: users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .Include(u => u.userType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.user == null)
            {
                return Problem("Entity set 'dbContext.user'  is null.");
            }
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                _context.user.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userExists(Guid id)
        {
          return _context.user.Any(e => e.id == id);
        }
        public async Task<IActionResult> login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login([Bind("userName,password")] loginViewModel loginCredentials)
        {
            var user = _context.user.Where(x => x.userName == loginCredentials.userName && x.password == loginCredentials.password).FirstOrDefault();

            if(user != null)
            {
                var theUserType = _context.userType.Where(x => x.id == user.userTypeId).FirstOrDefault();
                
                if (theUserType == null)
                {
                    return View();//return error
                }
                else
                {
                HttpContext.Session.SetString("userId", user.id.ToString("D"));
                HttpContext.Session.SetString("userTypeId", user.userTypeId.ToString("D"));
                HttpContext.Session.SetString("userType", theUserType.usersType.ToString());
                }   

                return Redirect("/Home/Index");
            }
            ModelState.AddModelError("userName", "Username or password are invalid");
            return View(loginCredentials);
        }
        public async Task<IActionResult> ChooseMatch()
        {
            ViewBag.userId = HttpContext.Session.GetString("userId");
            ViewBag.typeId = HttpContext.Session.GetString("userTypeId");
            ViewBag.userType = HttpContext.Session.GetString("userType");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseMatch([Bind("matchCost")] matchViewModel match)
        {
            var userId = HttpContext.Session.GetString("userId");
            var userGuid = new Guid(userId);
            Console.WriteLine("her her her here: " + match.matchCost);
            matchHistory lastMatch = _context.matchHistory.Where(n => n.userId == userGuid && n.active == true).FirstOrDefault();
            var entry = _context.entry.Where(n => n.price == match.matchCost).FirstOrDefault();
            if (lastMatch == null || lastMatch.createdDate.AddHours(24) >= DateTime.Now)//or last match of date and time - datetime.now is more than 24 hours
             {
                //if (lastMatch != null) lastMatch.active = false;
                matchHistory matchHistory = new matchHistory()
                {
                     id = Guid.NewGuid(),
                     userId = userGuid,
                     entryId = entry.id,                     
                     createdDate = DateTime.Now
                 };
                 _context.matchHistory.Add(matchHistory);
                 _context.SaveChanges();
                 return Redirect("/Users/Create");
             }
            //he has to wait 24 hours to play
            //return Problem("wait");
            return View();
        }
    }
}
