using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.Helpers.Models
{
    public class Equation
    {
        public string Expression { get; set; }
        public string Result { get; set; }

        public Equation(string expression, string result)
        {
            Expression = expression;
            Result = result;
        }
    }
}
