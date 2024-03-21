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
        private readonly string _programPath = "C:\\Users\\Bozhidar\\source\\repos\\CPApi\\code\\myprogram.exe";

        
        public string Execute(string[] arguments)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = _programPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                   
                };
                string joined = string.Join(" ", arguments);
                Console.WriteLine(joined);

                Console.WriteLine(startInfo.ArgumentList.Count);
                using (Process process = Process.Start(startInfo.FileName, joined))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
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
