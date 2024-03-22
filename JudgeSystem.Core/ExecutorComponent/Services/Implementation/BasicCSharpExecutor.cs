using JudgeSystem.Core.ExecutorComponent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.ExecutorComponent.Services.Implementation
{
    public class BasicCSharpExecutor : IExecutor
    {
        public string Execute(string[] arguments, string programPath)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = programPath,
                    Arguments = string.Join(" ", arguments), 
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start(); 

                    
                    Task<string> outputTask = process.StandardOutput.ReadToEndAsync();
                    Task<string> errorTask = process.StandardError.ReadToEndAsync();

                    
                    Task.WaitAll(outputTask, errorTask);

                    string output = outputTask.Result; 
                    string errors = errorTask.Result; 

                    process.WaitForExit(); 

                    if (!string.IsNullOrEmpty(errors))
                    {
                        return $"Runtime Errors:{Environment.NewLine}{errors}";
                    }

                    Console.WriteLine(output);
                    return output;
                }
            }
            catch (Exception ex)
            {
                return $"Error occurred during program execution: {ex.Message}";
            }
        }
    }
}
