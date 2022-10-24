namespace FuzzyLogicController.Rules
{
    public class Premise : List<FuzzyRuleCondition>
    {
        public Premise(FuzzyRuleCondition condition)
        {
            this.Add(condition);
        }
        public Premise(IEnumerable<FuzzyRuleCondition> conditions)
        {
            foreach (var condition in conditions)
            {
                Add(condition);
            }
        }
    }
}