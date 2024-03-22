using JudgeSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.CompilerComponent.Services.Interfaces
{
    public interface ICompiler
    {
        public string Compile(string submissionFilePath);
    }
}
