using System.ComponentModel;

namespace coIT.BewirbDich.Winforms.Domain;

/// <summary>
/// Spezifiziert die Risiken für die Versicherung.
/// </summary>
public enum Risk
{
    [Description("Gering")]
    Low = 1,
    [Description("Mittel")]
    Average = 2
}