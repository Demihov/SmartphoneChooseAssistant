namespace FuzzyLogicController.Models
{
    public class LinguisticVariable
    {
        public string Name { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public double inputValue;

        public double InputValue
        {
            get { return inputValue; }

            //Normalization
            set
            {
                inputValue = (value - Min) / (Max - Min);
            }
        }

        public MembershipFunctionCollection MembershipFunctions { get; set; }

        public LinguisticVariable(string name)
        {
            MembershipFunctions = new MembershipFunctionCollection();
            Name = name;
        }
    }
}
