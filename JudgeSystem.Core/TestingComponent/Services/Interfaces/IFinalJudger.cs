﻿using JudgeSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.TestingComponent.Services.Interfaces
{
    public interface IFinalJudger
    {
        public TestResultSuite Judge(string programPath, TestSuite testCases);
    }
}
