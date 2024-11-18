using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_SAMPLE.Data;
using MVC_SAMPLE.Models;

namespace MVC_SAMPLE.Controllers
{
    public class DiaryEntryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

          
        public DiaryEntryController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
           
        }


        public IActionResult Index()
        {
            List<DiaryEntry> entries = _dbContext.DiaryEntry
          .OrderByDescending(entry => entry.Created)
          .ToList();
            return View(entries);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title is empty or title is too short");
            }

        

            if (ModelState.IsValid)
            {
                _dbContext.DiaryEntry.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            TempData["EntryID"] = id;
            DiaryEntry? diaryEntry = _dbContext.DiaryEntry.Find(id);

            if (id == null || id == 0 || diaryEntry == null) { 
                return NotFound();
            }

            return View(diaryEntry);
            
        }

		[HttpPost]
		public IActionResult Update(DiaryEntry obj)
		{
			if (obj != null && obj.Title.Length < 3)
			{
				ModelState.AddModelError("Title", "Title is empty or title is too short");
			}

			if (ModelState.IsValid)
			{
			
				_dbContext.DiaryEntry.Update(obj);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(obj);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			DiaryEntry? diaryEntry = _dbContext.DiaryEntry.Find(id);

			if (id == null || id == 0 || diaryEntry == null)
			{
				return NotFound();
            }
            else
            {
                _dbContext.DiaryEntry.Remove(diaryEntry);
				_dbContext.SaveChanges();
			}
            return RedirectToAction("Index");
		}



	}
}
