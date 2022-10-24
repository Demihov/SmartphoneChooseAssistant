using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Rules;

namespace FuzzyLogicController.Logic
{
    public class FuzzyRuleEvaluator : IFuzzyRuleEvaluator
    {
        public double Evaluate(List<FuzzyRuleCondition> ruleConditions)
        {
            double value = 0;
            bool isFirstCondition = true;

            foreach (var condition in ruleConditions)
            {
                var conditionValue = condition.MembershipFunction.Fuzzify(condition.Variable.InputValue);

                if (isFirstCondition)
                {
                    value = conditionValue;
                    isFirstCondition = false;
                }
                else
                {
                    if (conditionValue < value)
                        value = conditionValue;
                }
            }

            return value;
        }
    }
}
