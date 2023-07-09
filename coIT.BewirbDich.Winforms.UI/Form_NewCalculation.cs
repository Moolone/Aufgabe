using coIT.BewirbDich.Winforms.Domain;

namespace coIT.BewirbDich.Winforms.UI
{
    /// <summary>
    /// Stellt das Formular für die Erstellung einer neuen Kalkulation dar.
    /// </summary>
    public partial class Form_NewCalculation : Form
    {
        /// <summary>
        /// Die Kalkulation, die hier erstellt wird. Dieses Feld sollte nur dann ausgewertet werden, 
        /// wenn der Dialog nicht abgebrochen wird.
        /// </summary>
        public Calculation Calculation { get; set; }

        /// <summary>
        /// Erstellt eine neue Instanz dieses Formulars.
        /// </summary>
        public Form_NewCalculation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bricht die Erstellung einer neuen Kalkulation ab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrl_Abbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Erstellt eine neue Kalkulation und führt die Berechnung durch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrl_Kalkuliere_Click(object sender, EventArgs e)
        {
            var calculation = CalculationFactory.Create(EnumHelper.GetValueByDescription<CalculationType>(ctrl_CalculationType.Text) ?? CalculationType.Turnover);
            calculation.DocumentType = DocumentType.Offer;
            calculation.Risk = EnumHelper.GetValueByDescription<Risk>(ctrl_Risk.Text) ?? Risk.Low;
            calculation.IncludeAdditionalProtection = ctrl_IncludeAdditionalProtection.Checked;
            if (float.TryParse(ctrl_AdditionalProtectionCharge.Text.Replace("%", string.Empty), out var zuschlag))
                calculation.AdditionalProtectionCharge = zuschlag;
            else
                calculation.AdditionalProtectionCharge = 0;
            calculation.HasWebshop = ctrl_HasWebshop.Checked;
            calculation.InsuranceSum = decimal.Parse(ctrl_InsuranceSum.Text);

            calculation.Calculate();

            Calculation = calculation;

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Wird ausgeführt, wenn das Formular geladen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_NewDocument_Load(object sender, EventArgs e)
        {            
            var calculationTypes = Enum.GetValues(typeof(CalculationType)) as int[];
            foreach(var value in calculationTypes)            
                ctrl_CalculationType.Items.Add(EnumHelper.GetDescription((CalculationType)value));
            
            var riskTypes = Enum.GetValues(typeof(Risk)) as int[];
            foreach (var value in riskTypes)
                ctrl_Risk.Items.Add(EnumHelper.GetDescription((Risk)value));
        }

        /// <summary>
        /// Zeigt das Feld für den Aufschlag des Zusatzschutzes an.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrl_IncludeAdditionalProtection_CheckedChanged(object sender, EventArgs e)
        {
            ctrl_AdditionalProtectionCharge.Visible = ctrl_IncludeAdditionalProtection.Checked;
        }
    }
}
