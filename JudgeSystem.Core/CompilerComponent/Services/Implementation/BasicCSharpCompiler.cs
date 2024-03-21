using JudgeSystem.Core.CompilerComponent.Services.Interfaces;
using JudgeSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.CompilerComponent.Services.Implementation
{
    public class BasicCSharpCompiler : ICompiler
    {
        private readonly string _compilerPath;
        private readonly string _outputDirectory = "C:\\Users\\Bozhidar\\source\\repos\\CPApi\\code";
        private readonly string outputPath = "C:\\Users\\Bozhidar\\source\\repos\\CPApi\\code\\Code.exe";



        public bool Compile(string submissionFilePath)
        {
            try
            {
                
                string compilerPath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\Roslyn\csc.exe";

                Console.WriteLine(submissionFilePath);
                Process compileProcess = new Process();
                compileProcess.StartInfo.FileName = compilerPath;
                compileProcess.StartInfo.Arguments = $"/out:\"{outputPath}\" \"{submissionFilePath}\"";
                compileProcess.StartInfo.WorkingDirectory = @"C:\Users\Bozhidar\source\repos\CPApi\code";
                compileProcess.StartInfo.UseShellExecute = false;
                compileProcess.StartInfo.RedirectStandardOutput = true;
                compileProcess.StartInfo.RedirectStandardError = true;
                compileProcess.Start();

                string output = compileProcess.StandardOutput.ReadToEnd();
                string errors = compileProcess.StandardError.ReadToEnd();
                compileProcess.WaitForExit();

                if (compileProcess.ExitCode == 0)
                {
                    Console.WriteLine("Compilation successful.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Compilation failed with errors: {errors}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during compilation: {ex.Message}");
                return false;
            }
        }

    }
}
