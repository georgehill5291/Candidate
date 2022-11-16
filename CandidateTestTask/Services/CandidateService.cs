using CandidateTestTask.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Reflection;

namespace CandidateTestTask.Services
{
    public interface ICandidateService
    {
        StringBuilder Create(Candidate model);
    }

    public class CandidateService : ICandidateService
    {
        public StringBuilder Create(Candidate model)
        {
            //before your loop
            var csv = new StringBuilder();

            //Suggestion made by KyleMit
            var newLine = $"{model.FirstName}," +
                          $"{model.LastName}," +
                          $"{model.PhoneNumber}," +
                          $"{model.Email}," +
                          $"{model.TimeIntervalToCall}," +
                          $"{model.LinkedInProfileUrl}," +
                          $"{model.GithubProfileUrl}," +
                          $"{model.FreeTextComment}";                
            csv.AppendLine(newLine);
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
            var filePath = Path.Combine(path + "\\CandidateCSV\\", $"{model.FirstName}-{model.LastName}-{DateTime.Now.Ticks}.csv");
            File.WriteAllText(filePath, csv.ToString());

            return csv;
        }
    }
}
