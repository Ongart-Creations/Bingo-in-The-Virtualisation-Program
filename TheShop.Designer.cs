namespace Bingo
{
    partial class TheShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheShop));
            this.converterPanel = new System.Windows.Forms.Panel();
            this.switchCurrenciesBtn = new System.Windows.Forms.Button();
            this.toConvertInfoLbl = new System.Windows.Forms.Label();
            this.converterInfoLbl = new System.Windows.Forms.Label();
            this.currency1Cbox = new System.Windows.Forms.ComboBox();
            this.currency2Cbox = new System.Windows.Forms.ComboBox();
            this.shopPanel = new System.Windows.Forms.Panel();
            this.exchangeRateLbl = new System.Windows.Forms.Label();
            this.exchangeRateInfoLbl = new System.Windows.Forms.Label();
            this.makeTransactionBtn = new System.Windows.Forms.Button();
            this.currencyConvertLbl = new System.Windows.Forms.Label();
            this.currencyPriceSelectorUpDown = new System.Windows.Forms.NumericUpDown();
            this.converterPanel.SuspendLayout();
            this.shopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currencyPriceSelectorUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // converterPanel
            // 
            this.converterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.converterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.converterPanel.Controls.Add(this.switchCurrenciesBtn);
            this.converterPanel.Controls.Add(this.toConvertInfoLbl);
            this.converterPanel.Controls.Add(this.converterInfoLbl);
            this.converterPanel.Controls.Add(this.currency1Cbox);
            this.converterPanel.Controls.Add(this.currency2Cbox);
            this.converterPanel.Location = new System.Drawing.Point(12, 12);
            this.converterPanel.Name = "converterPanel";
            this.converterPanel.Size = new System.Drawing.Size(534, 57);
            this.converterPanel.TabIndex = 0;
            // 
            // switchCurrenciesBtn
            // 
            this.switchCurrenciesBtn.Location = new System.Drawing.Point(418, 11);
            this.switchCurrenciesBtn.Name = "switchCurrenciesBtn";
            this.switchCurrenciesBtn.Size = new System.Drawing.Size(106, 32);
            this.switchCurrenciesBtn.TabIndex = 4;
            this.switchCurrenciesBtn.Text = "Tauschen";
            this.switchCurrenciesBtn.UseVisualStyleBackColor = true;
            this.switchCurrenciesBtn.Click += new System.EventHandler(this.switchCurrenciesBtn_Click);
            // 
            // toConvertInfoLbl
            // 
            this.toConvertInfoLbl.AutoSize = true;
            this.toConvertInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toConvertInfoLbl.Location = new System.Drawing.Point(278, 15);
            this.toConvertInfoLbl.Name = "toConvertInfoLbl";
            this.toConvertInfoLbl.Size = new System.Drawing.Size(32, 24);
            this.toConvertInfoLbl.TabIndex = 2;
            this.toConvertInfoLbl.Text = "zu";
            // 
            // converterInfoLbl
            // 
            this.converterInfoLbl.AutoSize = true;
            this.converterInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.converterInfoLbl.Location = new System.Drawing.Point(13, 15);
            this.converterInfoLbl.Name = "converterInfoLbl";
            this.converterInfoLbl.Size = new System.Drawing.Size(157, 24);
            this.converterInfoLbl.TabIndex = 0;
            this.converterInfoLbl.Text = "Konvertiere von";
            // 
            // currency1Cbox
            // 
            this.currency1Cbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currency1Cbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currency1Cbox.FormattingEnabled = true;
            this.currency1Cbox.Items.AddRange(new object[] {
            "Coins",
            "Euro",
            "Shards"});
            this.currency1Cbox.Location = new System.Drawing.Point(176, 11);
            this.currency1Cbox.Name = "currency1Cbox";
            this.currency1Cbox.Size = new System.Drawing.Size(96, 32);
            this.currency1Cbox.TabIndex = 1;
            this.currency1Cbox.SelectedIndexChanged += new System.EventHandler(this.currency1Cbox_SelectedIndexChanged);
            // 
            // currency2Cbox
            // 
            this.currency2Cbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currency2Cbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currency2Cbox.FormattingEnabled = true;
            this.currency2Cbox.Items.AddRange(new object[] {
            "Coins",
            "Euro",
            "Shards"});
            this.currency2Cbox.Location = new System.Drawing.Point(316, 12);
            this.currency2Cbox.Name = "currency2Cbox";
            this.currency2Cbox.Size = new System.Drawing.Size(96, 32);
            this.currency2Cbox.TabIndex = 2;
            this.currency2Cbox.SelectedIndexChanged += new System.EventHandler(this.currency2Cbox_SelectedIndexChanged);
            // 
            // shopPanel
            // 
            this.shopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shopPanel.Controls.Add(this.exchangeRateLbl);
            this.shopPanel.Controls.Add(this.exchangeRateInfoLbl);
            this.shopPanel.Controls.Add(this.makeTransactionBtn);
            this.shopPanel.Controls.Add(this.currencyConvertLbl);
            this.shopPanel.Controls.Add(this.currencyPriceSelectorUpDown);
            this.shopPanel.Location = new System.Drawing.Point(12, 87);
            this.shopPanel.Name = "shopPanel";
            this.shopPanel.Size = new System.Drawing.Size(534, 102);
            this.shopPanel.TabIndex = 1;
            // 
            // exchangeRateLbl
            // 
            this.exchangeRateLbl.Location = new System.Drawing.Point(145, 69);
            this.exchangeRateLbl.Name = "exchangeRateLbl";
            this.exchangeRateLbl.Size = new System.Drawing.Size(119, 24);
            this.exchangeRateLbl.TabIndex = 4;
            this.exchangeRateLbl.Text = "exchange";
            // 
            // exchangeRateInfoLbl
            // 
            this.exchangeRateInfoLbl.AutoSize = true;
            this.exchangeRateInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeRateInfoLbl.Location = new System.Drawing.Point(3, 69);
            this.exchangeRateInfoLbl.Name = "exchangeRateInfoLbl";
            this.exchangeRateInfoLbl.Size = new System.Drawing.Size(136, 24);
            this.exchangeRateInfoLbl.TabIndex = 3;
            this.exchangeRateInfoLbl.Text = "Wechselkurs:";
            // 
            // makeTransactionBtn
            // 
            this.makeTransactionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.makeTransactionBtn.Location = new System.Drawing.Point(270, 65);
            this.makeTransactionBtn.Name = "makeTransactionBtn";
            this.makeTransactionBtn.Size = new System.Drawing.Size(259, 32);
            this.makeTransactionBtn.TabIndex = 2;
            this.makeTransactionBtn.Text = "Transaktion durchführen";
            this.makeTransactionBtn.UseVisualStyleBackColor = true;
            this.makeTransactionBtn.Click += new System.EventHandler(this.makeTransactionBtn_Click);
            // 
            // currencyConvertLbl
            // 
            this.currencyConvertLbl.AutoSize = true;
            this.currencyConvertLbl.Location = new System.Drawing.Point(119, 15);
            this.currencyConvertLbl.Name = "currencyConvertLbl";
            this.currencyConvertLbl.Size = new System.Drawing.Size(195, 24);
            this.currencyConvertLbl.TabIndex = 1;
            this.currencyConvertLbl.Text = "currency -> currency2";
            // 
            // currencyPriceSelectorUpDown
            // 
            this.currencyPriceSelectorUpDown.DecimalPlaces = 2;
            this.currencyPriceSelectorUpDown.Location = new System.Drawing.Point(3, 13);
            this.currencyPriceSelectorUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.currencyPriceSelectorUpDown.Name = "currencyPriceSelectorUpDown";
            this.currencyPriceSelectorUpDown.Size = new System.Drawing.Size(110, 29);
            this.currencyPriceSelectorUpDown.TabIndex = 0;
            this.currencyPriceSelectorUpDown.ValueChanged += new System.EventHandler(this.currencyPriceSelectorUpDown_ValueChanged);
            // 
            // TheShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 201);
            this.Controls.Add(this.shopPanel);
            this.Controls.Add(this.converterPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TheShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop";
            this.converterPanel.ResumeLayout(false);
            this.converterPanel.PerformLayout();
            this.shopPanel.ResumeLayout(false);
            this.shopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currencyPriceSelectorUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel converterPanel;
        private System.Windows.Forms.Button switchCurrenciesBtn;
        private System.Windows.Forms.Label toConvertInfoLbl;
        private System.Windows.Forms.Label converterInfoLbl;
        private System.Windows.Forms.ComboBox currency1Cbox;
        private System.Windows.Forms.ComboBox currency2Cbox;
        private System.Windows.Forms.Panel shopPanel;
        private System.Windows.Forms.Button makeTransactionBtn;
        private System.Windows.Forms.Label currencyConvertLbl;
        private System.Windows.Forms.NumericUpDown currencyPriceSelectorUpDown;
        private System.Windows.Forms.Label exchangeRateLbl;
        private System.Windows.Forms.Label exchangeRateInfoLbl;
    }
}