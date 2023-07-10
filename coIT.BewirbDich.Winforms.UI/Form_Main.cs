using coIT.BewirbDich.Winforms.Domain;
using coIT.BewirbDich.Winforms.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace coIT.BewirbDich.Winforms.UI;

/// <summary>
/// Stellt die Hauptansicht dar.
/// </summary>
public partial class Form_Main : Form
{
    private readonly IRepository<Calculation> _repo;

    private BindingSource _calculations;

    /// <summary>
    /// Erstellt eine neue Instanz dieser Klasse und lädt den erforderlichen Datenbestand.
    /// </summary>
    /// <param name="repo">Per DI bereitgestellte Schnittstelle zur Datenbank.</param>
    public Form_Main(IRepository<Calculation> repo)
    {
        InitializeComponent();
        _repo = repo; 
    }

    /// <summary>
    /// Öffnet den Dialog für das Erstellen einer neuen Kalkulation und fügt die neue Kalkulation der Liste hinzu,
    /// wenn nicht abgebrochen wird.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctr_NewCalculation_Click(object sender, EventArgs e)
    {
        using(var newCalculationForm = Program.ServiceProvider.GetRequiredService<Form_NewCalculation>())
        {
            var dialog = newCalculationForm.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                _repo.Add(newCalculationForm.Calculation);
                _calculations.ResetBindings(false);
            }
        }
    }

    /// <summary>
    /// Speichert alle Einträge.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctrl_Save_Click(object sender, EventArgs e)
    {
        _repo.Save();
        MessageBox.Show("Daten gespeichert.", "Vorgang", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Führt Aktualisierungen an der Oberfläche durch, wenn sich die Auswahl geändert hat.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctrl_CalculationsList_SelectionChanged(object sender, EventArgs e)
    {
        // Hier werden einfach nur die Optionen aktualisiert, wenn eine Zeile ausgewählt ist.
        UseSelectedCalculation(calc =>
        {
        });
    }

    /// <summary>
    /// Zeigt die Optionen abhängig vom Dokumenttyp an.
    /// </summary>
    /// <param name="calculation">Die ausgewählte Kalkulation.</param>
    /// <exception cref="InvalidDataException">Wird bei unbekannten Dokumenttyp ausgelöst.</exception>
    private void OptionenAnzeigen(Calculation calculation)
    {
        ctrl_IssueInsuranceCertificate.Enabled = false;
        ctrl_AngebotAnnehmen.Enabled = false;

        switch (calculation.DocumentType)
        {
            case DocumentType.Offer:
                ctrl_AngebotAnnehmen.Enabled = true;
                break;
            case DocumentType.InsuranceCertificate:
                if (!calculation.InsuranceCertificateIssued)
                    ctrl_IssueInsuranceCertificate.Enabled = true;
                break;
            default: throw new InvalidDataException("Unbekannter Dokumenttyp");
        }
    }

    /// <summary>
    /// Nimmt das ausgewählte Angebot an.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctrl_AcceptOffer_Click(object sender, EventArgs e)
    {
        UseSelectedCalculation(calc =>
        {
            calc.DocumentType = DocumentType.InsuranceCertificate;
            _calculations.ResetBindings(false);
        });
    }

    /// <summary>
    /// Stellt ein Versicherungsschein für die ausgewählte Kalkulation aus.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctrl_IssueInsuranceCertificate_Click(object sender, EventArgs e)
    {
        UseSelectedCalculation(calc =>
        {
            calc.InsuranceCertificateIssued = true;
            MessageBox.Show("Der Versicherungsschein wurde an den Versicherungsnehmer verschickt.", "Vorgang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        });
    }

    /// <summary>
    /// Führt die angegebene Action aus, nachdem vorher erfolgreich die ausgewählte Kalkulation gelesen wurde.
    /// </summary>
    /// <param name="action">Die Action.</param>
    /// <param name="showOptions">Gibt an, ob die Optionen nach der Ausführung der Action angezeigt werden sollen.</param>
    private void UseSelectedCalculation(Action<Document> action, bool showOptions = true)
    {
        var calculation = ReadSelection();
        if (calculation == null)
            return;

        action?.Invoke(calculation);
        if (showOptions)
            try {
                OptionenAnzeigen(calculation);
            }
            catch (InvalidDataException ex) {
                MessageBox.Show(ex.Message, "Ein Fehler ist aufgetreten.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

    /// <summary>
    /// Liest die ausgewählte Zeile und gibt die Kalkulation zurück.
    /// </summary>
    /// <returns>Die Kalkulation.</returns>
    private Calculation? ReadSelection()
    {
        var rowsCount = ctrl_CalculationsList.SelectedRows.Count;
        if (rowsCount == 0 || rowsCount > 1) return null;

        var calculation = ctrl_CalculationsList.SelectedRows[0];

        return calculation == null ? null : (Calculation)calculation.DataBoundItem;
    }

    /// <summary>
    /// Wird aufgerufen, wenn das Formular geladen wird. 
    /// Lädt die Liste mit den Kalkulationen und stellt sie in der DataGridView dar.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form_Main_Load(object sender, EventArgs e)
    {
        _calculations = new BindingSource
        {
            DataSource = _repo.ToList()
        };

        var list = ctrl_CalculationsList;
        list.DataSource = _calculations;

        var i = 0;
        ConfigureColumn(list.Columns[nameof(Calculation.Id)], "Id", false, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.DocumentType)], "Typ", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.CalculationType)], "Berechnungsart", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.CalculationBase)], "Berechnungsbasis", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.IncludeAdditionalProtection)], "Zusatzschutz", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.AdditionalProtectionCharge)], "Zusatzschutzaufschlag", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.HasWebshop)], "Hat Webshop", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.Risk)], "Risiko", true, i++) ;
        ConfigureColumn(list.Columns[nameof(Calculation.Contribution)], "Beitrag", true, i++, "c") ;
        ConfigureColumn(list.Columns[nameof(Calculation.InsuranceCertificateIssued)], "Versicherungsschein ausgestellt", true, i++);
        ConfigureColumn(list.Columns[nameof(Calculation.InsuranceSum)], "Versicherungssumme", true, i++, "c") ;

        ctrl_CalculationsList.ColumnHeadersVisible = true;
        ctrl_CalculationsList.AutoGenerateColumns = true;
        ctrl_CalculationsList.AutoResizeColumns();
        ctrl_CalculationsList.AutoSize = true;

        _calculations.ResetBindings(false);
    }

    /// <summary>
    /// Konfiguriert eine Spalte in <see cref="DataGridView"/>.
    /// </summary>
    /// <param name="column">Die Spalte.</param>
    /// <param name="headerText">Die Spaltenüberschrift.</param>
    /// <param name="isVisible">Gibt an, ob die Spalte sichtbar sein soll.</param>
    /// <param name="index">Spaltenreihenfolge.</param>
    /// <param name="format">Anzeigeformat.</param>
    private void ConfigureColumn(DataGridViewColumn? column, string headerText, bool isVisible = true, int? index = null, string? format = null)
    {
        if (column == null) return;

        column.HeaderText = headerText;
        column.Visible = isVisible;

        if (!string.IsNullOrEmpty(format)) 
            column.DefaultCellStyle.Format = format;

        if (index.HasValue)
            column.DisplayIndex = index.Value;
    }
}