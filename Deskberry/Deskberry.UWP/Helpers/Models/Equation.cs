namespace Deskberry.UWP.Helpers.Models
{
    public class Equation
    {
        public Equation(string expression, string result)
        {
            Expression = expression;
            Result = result;
        }

        public string Expression { get; set; }
        public string Result { get; set; }
    }
}