namespace FuzzyLogicController.MembershipFunctions
{
    public class TrapezoidMembershipFunction : BaseMembershipFunction
    {
        private double _a = 0;
        private double _b = 0;
        private double _c = 0;
        private double _d = 0;
        public TrapezoidMembershipFunction(string name, double a, double b, double c, double d)
            : base(name)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double A { get { return _a; } }
        public double B { get { return _b; } }
        public double C { get { return _c; } }
        public double D { get { return _d; } }

        public override double Fuzzify(double inputValue)
        {
            if (_a <= inputValue && inputValue < _b)
                return (inputValue - _a) / (_b - _a);

            else if (_b <= inputValue && inputValue <= _c)
                return 1;

            else if (_c < inputValue && inputValue <= _d)
                return (_d - inputValue) / (_d - _c);

            else
                return 0;
        }
    }
}
