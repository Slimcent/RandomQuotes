using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomQuotes.Data;
using RandomQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomQuotes.Controllers
{
    public class QuoteController : Controller
    {
        private readonly EntitiesContext _dbContext;
        public QuoteController(EntitiesContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IActionResult> Index(int pg = 1)
        {
            var quotesResult = await _dbContext.Quotes.OrderBy(emp => Guid.NewGuid()).ToListAsync();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;
            int quotesCount = quotesResult.Count();
            var pager = new Pager(quotesCount, pg, pageSize);
            int quoteSkip = (pg - 1) * pageSize;
            var quotesWithPagination = quotesResult.Skip(quoteSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(quotesWithPagination);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(QuotesViewModel quotesModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //ModelState.Clear();
                    return View();
                }
                else
                {
                    await _dbContext.Quotes.AddAsync(quotesModel);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task <IActionResult> Edit(int id)
        {
            try
            {
                var result = await _dbContext.Quotes.Where(q => q.Id == id).FirstOrDefaultAsync();
                return View("Edit", result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task <IActionResult> Edit(QuotesViewModel edit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Quotes.Update(edit);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit", edit);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Edit", edit);
            }
        }
        
        
        [HttpPost]
        public async Task <IActionResult> Delete(int id)
        {
            try
            {
                var deleteQuote = await _dbContext.Quotes.Where(q => q.Id == id).FirstOrDefaultAsync();
                if (deleteQuote != null )
                {
                    _dbContext.Quotes.Remove(deleteQuote);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }              
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

    }
}
