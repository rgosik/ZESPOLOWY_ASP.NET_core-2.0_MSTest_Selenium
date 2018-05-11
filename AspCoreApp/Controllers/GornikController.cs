using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspCoreApp.Data;
using AspCoreApp.Models;

namespace AspCoreApp.Controllers
{
    public class GornikController : Controller
    {
        private readonly IGornikRepository _minerRepo;
        private readonly IKluczRepository _keyRepo;

        public GornikController(IGornikRepository minerRepo, IKluczRepository keyRepo)
        {
            _minerRepo = minerRepo;
            _keyRepo = keyRepo;
        }

        public async Task<IActionResult> Index()
        {
            var miners = await _minerRepo.GetAll();
            return View(miners);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miner = await _minerRepo.GetById(id);
            if (miner == null)
            {
                return NotFound();
            }

            return View(miner);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["AddressList"] = new SelectList(await _keyRepo.GetAll(), "Id", "FullKey");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gornik miner)
        {
            if (!ModelState.IsValid)
            {

                ViewData["AddressList"] = new SelectList(await _minerRepo.GetAll(), "Id", "FullKey", miner.KluczId);
                return View(miner);
            }

            _minerRepo.Add(miner);
            await _minerRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miner = await _minerRepo.GetById(id);
            if (miner == null)
            {
                return NotFound();
            }

            ViewData["AddressList"] = new SelectList(await _keyRepo.GetAll(), "Id", "FullKey", miner.KluczId);
            return View(miner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Gornik miner)
        {
            if (!ModelState.IsValid)
            {
                ViewData["AddressList"] = new SelectList(await _keyRepo.GetAll(), "Id", "FullKey", miner.KluczId);
                return View(miner);
            }

            _minerRepo.Update(miner);
            await _minerRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miner = await _minerRepo.GetById(id);
            if (miner == null)
            {
                return NotFound();
            }

            return View(miner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var miner = await _minerRepo.GetById(id);
            if (miner == null)
            {
                return NotFound();
            }

            _minerRepo.Delete(miner);
            await _minerRepo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
