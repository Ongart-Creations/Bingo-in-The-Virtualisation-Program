using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bingo
{
    public partial class BingoUpgrades : Form
    {
        BingoMainMenu menu;

        int oldWidth;
        int price = 0;

        int checkCount = 0;

        List<Upgrade> upgrades;

        public BingoUpgrades(BingoMainMenu instance)
        {
            InitializeComponent();

            this.menu = instance;

            upgrades = new List<Upgrade>()
            {
                new Upgrade("Beschützt Sie vor einem Bad Call (x1)", 8, "protection"),
                new Upgrade("Zeigt Ihnen die genannten Zahlen im Feld an", 55, "vision"),
                new Upgrade("Zeigt im Falle eines Bingos das Bingo an (nur ausgewählte Felder)", 30, "bingo"),
            };

            foreach (Upgrade upgrade in upgrades)
            {
                ListViewItem lstvtm = new ListViewItem();

                lstvtm.SubItems.Add(upgrade.Description);
                lstvtm.SubItems.Add(upgrade.Price.ToString());

                upgradesList.Items.Add(lstvtm);
            }

            oldWidth = this.Size.Width;

            MessageBox.Show("Update Log\n\nPatch 1.1.0.0\n-Reduced Price of Bad Call Upgrade from 12 to 8\n-Increased Price of Vision Upgrade from 35 to 55\n-Increased Price of Bingo Vision from 28 to 30");
        }

        private void BingoUpgrades_SizeChanged(object sender, EventArgs e)
        {
            int difference = this.Size.Width - oldWidth;
            upgradeDescColumn.Width += difference;

            oldWidth = this.Size.Width;
        }

        private void RefreshVisuals()
        {
            priceLbl.Text = price.ToString() + " Coins";
        }

        private void upgradesList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!(upgradesList.Items.Count <= checkCount))
            {
                checkCount++;  
                return;
            }

            if (e.Item.Checked)
            {
                price += upgrades[e.Item.Index].Price;
            }
            else if (!e.Item.Checked)
            {
                price -= upgrades[e.Item.Index].Price;
            }

            RefreshVisuals();
        }

        private void addUpgradesBtn_Click(object sender, EventArgs e)
        {
            if (price != 0)
            {
                if (MessageBox.Show("Möchten Sie die ausgewählten Upgrades für " + price + " Coins kaufen?\n\nHinweis: Alle Upgrades müssen nach jeder Runde neu gekauft werden.", "Upgrades kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (menu.coins >= price)
                    {
                        foreach (ListViewItem upgrade in upgradesList.CheckedItems)
                        {
                            if (AlreadyBought(upgrades[upgrade.Index].ID))
                            {
                                MessageBox.Show("Eines der ausgewählten Upgrades besitzen Sie bereits.\n\nVersuchen Sie es erneut, wenn Sie das Upgrade entfernt haben.", "Upgrade bereits in Besitz", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                menu.upgrades.Add(upgrades[upgrade.Index]);
                            }
                        }

                        menu.coins -= price;
                        menu.RefreshVisuals();
                        MessageBox.Show("Upgrades erfolgreich gekauft.", "Kauf erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sie haben nicht genügend Coins um die ausgewählten Upgrades zu kaufen.", "Nicht genügend Coins", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Kauf abgebrochen.", "Kauf fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Wählen Sie vorher Upgrades aus, die Sie kaufen möchten!", "Kauf fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool AlreadyBought(string checkID)
        {
            for (int i = 0; i < menu.upgrades.Count; i++)
            {
                if (menu.upgrades[i].ID == checkID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
