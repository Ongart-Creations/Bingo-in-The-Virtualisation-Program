using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using TVP.Objects;
using TVP.v4;
using static TVP.v4.Functions;

namespace Bingo
{
    public partial class BingoMainMenu : Form
    {
        public int coins = 0;
        public long shards = 0;

        private int selCards = 1;
        private int minCards = 1;
        private int maxCards = 8;
        private int cardPrice = 0;

        private decimal basePrice = 22m;
        private bool IsError = false;


        public List<Upgrade> upgrades = new List<Upgrade>();

        public UserInfo user;

        public BingoMainMenu()
        {
            InitializeComponent();

            if (Environment.GetCommandLineArgs().Length > 0 && System.Diagnostics.Debugger.IsAttached)
            {
                foreach (string args in Environment.GetCommandLineArgs())
                {
                    if (args == "-debugcoins")
                    {
                        coins += 10000;
                    }
                    if (args == "-debugshards")
                    {
                        shards += 100;
                    }
                }
            }

            cardPrice = int.Parse(basePrice.ToString());

            Login();
        }

        void Login()
        {
            user = LoginToBank(this.Icon);

            if (user == null)
            {
                Environment.Exit(0);
            }

            IsError = false;

            RefreshVisuals();
        }

        public void RefreshVisuals()
        {
            if (!IsError)
            {
                bankLbl.Text = user.Bank.BankName;
                userLbl.Text = user.Username;
                accountstateLbl.Text = user.Bank.Balance + " €";
            }

            yourCoinsLbl.Text = coins.ToString();
            yourShardsLbl.Text = shards.ToString();
            selCardsLbl.Text = selCards.ToString();
            priceLbl.Text = cardPrice.ToString() + " Coins";
        }

        public void RefreshUserInformation()
        {
            bankLbl.Text = "...";
            userLbl.Text = "...";
            accountstateLbl.Text = "...";

            if (!UpdatedSuccess())
            {
                MessageBox.Show("Kontoinformationen konnten nicht aktualisiert werden." + Environment.NewLine + Environment.NewLine + "Falls Sie Ihren Namen geändert haben, setzen Sie ihn wieder zurück oder melden Sie sich ab und dann wieder an.", "Aktualisierung fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (MessageBox.Show("Möchten Sie sich abmelden?", "Abmelden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Abmelden();
                }
                else
                {
                    bankLbl.Text = "FEHLER";
                    userLbl.Text = "FEHLER";
                    accountstateLbl.Text = "FEHLER";
                    IsError = true;
                }
            }
            else
            {
                IsError = false;
            }
        }

        public void RefreshAccountBalance()
        {
            try
            {
                TVP.Transactions.RefreshUserInfo(ref user);
                RefreshVisuals();
            }
            catch
            {
                MessageBox.Show("Kontostand konnte nicht aktualisiert werden.", "Aktualisierung fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Abmelden()
        {
            this.Hide();
            Login();
            this.Show();
        }

        bool UpdatedSuccess()
        {
            //string loginPath = ftp + bank_short + "/account/" + username + "/anmelden/";
            //string accountPath = ftp + bank_short + "/account/" + username + "/konto/";

            try
            {
                ////wb.Credentials = new NetworkCredential(LoginInfo.LoginUser, LoginInfo.LoginPass);
                ////username = wb.DownloadString(loginPath + "name.txt");
                ////password = wb.DownloadString(loginPath + "pass.txt");
                ////balance = decimal.Parse(wb.DownloadString(accountPath + "kstand.txt"));
                //user = (UserInfo)TVP.v1.Transactions.DownloadBalance((TVP.v1.UserInfo)user);
                if (TVP.Transactions.RefreshUserInfo(ref user))
                {
                    RefreshVisuals();
                    MessageBox.Show("Kontoinformationen wurden erfolgreich aktualisiert.", "Aktualisierung erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    //MessageBox.Show("Kontoinformationen konnten nicht aktualisiert werden.", "Fehler bei Aktualisierung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                return false;
            }

            
        }

        private void updateUserDataBtn_Click(object sender, EventArgs e)
        {
            RefreshUserInformation();
        }

        private void shopBtn_Click(object sender, EventArgs e)
        {
            TheShop shop = new TheShop(this);
            shop.ShowDialog();
            shop.Close();
        }

        private void addCardsBtn_Click(object sender, EventArgs e)
        {
            CardCalculator(CardStyle.Add);
        }

        private void removeCardsBtn_Click(object sender, EventArgs e)
        {
            CardCalculator(CardStyle.Substract);
        }

        void CheckCardButtons()
        {
            if (selCards > minCards)
            {
                removeCardsBtn.Enabled = true;
            }

            if (selCards == minCards)
            {
                removeCardsBtn.Enabled = false;
            }

            if (selCards < maxCards)
            {
                addCardsBtn.Enabled = true;
            }

            if (selCards == maxCards)
            {
                addCardsBtn.Enabled = false;
            }

            cardPrice = int.Parse(Math.Floor(double.Parse(basePrice.ToString()) * Math.Pow(selCards, 2)).ToString());

            RefreshVisuals();
        }

        enum CardStyle
        {
            Add,
            Substract
        }

        void CardCalculator(CardStyle cardStyle)
        {
            switch (cardStyle)
            {
                case CardStyle.Add:
                    selCards += selCards;
                    break;

                case CardStyle.Substract:
                    selCards /= 2;
                    break;
            }

            CheckCardButtons();
        }

        private void playGameBtn_Click(object sender, EventArgs e)
        {
            if (coins < cardPrice)
            {
                MessageBox.Show("Ihre Coins reichen nicht aus um das Spiel zu starten.\nKaufen Sie neue Coins um weiter spielen zu können.", "Nicht genügend Coins", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                coins -= cardPrice;

                BingoGame bingo = new BingoGame(this, selCards);
                this.Hide();
                bingo.Show();
            }
        }

        private void upgradesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("EXPERIMENTELLES FEATURE:\n\nUpgrades sind momentan noch in der Testphase.\nDeswegen kostet das Öffnen des Menüs im Voraus 125 Coins.\n\nMöchten Sie die Gebühr zahlen?\n\nHinweis: Die Gebühr wird bei Verlassen der Testphase aufgehoben.", "Upgrades", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (coins >= 125)
                {
                    coins -= 125;
                    RefreshVisuals();
                    BingoUpgrades upgrades = new BingoUpgrades(this);
                    upgrades.ShowDialog();
                    upgrades.Dispose();
                    upgrades.Close();
                }
                else
                {
                    MessageBox.Show("Die Gebühr konnte nicht erhoben werden.\nStellen Sie sicher, dass Sie 25 Coins haben.", "Nicht genügend Coins", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
