using FuzzyLogicController.Rules;

namespace FuzzyLogicController.Interfaces
{
    public interface IFuzzyRuleEvaluator
    {
        double Evaluate(List<FuzzyRuleCondition> ruleConditions);
    }
}