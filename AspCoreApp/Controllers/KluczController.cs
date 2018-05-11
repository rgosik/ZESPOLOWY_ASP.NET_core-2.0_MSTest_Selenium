using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreApp.Data;
using AspCoreApp.Models;

namespace AspCoreApp.Controllers
{
    [Route("[controller]/[action]")]
    public class KluczController : Controller
    {
        private readonly IKluczRepository _keyRepo;

        public KluczController(IKluczRepository keyRepo)
        {
            _keyRepo = keyRepo;
        }

        public async Task<IActionResult> Index()
        {
            var key = await _keyRepo.GetAll();
            return View(key);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var key = await _keyRepo.GetById(id);
            if (key == null)
            {
                return NotFound();
            }

            return View(key);
        }

        public async Task<IActionResult> Create()
        {
            await _keyRepo.Save();
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Klucz key)
        {
            if (!ModelState.IsValid)
            {
                return View(key);
            }

            _keyRepo.Add(key);
            await _keyRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: Address/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var key = await _keyRepo.GetById(id);
            if (key == null)
            {
                return NotFound();
            }

            return View(key);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Klucz key)
        {
            if (!ModelState.IsValid)
            {
                return View(key);
            }

            _keyRepo.Update(key);
            await _keyRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _keyRepo.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var key = await _keyRepo.GetById(id);
            if (key == null)
            {
                return NotFound();
            }

            _keyRepo.Delete(key);
            await _keyRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
