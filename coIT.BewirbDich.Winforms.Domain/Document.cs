namespace coIT.BewirbDich.Winforms.Domain;
/// <summary>
/// Stellt ein Dokument der Versicherung dar.
/// </summary>
public class Document
{
    private Guid? _id;

    /// <summary>
    /// Der eindeutige Identifier des Dokuments.
    /// @Co-IT: Ich weiß, dass der Setter besser privat sein sollte, aber ich habe angesichts der Problematik
    /// mit der Deserialisierung leider keine bessere Lösung auf die Schnelle gefunden.
    /// </summary>
    public Guid? Id {
        get {
            if (_id == null)
                _id = Guid.NewGuid();
            return _id;
        } 
        set => _id = value; 
    }

    /// <summary>
    /// Die Art dieses Dokuments.
    /// </summary>
    public DocumentType DocumentType { get; set; }       

    /// <summary>
    /// Gibt an, ob der Versicherungsschein ausgestellt wurde.
    /// </summary>
    public bool InsuranceCertificateIssued { get; set; }    

    /// <summary>
    /// Erstellt eine neue Instanz dieser Klasse.
    /// </summary>
    protected Document() 
    {
    }
}