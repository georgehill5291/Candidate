using System.ComponentModel.DataAnnotations;

namespace CandidateTestTask.Models
{
    public class Candidate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TimeIntervalToCall { get; set; }
        public string LinkedInProfileUrl { get; set; }
        public string GithubProfileUrl { get; set; }
        [Required]
        public string FreeTextComment { get; set; }
    }
}
