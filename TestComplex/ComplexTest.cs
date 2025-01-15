using TestExample;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestComplex
{
    public class ComplexTest
    {
        [Fact]
        public void ToString_ReturnsString()
        {
            var z1 = new Complex(3, 5);
            Assert.Equal("3+5i", z1.ToString());
            var z2 = new Complex(-3, -5);
            Assert.Equal("-3-5i", z2.ToString());
            var z3 = new Complex(0, 0);
            Assert.Equal("0", z3.ToString());
        }

        [Theory]
        [InlineData(3, 5, "3+5i")]
        [InlineData(-3, -5, "-3-5i")]
        [InlineData(0, 0, "0")]
        [InlineData(1, 1, "1+i")]
        [InlineData(-1, -1, "-1-i")]
        [InlineData(0, 1, "i")]
        [InlineData(1, 0, "1")]
        [InlineData(0, -3, "-3i")]
        [InlineData(0, 3, "3i")]
        [InlineData(3, 0, "3")]
        [InlineData(-3, 0, "-3")]
        public void ToStringReIm_RetunsString(double re, double im, string expected)
        {
            var z = new Complex(re, im);
            Assert.Equal(expected, z.ToString());
        }

        public static IEnumerable<object[]> Complexes
        {
            get
            {
                var sr = new StreamReader("complex_test.txt", System.Text.Encoding.UTF8);
                while (true){
                    var data = sr.ReadLine()?.Split(',', ' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    if (data is not null)
                    {
                        Complex c;
                        try
                        {
                            c = new Complex(double.Parse(data[0]), double.Parse(data[1]));
                        }
                        catch
                        {
                            c = new Complex();
                        }
                        yield return new object[] { c, data[2] };
                    }
                    else yield break;
                }
            }
        }
        [Theory]
        [MemberData(nameof(Complexes))]
        public void ToString_Complex_ReturnsString(Complex z, string expected)
        {
            Assert.Equal(expected, z.ToString());
        }
    }
}
