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
        private readonly string _outputPath = "C:\\Users\\Bozhidar\\source\\repos\\CPApi\\code";

        public string Compile(string submissionFilePath)
        {
            try
            {
                string compilerPath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\Roslyn\csc.exe";
                string uniqueOutputFileName = $"{Guid.NewGuid()}.exe";
                string outputFilePath = System.IO.Path.Combine(_outputPath, uniqueOutputFileName);

                Console.WriteLine($"Output file path: {outputFilePath}");
                Console.WriteLine($"Submission file path: {submissionFilePath}");

                Process compileProcess = new Process();
                compileProcess.StartInfo.FileName = compilerPath;
                compileProcess.StartInfo.Arguments = $"/out:\"{outputFilePath}\" \"{submissionFilePath}\"";
                compileProcess.StartInfo.WorkingDirectory = _outputDirectory;
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
                    return outputFilePath;
                }
                else
                {
                    Console.WriteLine($"Compilation failed with errors: {errors}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during compilation: {ex.Message}");
                return null;
            }
        }
    }
}
