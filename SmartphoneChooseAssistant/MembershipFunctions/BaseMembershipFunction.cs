using FuzzyLogicController.Interfaces;

namespace FuzzyLogicController.MembershipFunctions
{
	public abstract class BaseMembershipFunction : IMembershipFunction
	{
		public string Name { get; set; }

		public BaseMembershipFunction(string name)
		{
			Name = name;
		}

		private double _premiseModifier = 0;

		public double PremiseModifier
		{
			get
			{
				return _premiseModifier;
			}
			set
			{
				if (value > _premiseModifier)
					_premiseModifier = value;
			}
		}

		public abstract double Fuzzify(double inputValue);
	}
}
