namespace coIT.BewirbDich.Winforms.Domain
{
    /// <summary>
    /// Stellt eine Kalkulation basierend auf der Haushaltssumme dar.
    /// </summary>
    public class BudgetCalculation : Calculation
    {
        /// <summary>
        /// Erstellt eine neue Instanz dieser Klasse.
        /// </summary>
        public BudgetCalculation() : base()
        {
            CalculationType = CalculationType.Budget;
        }

        /// <summary>
        /// Führt die Kalkulation durch.
        /// </summary>
        public override void Calculate()
        {
            //Versicherungsnehmer, die nach Haushaltssumme versichert werden (primär Vereine) stellen immer ein mittleres Risiko da            
            Risk = Risk.Average;                     
            
            CalculationBase = (decimal)Math.Log10((double)InsuranceSum);
            decimal contribution = 1.0m * CalculationBase + 100m;
            
            if (IncludeAdditionalProtection)
                contribution *= 1.0m + (decimal)AdditionalProtectionCharge / 100.0m;
            
            contribution *= 1.2m;

            CalculationBase = Math.Round(CalculationBase, 2);
            Contribution = Math.Round(contribution, 2);
        }
    }
}
