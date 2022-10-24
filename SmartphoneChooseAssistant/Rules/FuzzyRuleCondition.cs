using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Models;

namespace FuzzyLogicController.Rules
{
    public class FuzzyRuleCondition : FuzzyRuleClause
    {
        public FuzzyRuleCondition(LinguisticVariable variable, IMembershipFunction function)
            : base(variable, function) { }
        public FuzzyRuleConditionConjunction Conjunction { get; set; }
    }
}