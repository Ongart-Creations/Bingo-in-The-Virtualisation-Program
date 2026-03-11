using System;
using System.Windows.Forms;
using TVP.Objects;
using TVP.v2;

namespace Bingo
{
    public partial class TheShop : Form
    {
        private int oldIndexCur1 = 1;
        private int oldIndexCur2 = 0;

        bool CheckForEqualValues = true;

        decimal transaction;

        BingoMainMenu menu;

        public TheShop(BingoMainMenu menu)
        {
            InitializeComponent();

            this.menu = menu;

            currency1Cbox.SelectedIndex = 1;
            currency2Cbox.SelectedIndex = 0;
        }

        bool EqualValues()
        {
            if (currency1Cbox.SelectedIndex == currency2Cbox.SelectedIndex && CheckForEqualValues)
            {
                MessageBox.Show("Sie können nicht die gleiche Währung handeln.", "Nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            return false;
        }

        void ChangeCboxStates()
        {
            switch (currency1Cbox.SelectedIndex)
            {
                case 1:
                    if (menu.user.Bank.Balance < 0)
                    {
                        currencyPriceSelectorUpDown.Maximum = 0;
                    }
                    else
                    {
                        currencyPriceSelectorUpDown.Maximum = menu.user.Bank.Balance;
                    }
                    currencyPriceSelectorUpDown.DecimalPlaces = 2;
                    currencyPriceSelectorUpDown.Increment = 0.25m;
                    break;

                case 0:
                    if (menu.coins < 0)
                    {
                        currencyPriceSelectorUpDown.Maximum = 0;
                    }
                    else
                    {
                        currencyPriceSelectorUpDown.Maximum = menu.coins;
                    }
                    currencyPriceSelectorUpDown.DecimalPlaces = 0;
                    currencyPriceSelectorUpDown.Increment = 1;
                    currencyPriceSelectorUpDown.Value = Math.Floor(currencyPriceSelectorUpDown.Value);
                    break;

                case 2:
                    if (menu.shards < 0)
                    {
                        currencyPriceSelectorUpDown.Maximum = 0;
                    }
                    else
                    {
                        currencyPriceSelectorUpDown.Maximum = menu.shards;
                    }
                    currencyPriceSelectorUpDown.DecimalPlaces = 0;
                    currencyPriceSelectorUpDown.Increment = 1;
                    currencyPriceSelectorUpDown.Value = Math.Floor(currencyPriceSelectorUpDown.Value);
                    break;
            }

            if (currency1Cbox.SelectedItem != null && currency2Cbox.SelectedItem != null)
            {
                Convertions convertions;

                Enum.TryParse(currency1Cbox.SelectedItem.ToString() + currency2Cbox.SelectedItem.ToString(), out convertions);

                string con = Converter(convertions);
                transaction = decimal.Parse(con);


                currencyConvertLbl.Text = currency1Cbox.SelectedItem.ToString() + " -> " + con + " " + currency2Cbox.SelectedItem.ToString();
                exchangeRateLbl.Text = Converter(convertions, true);
            }
        }

        private void currency1Cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCboxStates();

            if (EqualValues())
            {
                currency1Cbox.SelectedIndex = oldIndexCur1;
            }
            else
            {
                oldIndexCur1 = currency1Cbox.SelectedIndex;
            }
        }

        private void currency2Cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCboxStates();

            if (EqualValues())
            {
                currency2Cbox.SelectedIndex = oldIndexCur2;
            }
            else
            {
                oldIndexCur2 = currency2Cbox.SelectedIndex;
            }
        }

        private void switchCurrenciesBtn_Click(object sender, EventArgs e)
        {
            int index1 = currency1Cbox.SelectedIndex, index2 = currency2Cbox.SelectedIndex;

            CheckForEqualValues = false;
            currency1Cbox.SelectedIndex = index2;
            currency2Cbox.SelectedIndex = index1;
            CheckForEqualValues = true;
        }

        private string Converter(Convertions convert, bool exchangeRate = false)
        {
            switch (convert)
            {
                case Convertions.EuroCoins:

                    return exchangeRate ? (0.67356m).ToString() : (currencyPriceSelectorUpDown.Value * 0.67356m).ToString("0");

                case Convertions.ShardsCoins:

                    return exchangeRate ? (4.225m).ToString() : (currencyPriceSelectorUpDown.Value * 4.225m).ToString("0");

                case Convertions.ShardsEuro:

                    return exchangeRate ? (2.275m).ToString() : (currencyPriceSelectorUpDown.Value * 2.275m).ToString("0.00");
            }
            return decimal.MinusOne.ToString();
        }

        private enum Convertions
        {
            EuroCoins,
            ShardsCoins,
            ShardsEuro
        }

        private void currencyPriceSelectorUpDown_ValueChanged(object sender, EventArgs e)
        {
            ChangeCboxStates();
        }

        private void makeTransactionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Convertions transactionValid;

                menu.RefreshAccountBalance();

                //TVP.v1.UserInfo userInfo =
                //    new TVP.v1.UserInfo(menu.username, menu.password, menu.balance, menu.bank_long, menu.bank_short, menu.transgression);
                //TVP.v1.UserInfo userInfo = (TVP.v1.UserInfo)menu.user;
                TVP.Objects.UserInfo ui = menu.user;


                if (Enum.TryParse(currency1Cbox.SelectedItem.ToString() + currency2Cbox.SelectedItem.ToString(), out transactionValid))
                {
                    //menu.RefreshAccountBalance();

                    if (currencyPriceSelectorUpDown.Value <= 0)
                    {
                        MessageBox.Show("Wählen Sie vorher aus wie viel Sie handeln möchten.", "Transaktion fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //if (transactionValid == Convertions.EuroCoins && userInfo.Balance < currencyPriceSelectorUpDown.Value)
                    if (transactionValid == Convertions.EuroCoins && ui.Bank.Balance < currencyPriceSelectorUpDown.Value)
                    {
                        MessageBox.Show("Transaktion fehlgeschlagen.\n\nTransaktionen können nicht mehr als verfügbar berechnen.", "Transaktion fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (currencyPriceSelectorUpDown.Value > 2147483647)
                    {
                        MessageBox.Show("Diese Transaktion kann nicht durchgeführt werden.", "Transaktionsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    switch (transactionValid)
                    {
                        case Convertions.EuroCoins:
                            //if (TVP.v1.Transactions.Money(-currencyPriceSelectorUpDown.Value, userInfo))
                            AccountBalanceResult resultEC = TVP.Transactions.AccountBalanceEditor(-currencyPriceSelectorUpDown.Value, ref ui);
                            if (resultEC.Result == TVP.Enums.ABResult.Success)
                            {
                                menu.coins += int.Parse(transaction.ToString());
                                Succsssul();
                            }
                            else
                            {
                                NotSuccessful();
                            }
                            break;

                        case Convertions.ShardsCoins:
                            menu.coins += int.Parse(transaction.ToString());
                            menu.shards -= int.Parse(currencyPriceSelectorUpDown.Value.ToString());
                            Succsssul();
                            break;

                        case Convertions.ShardsEuro:
                            //if (TVP.v1.Transactions.Money(transaction, userInfo))
                            AccountBalanceResult resultSE = TVP.Transactions.AccountBalanceEditor(transaction, ref ui);
                            if (resultSE.Result == TVP.Enums.ABResult.Success)
                            {
                                menu.shards -= int.Parse(currencyPriceSelectorUpDown.Value.ToString());
                                Succsssul();
                            }
                            else
                            {
                                NotSuccessful();
                            }
                            break;
                    }

                    menu.RefreshAccountBalance();
                    ChangeCboxStates();
                }
                else
                {
                    MessageBox.Show("Transaktion kann nicht durchgeführt werden.\n\nGültige Konvertiervorlagen:\nEuro -> Coins\nShards -> Coins\nShards -> Euro", "Ungültige Konvertiervorlage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Bei der Transaktion ist ein Fehler aufgetreten.\n\nBei Geldverlust, melden Sie sich bitte beim Entwickler.", "Transaktionsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Succsssul()
        {
            MessageBox.Show("Transaktion erfolgreich ausgeführt.", "Transaktion erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void NotSuccessful()
        {
            MessageBox.Show("Transaktion konnte nicht erfolgreich durchgeführt werden.", "Transaktion nicht erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}