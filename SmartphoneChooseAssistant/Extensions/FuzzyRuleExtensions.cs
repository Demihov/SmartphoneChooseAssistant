using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Models;
using FuzzyLogicController.Rules;

namespace FuzzyLogicController.Extensions
{
    public static class FuzzyRuleExtensions
    {
        public static FuzzyRuleCondition Is(this LinguisticVariable value, IMembershipFunction function)
        {
            if (null == function)
                throw new ArgumentNullException("function");

            var clause = new FuzzyRuleCondition(value, function);
            return clause;
        }

        public static List<FuzzyRuleCondition> And(this FuzzyRuleCondition value, FuzzyRuleCondition condition)
        {
            var conditions = new List<FuzzyRuleCondition>();
            var conjunction = new FuzzyRuleConditionConjunction() { Conjunction = "AND", FirstCondition = value, SecondCondition = condition };
            condition.Conjunction = conjunction;
            conditions.Add(value);
            conditions.Add(condition);

            return conditions;
        }
        public static List<FuzzyRuleCondition> And(this List<FuzzyRuleCondition> value, FuzzyRuleCondition condition)
        {
            var firstCondition = value.Last();
            var conjunction = new FuzzyRuleConditionConjunction() { Conjunction = "AND", FirstCondition = firstCondition, SecondCondition = condition };
            condition.Conjunction = conjunction;

            value.Add(condition);

            return value;
        }

        public static FuzzyRule Then(this FuzzyRule value, FuzzyRuleClause clause)
        {
            if (null == clause) throw new ArgumentNullException("clause");

            var conclusion = new Conclusion(clause.Variable, clause.MembershipFunction);

            value.Conclusion = conclusion;

            return value;
        }
    }
}
