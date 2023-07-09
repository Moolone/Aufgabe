using System.ComponentModel;

namespace coIT.BewirbDich.Winforms.Domain;

/// <summary>
/// Spezifiziert die Berechnungsarten.
/// </summary>
public enum CalculationType
{
    [Description("Umsatz")]
    Turnover = 1,
    [Description("Haushaltssumme")]
    Budget = 2,
    [Description("Anzahl Mitarbeiter")]
    EmployeesCount = 3
}