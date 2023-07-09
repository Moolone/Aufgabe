using System.ComponentModel;

namespace coIT.BewirbDich.Winforms.Domain;

/// <summary>
/// Spezifiziert die Dokumenttypen.
/// </summary>
public enum DocumentType
{
    [Description("Angebot")]
    Offer = 1,
    [Description("Versicherungsschein")]
    InsuranceCertificate = 2
}