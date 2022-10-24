namespace FuzzyLogicController.Rules
{
    public class FuzzyRuleConditionConjunction
    {
        public string Conjunction { get; set; }
        public FuzzyRuleCondition FirstCondition { get; set; }
        public FuzzyRuleCondition SecondCondition { get; set; }
    }
}