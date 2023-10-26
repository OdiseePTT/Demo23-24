using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame
{
    public interface IRandomProvider
    {
        int Next(int maxValue);
        double NextDouble();
    }

    public class RandomProvider : IRandomProvider
    {
        public int Next(int maxValue)
        {
            return new Random().Next(maxValue);
        }

        public double NextDouble()
        {
            return new Random().NextDouble();
        }
    }
}
