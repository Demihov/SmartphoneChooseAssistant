namespace FuzzyLogicController.Interfaces
{
    public interface IMembershipFunction
    {
        string Name { get; set; }
        double Fuzzify(double inputValue);
        double PremiseModifier { get; set; }
    }
}
