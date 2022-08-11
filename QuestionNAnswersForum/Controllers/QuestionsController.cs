using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionNAnswersForum.Data;
using QuestionNAnswersForum.Models;
using QuestionNAnswersForum.Models.ViewModels;

namespace QuestionNAnswersForum.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Questions
        public async Task<IActionResult> Index(string? sortOrder)
        {
            
            IQueryable <Question> questions =  _context.Question.Include(r => r.User).Include(r => r.Answers);

            switch (sortOrder)
            {
                case " ":
                    questions = questions.OrderByDescending(r => r.DateAsked);
                    break;
                case "sortByDate":
                    questions = questions.OrderByDescending(r => r.DateAsked);
                    return View("Index");
                    break;
                case "SortByAnswersCount":
                    questions = questions.OrderByDescending(r => r.Answers.Count);
                    return View ("Index");
                    break;
                default:
                    questions = questions.OrderByDescending(r => r.DateAsked);
                    break;
            }

            return View(questions.ToList());
            
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult AskQuestion()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AskQuestion(string? title, string content)
        {
            string userName = User.Identity.Name;
            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            Question newQuestion = new Question();
            if (title != null && content != null)
            {
                newQuestion.Title = title;
                newQuestion.Content = content;
                newQuestion.DateAsked = DateTime.Now;
                newQuestion.User = user;
                user.Questions.Add(newQuestion);
                _context.Question.Add(newQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        public IActionResult AddAnswer()
        {
            QuestionsSelectViewModel vm = new QuestionsSelectViewModel(_context.Question.ToList());

            return View(vm);


        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer(int? questionId, string post)
        {
            string UserName = User.Identity.Name;
            ApplicationUser user = await _userManager.FindByNameAsync(UserName);
            Answer answer = new Answer();
            Question question = await _context.Question.FirstAsync(q => q.Id == questionId);

            if (post != null && question != null)
            {
                answer.Post = post;
                answer.User = user;
                question.Answers.Add(answer);
                _context.Add(answer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", question.UserId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,UserId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", question.UserId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Question == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Question'  is null.");
            }
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
          return (_context.Question?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
