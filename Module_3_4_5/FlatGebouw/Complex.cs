using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGebouw
{
    struct Complex
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }
        public static bool operator==(Complex a, Complex b)
        {
            return a.Real == b.Real && a.Imaginary == b.Imaginary;
        }
        public static Complex operator+(Complex a, Complex b)
        {
            return new Complex { Imaginary = a.Imaginary + b.Imaginary, Real = a.Real + b.Real };
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

    }
}
