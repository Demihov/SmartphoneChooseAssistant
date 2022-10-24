using FuzzyLogicController.Interfaces;
using FuzzyLogicController.MembershipFunctions;
using System.Collections.ObjectModel;

namespace FuzzyLogicController.Models
{
    public class MembershipFunctionCollection : Collection<IMembershipFunction>
    {
        public IMembershipFunction AddTrapezoid(string name, double a, double b, double c, double d)
        {
            var memFunc = new TrapezoidMembershipFunction(name, a, b, c, d);
            this.Add(memFunc);
            return memFunc;
        }

        public IMembershipFunction AddTriangle(string name, double a, double b, double c)
        {
            var memFunc = new TriangleMembershipFunction(name, a, b, c);
            this.Add(memFunc);
            return memFunc;
        }
    }
}