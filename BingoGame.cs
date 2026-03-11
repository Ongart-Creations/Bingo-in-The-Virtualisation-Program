using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Bingo
{
    public partial class BingoGame : Form
    {
        public int allBingoCount = 0;
        public List<int> rolledNumbers = new List<int>();
        public List<Upgrade> upgrades = new List<Upgrade>();
        public bool HasVision = false;
        public bool HasBingoVision = false;

        private bool DebugEnabled = false;
        private decimal shardPrice = 7.25m;
        private int countdown = 4, remainingNumbers = 22;
        private bool IsStarting = true;
        


        char[] keys = new char[] { 'B', 'I', 'N', 'G', 'O' };

        List<int> gotSelected = Enumerable.Range(1, 75).ToList();
        

        Random ran = new Random();

        BingoMainMenu menu;

        List<BingoCard> cardInstances;

        SpeechSynthesizer speaker = new SpeechSynthesizer();

        bool SpeakRolledNum = true;



        public BingoGame(BingoMainMenu instance, int cards)
        {
            InitializeComponent();

            this.menu = instance;

            cardInstances = new List<BingoCard>();
            upgrades = menu.upgrades;

            HasVision = IsUpgradeBought("vision");
            HasBingoVision = IsUpgradeBought("bingo");

            if (DebugEnabled)
            {
                startGameBtn.Enabled = false;
                speakRolledCheckBox.Enabled = false;
                rolledNumbers = Enumerable.Range(1, 75).ToList();
            }

            for (int i = 0; i < cards; i++)
            {
                BingoCard card = new BingoCard(this, i + 1, cards);
                cardInstances.Add(card);
                card.Show(this);
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.ContextMenuStrip = DebugContent;
            }
        }

        public void SendInstanceBreak()
        {
            foreach (BingoCard card in cardInstances)
            {
                if (card.Visible == true)
                {
                    card.Dispose();
                    card.Close();
                }
            }
            cardInstances.Clear();
            this.Close();
        }

        public bool IsLastInstance()
        {
            int instancesCount = 0;

            foreach (BingoCard card in cardInstances)
            {
                if (card.Visible == true)
                {
                    instancesCount++;
                }
            }

            if (instancesCount > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ApplyShards()
        {
            if (allBingoCount > 0)
            {
                menu.shards += Convert.ToInt64(Math.Pow((double)shardPrice, (double)allBingoCount / 2));
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Label[] txts = new Label[] { bingoLbl1, bingoLbl2, bingoLbl3, bingoLbl4, bingoLbl5, bingoLbl6 };

            for (int i = 0; i < txts.Length; i++)
            {
                if ((i + 1) < txts.Length)
                {
                    txts[i].Text = txts[i + 1].Text;
                }
            }

            //Generierung neuer Zahlen

            if (gotSelected.Count % 52 != 1)
            {
                int ranNum = ran.Next(0, gotSelected.Count());

                bingoLbl6.Text = keys[GetAlphaIndex(gotSelected[ranNum])] + Environment.NewLine + gotSelected[ranNum];

                if (SpeakRolledNum)
                {
                    speaker.SpeakAsync(keys[GetAlphaIndex(gotSelected[ranNum])] + " " + gotSelected[ranNum]); 
                }

                rolledNumbers.Add(gotSelected[ranNum]);

                if (HasVision)
                {
                    foreach (BingoCard card in cardInstances)
                    {
                        card.Vision();
                    }
                }

                if (HasBingoVision)
                {
                    foreach (BingoCard card in cardInstances)
                    {
                        card.BingoVision();
                    }
                }

                gotSelected.RemoveAt(ranNum);
                remainingNumbers--;

                if (remainingNumbers == 1)
                {
                    IsStarting = false;
                    countdown = 5;
                }
            }
            else
            {
                gameTimer.Stop();
                this.Close();
            }
        }

        int GetAlphaIndex(int countIndex)
        {
            if (InRange(1, 15, countIndex))
            {
                return 0;
            }
            else if (InRange(16, 30, countIndex))
            {
                return 1;
            }
            else if (InRange(31, 45, countIndex))
            {
                return 2;
            }
            else if (InRange(46, 60, countIndex))
            {
                return 3;
            }
            else if (InRange(61, 75, countIndex))
            {
                return 4;
            }

            return -1;
        }

        /// <summary>
        /// In Range minimum and maximum are included
        /// </summary>
        public bool InRange(int min, int max, int check)
        {
            return !(check < min || check > max);
        }

        private void BingoGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplyShards();
            menu.RefreshVisuals();
            menu.upgrades.Clear();
            GC.Collect();
            menu.Show();
            this.Dispose();
        }

        private void speakRolledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SpeakRolledNum = speakRolledCheckBox.Checked;
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            howItWorksLnkLbl.Hide();
            startGameBtn.Enabled = false;
            countdownLbl.Show();
            countdownTimer.Start();
            gameTimer.Start();
        }

        private void howItWorksLnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BingoWins wins = new BingoWins();

            wins.ShowDialog();
            wins.Dispose();
            wins.Close();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            if (IsStarting && remainingNumbers > 21)
            {
                countdownLbl.Text = "Spiel startet in " + countdown + "...";
                countdown--;
            }
            else if (!IsStarting && !(remainingNumbers > 0))
            {
                countdownLbl.Text = "Spiel endet in " + countdown + "...";
                countdown--;
            }
            else
            {
                countdownLbl.Text = "Verbleibende Zahlen: " + remainingNumbers;
            }
        }

        public bool IsUpgradeBought(string checkId)
        {
            foreach (Upgrade upgrade in upgrades)
            {
                if (upgrade.ID == checkId)
                {
                    return true;
                }
            }

            return false;
        }

        private void insertNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = "";
            int conv = -1;

            InputBox xbox = new InputBox();
            xbox.ShowDialog();
            output = xbox.Output;
            xbox.Close();
            xbox.Dispose();

            if (output != null)
            {
                if (!output.All(char.IsNumber))
                {
                    MessageBox.Show("Error: Only number supported");
                    return;
                }
                else
                {
                    conv = int.Parse(output);
                }
            }
            else
            {
                MessageBox.Show("Error: Only number supported");
                return;
            }



            Label[] txts = new Label[] { bingoLbl1, bingoLbl2, bingoLbl3, bingoLbl4, bingoLbl5, bingoLbl6 };

            for (int i = 0; i < txts.Length; i++)
            {
                if ((i + 1) < txts.Length)
                {
                    txts[i].Text = txts[i + 1].Text;
                }
            }


            if (gotSelected.Contains(conv))
            {
                bingoLbl6.Text = keys[GetAlphaIndex(conv)] + Environment.NewLine + conv;

                rolledNumbers.Add(conv);

                gotSelected.RemoveAt(gotSelected.IndexOf(conv));
                remainingNumbers--;
            }
            else
            {
                MessageBox.Show("Error: Unknown");
            }
        }

        public Upgrade GetUpgradeById(string checkId)
        {
            foreach (Upgrade upgrade in upgrades)
            {
                if (upgrade.ID == checkId)
                {
                    return upgrade;
                }
            }

            return null;
        }
    }

    internal class InputBox : Form
    {
        TextBox txt;

        public string Output;

        public InputBox()
        {
            txt = new TextBox();
            txt.Dock = DockStyle.Fill;
            txt.Multiline = true;

            txt.TextChanged += Txt_TextChanged;

            this.Controls.Add(txt);
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            this.Output = txt.Text;
        }
    }
}
