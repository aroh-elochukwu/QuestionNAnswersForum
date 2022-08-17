using QuestionNAnswersForum.Data;
using QuestionNAnswersForum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace QuestionNAnswersForum.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        public async Task<ActionResult> Index()
        {
            List<Question> QuestionsList = _context.Question.ToList();
            return View(QuestionsList);
        }

        public async Task<ActionResult> DeleteQuestion(int? questionId)
        {
            Question question = _context.Question.First(q => q.Id == questionId);
            _context.Question.Remove(question);
            List<Answer> answers = _context.Answer.Where(a => a.Question == question).ToList();
            answers.ForEach(a =>
            {
                _context.Answer.Remove(a);
            });
            List<Comment> comments = _context.Comments.Where(c => c.Question == question || c.Answer.Question == question).ToList();
            comments.ForEach(c =>
            {
                _context.Comments.Remove(c);
            });
            
            List<Tag> questionTags = _context.Tags.ToList();
           
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}