namespace FuzzyLogicController.Interfaces
{
    public interface IDefuzzification
    {
        double Defuzzify(List<IMembershipFunction> functions);
    }
}
