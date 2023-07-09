namespace coIT.BewirbDich.Winforms.Domain
{
    /// <summary>
    /// Stellt eine Factory für Kalkulationen dar.
    /// </summary>
    public class CalculationFactory
    {
        /// <summary>
        /// Gibt entsprechend des angegebenen Typs die spezialisierte Kalkulationsinstanz zurück.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Calculation Create(CalculationType type)
        {
            switch(type)
            {
                case CalculationType.Budget:
                    return new BudgetCalculation();

                case CalculationType.Turnover:
                    return new TurnoverCalculation();

                case CalculationType.EmployeesCount:
                    return new EmployeesCountCalculation();

                default:
                    throw new ArgumentException("Ungültiger Typ.");

            }
        }
    }
}
