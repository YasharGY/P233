using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelvin_ve_Celsius;
public class Celsius
{
    public int degree { get; set; }
    public static implicit operator Celsius(Kelvin kelvin)
    {
        return new Celsius { degree = kelvin.degree -273 };
    }
}