using CPApi.ViewModel;
using System.Diagnostics;
using System.IO;

namespace CPApi.Service
{
    public class BasicCompilerService : IBasicCompilerService
    {
        public string Compile(ExerciseViewModel participantCode)
        {
            // Save participant code to a file
            string filePath = Path.Combine(@"C:\Users\Bozhidar\source\repos\CPApi\code", "ParticipantCode.cs");
            File.WriteAllText(filePath, participantCode.Code);

            // Path to the C# compiler
            string compilerPath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\Roslyn\csc.exe";

            // Output directory where the compiled executable will be saved
            string outputDirectory = @"C:\Users\Bozhidar\source\repos\CPApi\code";

            // Output path for the compiled executable
            string outputPath = Path.Combine(outputDirectory, "ParticipantCode.exe");

            // Start the compilation process
            Process compileProcess = new Process();
            compileProcess.StartInfo.FileName = compilerPath;
            compileProcess.StartInfo.Arguments = $"/out:\"{outputPath}\" \"{filePath}\"";
            compileProcess.StartInfo.WorkingDirectory = @"C:\Users\Bozhidar\source\repos\CPApi\code";
            compileProcess.StartInfo.RedirectStandardOutput = true;
            compileProcess.StartInfo.RedirectStandardError = true;
            compileProcess.StartInfo.UseShellExecute = false;
            compileProcess.StartInfo.CreateNoWindow = true;

            compileProcess.Start();

            // Read the compiler output and errors
            string output = compileProcess.StandardOutput.ReadToEnd();
            string errors = compileProcess.StandardError.ReadToEnd();
            compileProcess.WaitForExit();

            // Determine compilation result
            string compilationResult;
            if (compileProcess.ExitCode == 0)
            {
                string compiledProgramOutput = RunCompiledProgram(outputPath);
                compilationResult = $"{Environment.NewLine}Compilation succeeded.{Environment.NewLine}Compiled Program Output:{Environment.NewLine}{compiledProgramOutput}";
            }
            else
            {
                compilationResult = $"Compilation failed with exit code {compileProcess.ExitCode}.{Environment.NewLine}Compilation Errors:{Environment.NewLine}{errors}";
            }

            // Close process streams
            compileProcess.StandardOutput.Close();
            compileProcess.StandardError.Close();

            return compilationResult;
        }

        private string RunCompiledProgram(string programPath)
        {
            // Start the compiled program and capture output
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
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Check for runtime errors
                if (!string.IsNullOrEmpty(errors))
                {
                    output += $"{Environment.NewLine}Runtime Errors:{Environment.NewLine}{errors}";
                }

                return output;
            }
        }
    }
}