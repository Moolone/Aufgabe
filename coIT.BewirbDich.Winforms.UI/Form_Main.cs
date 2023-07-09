using coIT.BewirbDich.Winforms.Domain;
using coIT.BewirbDich.Winforms.Infrastructure;

namespace coIT.BewirbDich.Winforms.UI;

/// <summary>
/// Stellt die Hauptansicht dar.
/// </summary>
public partial class Form_Main : Form
{
    private readonly IRepository<Calculation> _repo;

    private BindingSource _calculations;

    /// <summary>
    /// Erstellt eine neue Instanz dieser Klasse und l�dt den erforderlichen Datenbestand.
    /// </summary>
    public Form_Main()
    {
        InitializeComponent();
        _repo = new JsonRepository<Calculation>("database.json");
    }

    /// <summary>
    /// �ffnet den Dialog f�r das Erstellen einer neuen Kalkulation und f�gt die neue Kalkulation der Liste hinzu,
    /// wenn nicht abgebrochen wird.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctr_NewCalculation_Click(object sender, EventArgs e)
    {
        var newCalculationForm = new Form_NewCalculation();

        var dialog = newCalculationForm.ShowDialog();
        if (dialog == DialogResult.OK)
        {
            _repo.Add(newCalculationForm.Calculation);
            _calculations.ResetBindings(false);
        }

    }

    /// <summary>
    /// Speichert alle Eintr�ge.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctrl_Save_Click(object sender, EventArgs e)
    {
        _repo.Save();
        MessageBox.Show("Daten gespeichert.", "Vorgang", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// F�hrt Aktualisierungen an der Oberfl�che durch, wenn sich die Auswahl ge�ndert hat.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ctrl_CalculationsList_SelectionChanged(object sender, EventArgs e)
    {
        // Hier werden einfach nur die Optionen aktualisiert, wenn eine Zeile ausgew�hlt ist.
        UseSelectedCalculation(calc =>
        {
        });
    }

    /// <summary>
    /// Zeigt die Optionen abh�ngig vom Dokumenttyp an.
    /// </summary>
    /// <param name="calculation">Die ausgew�hlte Kalkulation.</param>
    /// <exception cref="InvalidDataException">Wird bei unbekannten Dokumenttyp ausgel�st.</exception>
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
    /// Nimmt das ausgew�hlte Angebot an.
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
    /// Stellt ein Versicherungsschein f�r die ausgew�hlte Kalkulation aus.
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
    /// F�hrt die angegebene Action aus, nachdem vorher erfolgreich die ausgew�hlte Kalkulation gelesen wurde.
    /// </summary>
    /// <param name="action">Die Action.</param>
    /// <param name="showOptions">Gibt an, ob die Optionen nach der Ausf�hrung der Action angezeigt werden sollen.</param>
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
    /// Liest die ausgew�hlte Zeile und gibt die Kalkulation zur�ck.
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
    /// L�dt die Liste mit den Kalkulationen und stellt sie in der DataGridView dar.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form_Main_Load(object sender, EventArgs e)
    {
        _calculations = new BindingSource
        {
            DataSource = _repo.ToList()
        };

        ctrl_CalculationsList.DataSource = _calculations;

        ctrl_CalculationsList.ColumnHeadersVisible = true;
        ctrl_CalculationsList.AutoGenerateColumns = true;
        ctrl_CalculationsList.Columns[nameof(Calculation.Id)].Visible = false;
        ctrl_CalculationsList.Columns[nameof(Calculation.Contribution)].DefaultCellStyle.Format = "c";
        ctrl_CalculationsList.Columns[nameof(Calculation.InsuranceSum)].DefaultCellStyle.Format = "c";
        ctrl_CalculationsList.AutoResizeColumns();
        ctrl_CalculationsList.AutoSize = true;

        _calculations.ResetBindings(false);
    }
}