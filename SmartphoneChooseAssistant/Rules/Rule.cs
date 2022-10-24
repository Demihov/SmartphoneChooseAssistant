namespace FuzzyLogicController.Rules
{
    public static class Rule
    {
        public static FuzzyRule If(List<FuzzyRuleCondition> conditions)
        {
            var rule = new FuzzyRule();
            rule.Premise = new Premise(conditions);
            return rule;
        }

        public static FuzzyRule If(FuzzyRuleCondition condition)
        {
            var rule = new FuzzyRule();
            rule.Premise = new Premise(condition);
            return rule;
        }
    }
}
