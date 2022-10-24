using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Models;

namespace FuzzyLogicController.Rules
{
    public class FuzzyRuleClause
    {
        public FuzzyRuleClause(LinguisticVariable variable, IMembershipFunction function)
        {
            Variable = variable;
            MembershipFunction = function;
        }

        public LinguisticVariable Variable { get; set; }
        public IMembershipFunction MembershipFunction { get; set; }
    }
}