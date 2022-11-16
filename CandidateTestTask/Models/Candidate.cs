using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CandidateTestTask.Models
{
    public class Candidate
    {

        public Candidate(string firstname,
            string lastname,
            string phoneNumber,
            string email,
            string timeIntervalToCall,
            string linkedInProfile,
            string githubProfile,
            string freeTextComment)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.TimeIntervalToCall = timeIntervalToCall;
            this.LinkedInProfileUrl = linkedInProfile;
            this.GithubProfileUrl = githubProfile;
            this.FreeTextComment = freeTextComment;
        }

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
