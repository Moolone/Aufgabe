namespace coIT.BewirbDich.Winforms.Domain
{
    /// <summary>
    /// Stellt eine Kalkulation basierend auf der Anzahl der Mitarbeiter dar.
    /// </summary>
    public class EmployeesCountCalculation : Calculation
    {
        /// <summary>
        /// Erstellt eine neue Instanz dieser Klasse.
        /// </summary>
        public EmployeesCountCalculation() : base()
        {
            CalculationType = CalculationType.EmployeesCount;
        }

        /// <summary>
        /// Führt die Kalkulation durch.
        /// </summary>
        public override void Calculate()
        {
            //Versicherungsnehmer, die nach Anzahl Mitarbeiter abgerechnet werden und mehr als 5 Mitarbeiter haben, können kein Lösegeld absichern
            if (CalculationBase > 5)
            {
                IncludeAdditionalProtection = false;
                AdditionalProtectionCharge = 0;
            }

            decimal contribution;
            CalculationBase = InsuranceSum / 1000;

            if (CalculationBase < 4)
                contribution = CalculationBase * 250m;
            else
                contribution = CalculationBase * 200m;                  

            if (IncludeAdditionalProtection)
                contribution *= 1.0m + (decimal)AdditionalProtectionCharge / 100.0m;

            if (Risk == Risk.Average)
                contribution *= 1.3m;

            CalculationBase = Math.Round(CalculationBase, 2);
            Contribution = Math.Round(contribution, 2);
        }
    }
}
