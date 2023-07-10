namespace DomainTests;

/// <summary>
/// Absicherung der Domäne.
/// </summary>
[TestClass]
public class DomainTests
{
    [TestMethod]
    public void Factory_WithInvalidType_ShouldThrowArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {            
            var calc = CalculationFactory.Create((CalculationType)CalculationType.GetValues(typeof(int)).Length + 1);
        });        
    }

    [TestMethod]
    public void Factory_WithBudgetType_DeliverBudgetCalculation()
    {
        Assert.IsInstanceOfType(CalculationFactory.Create(CalculationType.Budget), typeof(BudgetCalculation));
    }

    [TestMethod]
    public void Factory_WithTurnoverType_DeliverTurnoverCalculation()
    {
        Assert.IsInstanceOfType(CalculationFactory.Create(CalculationType.Turnover), typeof(TurnoverCalculation));
    }

    [TestMethod]
    public void Factory_WithEmployeesCountType_DeliverBudgetCalculation()
    {
        Assert.IsInstanceOfType(CalculationFactory.Create(CalculationType.EmployeesCount), typeof(EmployeesCountCalculation));
    }

    [TestMethod]
    public void BudgetCalculation_Type_ShouldBeBudget()
    {
        Assert.AreEqual(CalculationFactory.Create(CalculationType.Budget).CalculationType, CalculationType.Budget);
    }

    [TestMethod]
    public void BudgetCalculation_Calculate_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.Budget);
        calc.InsuranceSum = 100;
        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Average);
        Assert.AreEqual(calc.CalculationBase, 2m);
        Assert.AreEqual(calc.Contribution, 122.4m);
    }

    [TestMethod]
    public void BudgetCalculation_CalculateWithAdditionalProtection_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.Budget);
        calc.InsuranceSum = 100;
        calc.IncludeAdditionalProtection = true;
        calc.AdditionalProtectionCharge = 15f;

        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Average);
        Assert.AreEqual(calc.CalculationBase, 2m);
        Assert.AreEqual(calc.Contribution, 140.76m);
    }

    [TestMethod]
    public void TurnoverCalculation_Type_ShouldBeTurnover()
    {
        Assert.AreEqual(CalculationFactory.Create(CalculationType.Turnover).CalculationType, CalculationType.Turnover);
    }

    [TestMethod]
    public void TurnoverCalculation_Calculate_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.Turnover);
        calc.InsuranceSum = 10000;
        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Low);
        Assert.AreEqual(calc.CalculationBase, 10m);
        Assert.AreEqual(calc.Contribution, 11);
    }

    [TestMethod]
    public void TurnoverCalculation_CalculateWithWebshop_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.Turnover);
        calc.InsuranceSum = 10000;
        calc.HasWebshop = true;
        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Low);
        Assert.AreEqual(calc.CalculationBase, 10m);
        Assert.AreEqual(calc.Contribution, 22m);
    }

    [TestMethod]
    public void TurnoverCalculation_CalculateWithAdditionalProtection_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.Turnover);
        calc.InsuranceSum = 1000000;
        calc.IncludeAdditionalProtection = true;
        calc.AdditionalProtectionCharge = 15f;
        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Average);
        Assert.AreEqual(calc.CalculationBase, 31.62m);
        Assert.AreEqual(calc.Contribution, 48.00m);
    }

    [TestMethod]
    public void EmployeesCountCalculation_Type_ShouldBeEmployeesCount()
    {
        Assert.AreEqual(CalculationFactory.Create(CalculationType.EmployeesCount).CalculationType, CalculationType.EmployeesCount);
    }

    [TestMethod]
    public void EmployeesCountCalculation_CalculateWithAdditionalProtection_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.EmployeesCount);
        calc.InsuranceSum = 1000;
        calc.IncludeAdditionalProtection = true;
        calc.AdditionalProtectionCharge = 15f;
        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Low);
        Assert.AreEqual(calc.CalculationBase, 1m);
        Assert.AreEqual(calc.Contribution, 287.5m);
    }

    [TestMethod]
    public void EmployeesCountCalculation_CalculateWithAdditionalProtectionHigherInsuranceSumAndAverageRisk_Result()
    {
        var calc = CalculationFactory.Create(CalculationType.EmployeesCount);
        calc.InsuranceSum = 10000;
        calc.IncludeAdditionalProtection = true;
        calc.AdditionalProtectionCharge = 15f;
        calc.Risk = Risk.Average;
        calc.Calculate();

        Assert.AreEqual(calc.Risk, Risk.Average);
        Assert.AreEqual(calc.CalculationBase, 10m);
        Assert.AreEqual(calc.Contribution, 2600m);
    }

    [TestMethod]
    public void Calculation_CalculateOnNonSpecificClass_ThrowsNotImplementedException()
    {
        var calc = new Calculation();
        Assert.ThrowsException<NotImplementedException>(() => calc.Calculate());
    }
}
