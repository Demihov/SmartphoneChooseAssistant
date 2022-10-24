using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Models;

namespace FuzzyLogicController.Rules
{
    // Then-part of the rule
    public class Conclusion : FuzzyRuleClause
    {
        public Conclusion(LinguisticVariable variable, IMembershipFunction function)
            : base(variable, function) { }
    }
}