using GRC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GRC.DataAccess
{
    public static class Extensions
    {

        [DbFunction("scalarFunction", "mfk")]
        public static bool ScalarFunction(/*this Process process, */int processId)
        {
            throw new NotImplementedException();
        }
    }
}
