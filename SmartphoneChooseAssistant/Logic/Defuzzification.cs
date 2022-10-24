using FuzzyLogicController.Interfaces;

namespace FuzzyLogicController.Logic
{
    public class Defuzzification : IDefuzzification
    {
        public double Defuzzify(List<IMembershipFunction> functions)
        {
            var minX = 0;
            var maxX = 1;

            var mid = 0.0;
            var sum = 0.0;
            var sumx = 0.0;

            for (double i = minX; i <= maxX; i += 0.01)
            {
                var maxAtX = functions.Select(f => f.PremiseModifier * f.Fuzzify(i)).Max();
                sum += maxAtX;
                sumx += i * maxAtX;
            }

            mid = sumx / sum;

            return mid;
        }
    }
}
