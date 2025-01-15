
using System.Text;

namespace TestExample
{
    public class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public Complex() { }
        public Complex(double re, double im) { Re = re; Im = im; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Re != 0.0 || Im == 0.0) sb.Append(Re);
            if (Im != 0.0)
            {
                sb.Append(Im < 0 ? "-" : (Re != 0.0 ? "+" : ""));
                if (Math.Abs(Im) != 1.0) sb.Append(Math.Abs(Im));
                sb.Append('i');
            }
            return sb.ToString();
        }
    }
}
