using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGissa.Models;

namespace PruebaTecnicaGissa.Controllers
{
    public class TestUsersController : Controller
    {
        private readonly TestDbContext _context;

        public TestUsersController(TestDbContext context)
        {
            _context = context;
        }

        // GET: TestUsers
        public async Task<IActionResult> Index()
        {
              return _context.TestUsers != null ? 
                          View(await _context.TestUsers.ToListAsync()) :
                          Problem("Entity set 'TestDbContext.TestUsers'  is null.");
        }

        // GET: TestUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestUsers == null)
            {
                return NotFound();
            }

            var testUser = await _context.TestUsers
                .FirstOrDefaultAsync(m => m.UserPrimaryId == id);
            if (testUser == null)
            {
                return NotFound();
            }

            return View(testUser);
        }

        // GET: TestUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserPrimaryId,UserLastName,UserNickName,UserUserType,UserTypeCed,UserCed,UserPass,UserEmail")] TestUser testUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testUser);
        }

        // GET: TestUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestUsers == null)
            {
                return NotFound();
            }

            var testUser = await _context.TestUsers.FindAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }
            return View(testUser);
        }

        // POST: TestUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserPrimaryId,UserLastName,UserNickName,UserUserType,UserTypeCed,UserCed,UserPass,UserEmail")] TestUser testUser)
        {
            if (id != testUser.UserPrimaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestUserExists(testUser.UserPrimaryId))
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
            return View(testUser);
        }

        // GET: TestUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestUsers == null)
            {
                return NotFound();
            }

            var testUser = await _context.TestUsers
                .FirstOrDefaultAsync(m => m.UserPrimaryId == id);
            if (testUser == null)
            {
                return NotFound();
            }

            return View(testUser);
        }

        // POST: TestUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestUsers == null)
            {
                return Problem("Entity set 'TestDbContext.TestUsers'  is null.");
            }
            var testUser = await _context.TestUsers.FindAsync(id);
            if (testUser != null)
            {
                _context.TestUsers.Remove(testUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestUserExists(int id)
        {
          return (_context.TestUsers?.Any(e => e.UserPrimaryId == id)).GetValueOrDefault();
        }
    }
}
