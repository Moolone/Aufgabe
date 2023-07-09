namespace coIT.BewirbDich.Winforms.UI
{
    partial class Form_NewCalculation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ctrl_CalculationType = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            ctrl_Risk = new ComboBox();
            ctrl_HasWebshop = new RadioButton();
            ctrl_InsuranceSum = new TextBox();
            label3 = new Label();
            ctrl_Calculate = new Button();
            ctrl_Cancel = new Button();
            ctrl_IncludeAdditionalProtection = new CheckBox();
            ctrl_AdditionalProtectionCharge = new ComboBox();
            SuspendLayout();
            // 
            // ctrl_CalculationType
            // 
            ctrl_CalculationType.FormattingEnabled = true;
            ctrl_CalculationType.Location = new Point(189, 16);
            ctrl_CalculationType.Margin = new Padding(3, 4, 3, 4);
            ctrl_CalculationType.Name = "ctrl_CalculationType";
            ctrl_CalculationType.Size = new Size(263, 28);
            ctrl_CalculationType.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 20);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 1;
            label1.Text = "Berechnungsart";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 80);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "Risiko";
            // 
            // ctrl_Risk
            // 
            ctrl_Risk.FormattingEnabled = true;
            ctrl_Risk.Location = new Point(189, 77);
            ctrl_Risk.Margin = new Padding(3, 4, 3, 4);
            ctrl_Risk.Name = "ctrl_Risk";
            ctrl_Risk.Size = new Size(263, 28);
            ctrl_Risk.TabIndex = 2;
            // 
            // ctrl_HasWebshop
            // 
            ctrl_HasWebshop.Appearance = Appearance.Button;
            ctrl_HasWebshop.Location = new Point(24, 236);
            ctrl_HasWebshop.Margin = new Padding(3, 4, 3, 4);
            ctrl_HasWebshop.Name = "ctrl_HasWebshop";
            ctrl_HasWebshop.Size = new Size(429, 63);
            ctrl_HasWebshop.TabIndex = 6;
            ctrl_HasWebshop.TabStop = true;
            ctrl_HasWebshop.Text = "Hat Webshop";
            ctrl_HasWebshop.TextAlign = ContentAlignment.MiddleCenter;
            ctrl_HasWebshop.UseVisualStyleBackColor = true;
            // 
            // ctrl_InsuranceSum
            // 
            ctrl_InsuranceSum.Location = new Point(189, 139);
            ctrl_InsuranceSum.Margin = new Padding(3, 4, 3, 4);
            ctrl_InsuranceSum.Name = "ctrl_InsuranceSum";
            ctrl_InsuranceSum.Size = new Size(263, 27);
            ctrl_InsuranceSum.TabIndex = 7;
            ctrl_InsuranceSum.Text = "100000";
            ctrl_InsuranceSum.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 143);
            label3.Name = "label3";
            label3.Size = new Size(147, 20);
            label3.TabIndex = 8;
            label3.Text = "Versicherungssumme";
            // 
            // ctrl_Calculate
            // 
            ctrl_Calculate.Location = new Point(249, 348);
            ctrl_Calculate.Margin = new Padding(3, 4, 3, 4);
            ctrl_Calculate.Name = "ctrl_Calculate";
            ctrl_Calculate.Size = new Size(203, 59);
            ctrl_Calculate.TabIndex = 9;
            ctrl_Calculate.Text = "Kalkulieren";
            ctrl_Calculate.UseVisualStyleBackColor = true;
            ctrl_Calculate.Click += ctrl_Calculate_Click;
            // 
            // ctrl_Cancel
            // 
            ctrl_Cancel.Location = new Point(24, 348);
            ctrl_Cancel.Margin = new Padding(3, 4, 3, 4);
            ctrl_Cancel.Name = "ctrl_Cancel";
            ctrl_Cancel.Size = new Size(203, 59);
            ctrl_Cancel.TabIndex = 10;
            ctrl_Cancel.Text = "Abbrechen";
            ctrl_Cancel.UseVisualStyleBackColor = true;
            ctrl_Cancel.Click += ctrl_Cancel_Click;
            // 
            // ctrl_IncludeAdditionalProtection
            // 
            ctrl_IncludeAdditionalProtection.AutoSize = true;
            ctrl_IncludeAdditionalProtection.Location = new Point(24, 203);
            ctrl_IncludeAdditionalProtection.Margin = new Padding(3, 4, 3, 4);
            ctrl_IncludeAdditionalProtection.Name = "ctrl_IncludeAdditionalProtection";
            ctrl_IncludeAdditionalProtection.Size = new Size(115, 24);
            ctrl_IncludeAdditionalProtection.TabIndex = 11;
            ctrl_IncludeAdditionalProtection.Text = "Zusatzschutz";
            ctrl_IncludeAdditionalProtection.UseVisualStyleBackColor = true;
            ctrl_IncludeAdditionalProtection.CheckedChanged += ctrl_IncludeAdditionalProtection_CheckedChanged;
            // 
            // ctrl_AdditionalProtectionCharge
            // 
            ctrl_AdditionalProtectionCharge.FormattingEnabled = true;
            ctrl_AdditionalProtectionCharge.Items.AddRange(new object[] { "10%", "20%", "25%" });
            ctrl_AdditionalProtectionCharge.Location = new Point(189, 197);
            ctrl_AdditionalProtectionCharge.Margin = new Padding(3, 4, 3, 4);
            ctrl_AdditionalProtectionCharge.Name = "ctrl_AdditionalProtectionCharge";
            ctrl_AdditionalProtectionCharge.Size = new Size(263, 28);
            ctrl_AdditionalProtectionCharge.TabIndex = 12;
            ctrl_AdditionalProtectionCharge.Visible = false;
            // 
            // Form_NeueKalkulation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 483);
            Controls.Add(ctrl_AdditionalProtectionCharge);
            Controls.Add(ctrl_IncludeAdditionalProtection);
            Controls.Add(ctrl_Cancel);
            Controls.Add(ctrl_Calculate);
            Controls.Add(label3);
            Controls.Add(ctrl_InsuranceSum);
            Controls.Add(ctrl_HasWebshop);
            Controls.Add(label2);
            Controls.Add(ctrl_Risk);
            Controls.Add(label1);
            Controls.Add(ctrl_CalculationType);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_NeueKalkulation";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Neue Kalkulation";
            Load += Form_NewDocument_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ctrl_CalculationType;
        private Label label1;
        private Label label2;
        private ComboBox ctrl_Risk;
        private RadioButton ctrl_HasWebshop;
        private TextBox ctrl_InsuranceSum;
        private Label label3;
        private Button ctrl_Calculate;
        private Button ctrl_Cancel;
        private CheckBox ctrl_IncludeAdditionalProtection;
        private ComboBox ctrl_AdditionalProtectionCharge;
    }
}