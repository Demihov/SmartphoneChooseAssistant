using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Rules;

namespace FuzzyLogicController.Logic
{
	public class FuzzyLogicService : IFuzzyLogicService
	{
		private readonly List<FuzzyRule> _rules;
		private readonly IFuzzyRuleEvaluator _fuzzyRuleEvaluator;
		private readonly IDefuzzification _defuzzification;

		public FuzzyLogicService(
			List<FuzzyRule> rules,
			IDefuzzification defuzzification,
			IFuzzyRuleEvaluator fuzzyRuleEvaluator)
		{
			_rules = rules;
			_fuzzyRuleEvaluator = fuzzyRuleEvaluator;
			_defuzzification = defuzzification;
		}

		public double StartProcess()
		{
			_rules.ForEach(r => r.Conclusion.MembershipFunction.PremiseModifier = 0);

			var conclustionMembershipFunctions = _rules.Select(r => r.Conclusion.MembershipFunction).ToList();

			foreach (FuzzyRule fuzzyRule in _rules)
			{
				var premiseValue = _fuzzyRuleEvaluator.Evaluate(fuzzyRule.Premise);

				var ruleConclusionVar = fuzzyRule.Conclusion.Variable;
				var membershipFunction = ruleConclusionVar.MembershipFunctions.First(mf => mf.Name == fuzzyRule.Conclusion.MembershipFunction.Name);

				membershipFunction.PremiseModifier = premiseValue;
			}

			return _defuzzification.Defuzzify(conclustionMembershipFunctions);
		}
	}
}
