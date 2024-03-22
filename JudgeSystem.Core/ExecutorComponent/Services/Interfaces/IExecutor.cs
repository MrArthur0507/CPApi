using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.ExecutorComponent.Services.Interfaces
{
    public interface IExecutor
    {
        public string Execute(string[] arguments, string programPath);
    }
}
