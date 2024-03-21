using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services
{
    public class CSharpExecutor
    {
        public string RunCompiledProgram(string programPath)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = programPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ToString();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();


                if (!string.IsNullOrEmpty(errors))
                {
                    output += $"{Environment.NewLine}Runtime Errors:{Environment.NewLine}{errors}";
                }

                return output;
            }
        }
    }
}
