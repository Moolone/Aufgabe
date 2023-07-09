namespace coIT.BewirbDich.Winforms.Domain
{
    /// <summary>
    /// Stellt eine Kalkulation basierend auf dem Umsatz dar.
    /// </summary>
    public class TurnoverCalculation : Calculation
    {
        /// <summary>
        /// Erstellt eine neue Instanz dieser Klasse.
        /// </summary>
        public TurnoverCalculation() : base()
        {
            CalculationType = CalculationType.Turnover;
        }

        /// <summary>
        /// Führt die Kalkulation durch.
        /// </summary>
        public override void Calculate()
        {            
            //Versicherungsnehmer, die nach Umsatz abgerechnet werden, mehr als 100.000€ ausweisen und Lösegeld versichern, haben immer mittleres Risiko
            if (InsuranceSum > 100000m && IncludeAdditionalProtection)
                Risk = Risk.Average;

            CalculationBase = (decimal)Math.Pow((double)InsuranceSum, 0.25d);
            decimal contribution = 1.1m * CalculationBase;
            if (HasWebshop) //Webshop gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
                contribution *= 2;                   

            if (IncludeAdditionalProtection)
                contribution *= 1.0m + (decimal)AdditionalProtectionCharge / 100.0m;

            if (Risk == Risk.Average)
                 contribution *= 1.2m;

            CalculationBase = Math.Round(CalculationBase, 2);
            Contribution = Math.Round(contribution, 2);
        }
    }
}
