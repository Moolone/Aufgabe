namespace coIT.BewirbDich.Winforms.Domain
{
    /// <summary>
    /// Stellt eine Kalkulation dar und bietet Methoden für dessen Berechnung.
    /// </summary>
    public class Calculation : Document
    {
        /// <summary>
        /// Erstellt eine neue Instanz dieser Klasse.
        /// </summary>
        public Calculation() : base()
        {
        }

        /// <summary>
        /// Gibt die Berechnungsart zurück, oder setzt sie.
        /// </summary>
        public CalculationType CalculationType { get; set; }

        /// <summary>
        /// Gibt die Berechnungsbasis zurück, oder setzt sie.
        /// Berechnungsart Umsatz => Jahresumsatz in Euro,
        /// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
        /// Berechnungsart AnzahlMitarbeiter => Ganzzahl
        /// </summary>
        public decimal CalculationBase { get; set; }

        /// <summary>
        /// Gibt den Risiko-Wert zurück, oder setzt ihn.
        /// </summary>
        public Risk Risk { get; set; }

        /// <summary>
        /// Gibt an, ob Zusatzschutz hinzugenommen weden soll, oder setzt diesen.
        /// </summary>
        public bool IncludeAdditionalProtection { get; set; }

        /// <summary>
        /// Gibt den Aufschlag für den Zusatzschutz zurück, oder setzt ihn.
        /// </summary>
        public float AdditionalProtectionCharge { get; set; }

        /// <summary>
        /// Gibt den Versicherungsbeitrag zurück, oder setzt ihn.
        /// </summary>
        public decimal Contribution { get; set; }

        /// <summary>
        /// Gibt die Versicherungssumme zurück, oder setzt sie.
        /// </summary>
        public decimal InsuranceSum { get; set; }

        /// <summary>
        /// Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden.
        /// </summary>
        public bool HasWebshop { get; set; }

        /// <summary>
        /// Führt die Berechnung durch.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual void Calculate()
        {
            throw new NotImplementedException("Bitte eine der spezialisierten Kalkulationen verwenden.");
        }

    }
}
