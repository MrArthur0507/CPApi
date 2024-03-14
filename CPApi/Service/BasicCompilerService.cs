using System.Diagnostics;

namespace CPApi.Service
{
    public class BasicCompilerService : IBasicCompilerService
    {
        public void Compile(string participantCode)
        {

            string filePath = "ParticipantCode.cs";
            File.WriteAllText(filePath, participantCode);

            string compilerPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";

            Process compileProcess = new Process();
            compileProcess.StartInfo.FileName = compilerPath;
            compileProcess.StartInfo.Arguments = $"/out:ParticipantCode.exe {filePath}";
            compileProcess.StartInfo.RedirectStandardOutput = true;
            compileProcess.StartInfo.RedirectStandardError = true;  
            compileProcess.StartInfo.UseShellExecute = false;
            compileProcess.StartInfo.CreateNoWindow = true;

            compileProcess.Start();

            
            string output = compileProcess.StandardOutput.ReadToEnd();
            string errors = compileProcess.StandardError.ReadToEnd();
            compileProcess.WaitForExit();

            Console.WriteLine("Compilation Output:");
            Console.WriteLine(output);
            Console.WriteLine("Compilation Errors:");
            Console.WriteLine(errors);

            if (compileProcess.ExitCode == 0)
            {
                Console.WriteLine("Compilation successful!");
            }
            else
            {
                Console.WriteLine($"Compilation failed with exit code {compileProcess.ExitCode}.");
            }

            compileProcess.StandardOutput.Close();
            compileProcess.StandardError.Close();


        }
    }
}
