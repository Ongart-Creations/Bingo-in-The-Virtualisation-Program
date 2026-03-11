namespace Bingo
{
    partial class BingoUpgrades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BingoUpgrades));
            this.upgradesList = new System.Windows.Forms.ListView();
            this.addColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.upgradeDescColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.upgradeDescInfoLbl = new System.Windows.Forms.Label();
            this.priceInfoLbl = new System.Windows.Forms.Label();
            this.priceLbl = new System.Windows.Forms.Label();
            this.addUpgradesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // upgradesList
            // 
            this.upgradesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upgradesList.CheckBoxes = true;
            this.upgradesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.addColumn,
            this.upgradeDescColumn,
            this.priceColumn});
            this.upgradesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradesList.FullRowSelect = true;
            this.upgradesList.Location = new System.Drawing.Point(12, 45);
            this.upgradesList.MultiSelect = false;
            this.upgradesList.Name = "upgradesList";
            this.upgradesList.Size = new System.Drawing.Size(360, 347);
            this.upgradesList.TabIndex = 0;
            this.upgradesList.UseCompatibleStateImageBehavior = false;
            this.upgradesList.View = System.Windows.Forms.View.Details;
            this.upgradesList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.upgradesList_ItemChecked);
            // 
            // addColumn
            // 
            this.addColumn.Text = "";
            this.addColumn.Width = 23;
            // 
            // upgradeDescColumn
            // 
            this.upgradeDescColumn.Text = "Beschreibung";
            this.upgradeDescColumn.Width = 225;
            // 
            // priceColumn
            // 
            this.priceColumn.Text = "Preis (Coins)";
            this.priceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceColumn.Width = 83;
            // 
            // upgradeDescInfoLbl
            // 
            this.upgradeDescInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upgradeDescInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeDescInfoLbl.Location = new System.Drawing.Point(12, 18);
            this.upgradeDescInfoLbl.Name = "upgradeDescInfoLbl";
            this.upgradeDescInfoLbl.Size = new System.Drawing.Size(360, 24);
            this.upgradeDescInfoLbl.TabIndex = 1;
            this.upgradeDescInfoLbl.Text = "Verfügbare Upgrades:";
            // 
            // priceInfoLbl
            // 
            this.priceInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.priceInfoLbl.AutoSize = true;
            this.priceInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceInfoLbl.Location = new System.Drawing.Point(12, 399);
            this.priceInfoLbl.Name = "priceInfoLbl";
            this.priceInfoLbl.Size = new System.Drawing.Size(63, 24);
            this.priceInfoLbl.TabIndex = 2;
            this.priceInfoLbl.Text = "Preis:";
            // 
            // priceLbl
            // 
            this.priceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(81, 399);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(73, 24);
            this.priceLbl.TabIndex = 3;
            this.priceLbl.Text = "0 Coins";
            // 
            // addUpgradesBtn
            // 
            this.addUpgradesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addUpgradesBtn.Location = new System.Drawing.Point(239, 427);
            this.addUpgradesBtn.Name = "addUpgradesBtn";
            this.addUpgradesBtn.Size = new System.Drawing.Size(133, 32);
            this.addUpgradesBtn.TabIndex = 4;
            this.addUpgradesBtn.Text = "Hinzufügen";
            this.addUpgradesBtn.UseVisualStyleBackColor = true;
            this.addUpgradesBtn.Click += new System.EventHandler(this.addUpgradesBtn_Click);
            // 
            // BingoUpgrades
            // 
            this.AcceptButton = this.addUpgradesBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 471);
            this.Controls.Add(this.addUpgradesBtn);
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.priceInfoLbl);
            this.Controls.Add(this.upgradeDescInfoLbl);
            this.Controls.Add(this.upgradesList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 510);
            this.Name = "BingoUpgrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BingoUpgrades";
            this.SizeChanged += new System.EventHandler(this.BingoUpgrades_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView upgradesList;
        private System.Windows.Forms.ColumnHeader addColumn;
        private System.Windows.Forms.ColumnHeader upgradeDescColumn;
        private System.Windows.Forms.ColumnHeader priceColumn;
        private System.Windows.Forms.Label upgradeDescInfoLbl;
        private System.Windows.Forms.Label priceInfoLbl;
        private System.Windows.Forms.Label priceLbl;
        private System.Windows.Forms.Button addUpgradesBtn;
    }
}