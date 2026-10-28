using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        public string CandidateName { get; set; }

        [Required]
        public string PartyName { get; set; }

        public int TotalVotes { get; set; }
    }
}