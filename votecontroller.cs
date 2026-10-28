using Microsoft.AspNetCore.Mvc;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    public class VoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(
                _context.Candidates.ToList());
        }

        public IActionResult CastVote(int id)
        {
            var voterId =
                HttpContext.Session.GetInt32("VoterId");

            if (voterId == null)
                return RedirectToAction(
                    "Login",
                    "Account");

            var voter =
                _context.Voters.Find(voterId);

            if (voter.HasVoted)
            {
                TempData["msg"] =
                    "You already voted";

                return RedirectToAction("Index");
            }

            var candidate =
                _context.Candidates.Find(id);

            candidate.TotalVotes++;

            voter.HasVoted = true;

            _context.SaveChanges();

            TempData["msg"] =
                "Vote Cast Successfully";

            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            return View(
                _context.Candidates.ToList());
        }
    }
}