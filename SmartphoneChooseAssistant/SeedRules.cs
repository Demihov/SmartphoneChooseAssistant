using FuzzyLogicController.Extensions;
using FuzzyLogicController.Models;
using FuzzyLogicController.Rules;

namespace FuzzyLogicController
{
    public class SeedRules
    {
        // Set Up Linguistic Variables
        public LinguisticVariable Rom = new LinguisticVariable("Ram");
        public LinguisticVariable Camera = new LinguisticVariable("Camera");
        public LinguisticVariable Battery = new LinguisticVariable("Battery");
        public LinguisticVariable Price = new LinguisticVariable("Price");

        //Set Up Output Linguistic Variables
        public LinguisticVariable Output = new LinguisticVariable("Smartphone choiсe");
        public List<FuzzyRule> GetRulesBase()
        {
            //Ram
            var lowRam = Rom.MembershipFunctions.AddTrapezoid("Low Ram", 0, 0, 0.1, 0.12);
            var mediumRam = Rom.MembershipFunctions.AddTriangle("Medium Ram", 0.08, 0.15, 0.2);
            var manyRam = Rom.MembershipFunctions.AddTrapezoid("Many Ram", 0.1, 0.3, 0.4, 0.5);
            var aLotRam = Rom.MembershipFunctions.AddTrapezoid("A lot Ram", 0.5, 0.7, 1, 1);

            //Camera
            var badCamera = Camera.MembershipFunctions.AddTrapezoid("Low Camera", 0, 0, 0.2, 0.4);
            var goodCamera = Camera.MembershipFunctions.AddTriangle("Good Camera", 0.3, 0.5, 0.8);
            var excellentCamera = Camera.MembershipFunctions.AddTrapezoid("Excellent Camera", 0.7, 0.8, 1, 1);

            //Battery
            var lowBattery = Battery.MembershipFunctions.AddTrapezoid("Low Battery", 0, 0, 0.1, 0.4);
            var mediumBattery = Battery.MembershipFunctions.AddTriangle("Medium Battery", 0.3, 0.6, 0.7);
            var bigBattery = Battery.MembershipFunctions.AddTrapezoid("Big Battery", 0.5, 0.7, 1, 1);

            //Price
            var lowPrice = Price.MembershipFunctions.AddTrapezoid("Low Price", 0, 0, 0.03, 0.05);
            var mediumPrice = Price.MembershipFunctions.AddTrapezoid("Medium Price", 0.03, 0.06, 0.1, 0.15);
            var highPrice = Price.MembershipFunctions.AddTrapezoid("High Price", 0.1, 0.25, 0.35, 0.6);
            var extremlyHighPrice = Price.MembershipFunctions.AddTrapezoid("Extremly high Price", 0.4, 0.6, 1, 1);


            //Output smartphone choiсe
            var badOutput = Output.MembershipFunctions.AddTrapezoid("Bad choiсe", 0, 0, 0.1, 0.4);
            var suitableOutput = Output.MembershipFunctions.AddTriangle("Suitable choiсe", 0.3, 0.4, 0.6);
            var veryGoodOutput = Output.MembershipFunctions.AddTriangle("Very good choiсe", 0.5, 0.7, 0.8);
            var excellentOutput = Output.MembershipFunctions.AddTrapezoid("Excellent choiсe", 0.7, 0.8, 1, 1);

            return new List<FuzzyRule> {
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(badOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(badOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(badOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(badOutput)),



                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(badOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),



                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(veryGoodOutput)),
                Rule.If(Rom.Is(lowRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),




                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(veryGoodOutput)),
                Rule.If(Rom.Is(mediumRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),




                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(veryGoodOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(veryGoodOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),

                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(manyRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),




                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(badCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(suitableOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(goodCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(veryGoodOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(lowBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(veryGoodOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(highPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(mediumBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),

                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(lowPrice))).Then(Output.Is(suitableOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(mediumPrice))).Then(Output.Is(veryGoodOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(highPrice))).Then(Output.Is(excellentOutput)),
                Rule.If(Rom.Is(aLotRam).And(Camera.Is(excellentCamera)).And(Battery.Is(bigBattery)).And(Price.Is(extremlyHighPrice))).Then(Output.Is(excellentOutput)),
};
        }
    }
}
