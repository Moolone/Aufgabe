namespace coIT.BewirbDich.Winforms.UI;

partial class Form_Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ctr_NeueKalkulation = new Button();
        ctrl_CalculationsList = new DataGridView();
        ctrl_Speichern = new Button();
        ctrl_AngebotAnnehmen = new Button();
        ctrl_IssueInsuranceCertificate = new Button();
        ((System.ComponentModel.ISupportInitialize)ctrl_CalculationsList).BeginInit();
        SuspendLayout();
        // 
        // ctr_NeueKalkulation
        // 
        ctr_NeueKalkulation.Location = new Point(14, 16);
        ctr_NeueKalkulation.Margin = new Padding(3, 4, 3, 4);
        ctr_NeueKalkulation.Name = "ctr_NeueKalkulation";
        ctr_NeueKalkulation.Size = new Size(86, 55);
        ctr_NeueKalkulation.TabIndex = 0;
        ctr_NeueKalkulation.Text = "+ NEU";
        ctr_NeueKalkulation.UseVisualStyleBackColor = true;
        ctr_NeueKalkulation.Click += ctr_NewCalculation_Click;
        // 
        // ctrl_CalculationsList
        // 
        ctrl_CalculationsList.AllowUserToAddRows = false;
        ctrl_CalculationsList.AllowUserToOrderColumns = true;
        ctrl_CalculationsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ctrl_CalculationsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        ctrl_CalculationsList.Location = new Point(14, 105);
        ctrl_CalculationsList.Margin = new Padding(3, 4, 3, 4);
        ctrl_CalculationsList.Name = "ctrl_CalculationsList";
        ctrl_CalculationsList.RowHeadersWidth = 51;
        ctrl_CalculationsList.RowTemplate.Height = 25;
        ctrl_CalculationsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        ctrl_CalculationsList.Size = new Size(1353, 479);
        ctrl_CalculationsList.TabIndex = 1;
        ctrl_CalculationsList.SelectionChanged += ctrl_CalculationsList_SelectionChanged;
        // 
        // ctrl_Speichern
        // 
        ctrl_Speichern.Location = new Point(1270, 16);
        ctrl_Speichern.Margin = new Padding(3, 4, 3, 4);
        ctrl_Speichern.Name = "ctrl_Speichern";
        ctrl_Speichern.Size = new Size(86, 55);
        ctrl_Speichern.TabIndex = 2;
        ctrl_Speichern.Text = "Speichern";
        ctrl_Speichern.UseVisualStyleBackColor = true;
        ctrl_Speichern.Click += ctrl_Save_Click;
        // 
        // ctrl_AngebotAnnehmen
        // 
        ctrl_AngebotAnnehmen.Enabled = false;
        ctrl_AngebotAnnehmen.Location = new Point(106, 16);
        ctrl_AngebotAnnehmen.Margin = new Padding(3, 4, 3, 4);
        ctrl_AngebotAnnehmen.Name = "ctrl_AngebotAnnehmen";
        ctrl_AngebotAnnehmen.Size = new Size(107, 55);
        ctrl_AngebotAnnehmen.TabIndex = 3;
        ctrl_AngebotAnnehmen.Text = "Annehmen 👍";
        ctrl_AngebotAnnehmen.UseVisualStyleBackColor = true;
        ctrl_AngebotAnnehmen.Click += ctrl_AcceptOffer_Click;
        // 
        // ctrl_IssueInsuranceCertificate
        // 
        ctrl_IssueInsuranceCertificate.Enabled = false;
        ctrl_IssueInsuranceCertificate.Location = new Point(221, 16);
        ctrl_IssueInsuranceCertificate.Margin = new Padding(3, 4, 3, 4);
        ctrl_IssueInsuranceCertificate.Name = "ctrl_IssueInsuranceCertificate";
        ctrl_IssueInsuranceCertificate.Size = new Size(107, 55);
        ctrl_IssueInsuranceCertificate.TabIndex = 4;
        ctrl_IssueInsuranceCertificate.Text = "Ausstellen 🖨";
        ctrl_IssueInsuranceCertificate.UseVisualStyleBackColor = true;
        ctrl_IssueInsuranceCertificate.Click += ctrl_IssueInsuranceCertificate_Click;
        // 
        // Form_Main
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1381, 600);
        Controls.Add(ctrl_IssueInsuranceCertificate);
        Controls.Add(ctrl_AngebotAnnehmen);
        Controls.Add(ctrl_Speichern);
        Controls.Add(ctrl_CalculationsList);
        Controls.Add(ctr_NeueKalkulation);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form_Main";
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Versicherungsdokumente";
        Load += Form_Main_Load;
        ((System.ComponentModel.ISupportInitialize)ctrl_CalculationsList).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button ctr_NeueKalkulation;
    private DataGridView ctrl_CalculationsList;
    private Button ctrl_Speichern;
    private Button ctrl_AngebotAnnehmen;
    private Button ctrl_IssueInsuranceCertificate;
}