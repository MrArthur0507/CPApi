using JudgeSystem.Core.SubmissionComponent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.SubmissionComponent.Services.Implementation
{
    public class SubmissionSaver : ISubmissionSaver
    {
        private readonly string directoryPath = "C:\\Users\\Bozhidar\\source\\repos\\CPApi\\code";
        private readonly ISubmissionValidator _submissionValidator;

        public SubmissionSaver(ISubmissionValidator submissionValidator)
        {
            _submissionValidator = submissionValidator;
        }
        public string SaveSubmission(string code, string languageType)
        {

            if (!_submissionValidator.ValidateSubmission(code, languageType)) 
            {
                Console.WriteLine("Submission validation failed. Cannot save submission.");
                return null;
            }

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string filePath = Path.Combine(directoryPath, $"submission_{DateTime.Now:yyyyMMddHHmmss}_{languageType}.cs");
                File.WriteAllText(filePath, code);

                Console.WriteLine($"Submission saved successfully at: {filePath}");
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving submission: {ex.Message}");
                return null;
            }
        }
    }
}

