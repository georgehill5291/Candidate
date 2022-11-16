using CandidateTestTask.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CandidateTestTask.Builder
{

    interface ICandidateBuilder
    {
        CandidateBuilder AddFirstname(string firstname);
        CandidateBuilder AddLastname(string lastname);        
        CandidateBuilder AddPhoneNumber(string phoneNumber);        
        CandidateBuilder AddEmail(string email);        
        CandidateBuilder AddTimeIntervalToCall(string timeIntervalToCall);        
        CandidateBuilder AddGithubProfileUrl(string githubProfileUrl);        
        CandidateBuilder AddLinkedInProfileUrl(string linkedInProfileUrl);        
        CandidateBuilder AddFreeTextComment(string freeTextComment);        
        Candidate Build();
    }


    public class CandidateBuilder : ICandidateBuilder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TimeIntervalToCall { get; set; }
        public string LinkedInProfileUrl { get; set; }
        public string GithubProfileUrl { get; set; }
        public string FreeTextComment { get; set; }

        public CandidateBuilder AddEmail(string email)
        {
            Email = email;
            return this;
        }

        public CandidateBuilder AddFirstname(string firstname)
        {
            FirstName = firstname;
            return this;
        }

        public CandidateBuilder AddFreeTextComment(string freeTextComment)
        {
            this.FreeTextComment = freeTextComment;
            return this;
        }

        public CandidateBuilder AddGithubProfileUrl(string githubProfileUrl)
        {
            this.GithubProfileUrl = githubProfileUrl;
            return this;
        }

        public CandidateBuilder AddLastname(string lastname)
        {
            this.LastName = lastname;
            return this;
        }

        public CandidateBuilder AddLinkedInProfileUrl(string linkedInProfileUrl)
        {
            this.LinkedInProfileUrl = linkedInProfileUrl ;
            return this;
        }

        public CandidateBuilder AddPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            return this;
        }

        public CandidateBuilder AddTimeIntervalToCall(string timeIntervalToCall)
        {
            this.TimeIntervalToCall = TimeIntervalToCall;
            return this;
        }

        public Candidate Build()
        {
            return new Candidate(this.FirstName, this.LastName, this.Email, this.PhoneNumber, this.TimeIntervalToCall, this.LinkedInProfileUrl, this.GithubProfileUrl, this.FreeTextComment);
        }
    }
}
