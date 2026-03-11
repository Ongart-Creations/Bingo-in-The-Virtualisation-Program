using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bingo
{
    public partial class BingoCard : Form
    {
        List<List<Label>> bingoLbls = new List<List<Label>>();

        bool BadCallKill = false;

        int bingoCount = 0;

        BingoGame game;

        Random ran = new Random();

        Dictionary<Label, bool> clickedDict;
        Label[] fields;

        public BingoCard(BingoGame game, int instanceID, int maxInstances)
        {
            InitializeComponent();

            this.game = game;
            this.Text = "Bingo Karte ( " + instanceID + " von " + maxInstances + " )";


            clickedDict = new Dictionary<Label, bool>()
            {
                { numLbl1, false }, { numLbl6, false }, { numLbl11, false }, { numLbl16, false }, { numLbl21, false },
                { numLbl2, false }, { numLbl7, false }, { numLbl12, false }, { numLbl17, false }, { numLbl22, false },
                { numLbl3, false }, { numLbl8, false }, { numLbl13, true }, { numLbl18, false }, { numLbl23, false },
                { numLbl4, false }, { numLbl9, false }, { numLbl14, false }, { numLbl19, false }, { numLbl24, false },
                { numLbl5, false }, { numLbl10, false }, { numLbl15, false }, { numLbl20, false }, { numLbl25, false }
            };

            fields = new Label[] { numLbl1, numLbl2, numLbl3, numLbl4, numLbl5, numLbl6, numLbl7, numLbl8, numLbl9, numLbl10,
                                           numLbl11, numLbl12, numLbl13, numLbl14, numLbl15, numLbl16, numLbl17, numLbl18, numLbl19, numLbl20,
                                           numLbl21, numLbl22, numLbl23, numLbl24, numLbl25 };

            GenerateField();
        }

        private void BingoCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!BadCallKill)
            {
                KillInstance(true);
            }
            this.Dispose();
        }

        private void KillInstance(bool killFullInstance)
        {
            if (killFullInstance || game.IsLastInstance())
            {
                game.SendInstanceBreak();
            }
            else
            {
                BadCallKill = true;
                this.Close();
            }
        }

        #region "old (new) Stuff"
        //        List<int> range = Enumerable.Range(1, 75).ToList();

        //        Label[] fields = new Label[] { numLbl1, numLbl2, numLbl3, numLbl4, numLbl5, numLbl6, numLbl7, numLbl8, numLbl9, numLbl10,
        //                                           numLbl11, numLbl12, numLbl13, numLbl14, numLbl15, numLbl16, numLbl17, numLbl18, numLbl19, numLbl20,
        //                                           numLbl21, numLbl22, numLbl23, numLbl24, numLbl25 };

        //        int count = 0;
        //        int ranIndex;

        //            foreach (Label field in fields)
        //            {
        //                DoAgain:

        //                ranIndex = ran.Next(0, range.Count);

        //                if (count< 5)
        //                {
        //                    if (!game.InRange(1, 15, range[ranIndex]))
        //                    {
        //                        goto DoAgain;   
        //                    }
        //    field.Text = range[ranIndex].ToString();
        //}
        //                else if(count< 10)
        //                {
        //                    if (!game.InRange(16, 30, range[ranIndex]))
        //                    {
        //                        goto DoAgain;
        //                    }
        //                    field.Text = range[ranIndex].ToString();
        //                }
        //                else if (count< 15)
        //                {
        //                    if (count != 12)
        //                    {
        //                        if (!game.InRange(31, 45, range[ranIndex]))
        //                        {
        //                            goto DoAgain;
        //                        }
        //                        field.Text = range[ranIndex].ToString();
        //                    }
        //                    else
        //                    {
        //                        goto SkipMid;
        //                    }
        //                }
        //                else if (count< 20)
        //                {
        //                    if (!game.InRange(46, 60, range[ranIndex]))
        //                    {
        //                        goto DoAgain;
        //                    }
        //                    field.Text = range[ranIndex].ToString();
        //                }
        //                else if (count< 25)
        //                {
        //                    if (!game.InRange(61, 75, range[ranIndex]))
        //                    {
        //                        goto DoAgain;
        //                    }
        //                    field.Text = range[ranIndex].ToString();
        //                }


        //                SkipMid:
        //                range.RemoveAt(ranIndex);
        //                count++;
        //            }
        #endregion

        public void GenerateField()
        {
            List<int> range_B = Enumerable.Range(1, 15).ToList();
            List<int> range_I = Enumerable.Range(16, 15).ToList();
            List<int> range_N = Enumerable.Range(31, 15).ToList();
            List<int> range_G = Enumerable.Range(46, 15).ToList();
            List<int> range_O = Enumerable.Range(61, 15).ToList();

           

            for (int i = 0; i < 5; i++)
            {
                int ranIndex = ran.Next(0, range_B.Count);

                fields[i].Text = range_B[ranIndex].ToString();
                range_B.RemoveAt(ranIndex);
            }

            for (int i = 5; i < 10; i++)
            {
                int ranIndex = ran.Next(0, range_I.Count);

                fields[i].Text = range_I[ranIndex].ToString();
                range_I.RemoveAt(ranIndex);
            }

            for (int i = 10; i < 15; i++)
            {
                int ranIndex = ran.Next(0, range_N.Count);

                if (i != 12)
                {
                    fields[i].Text = range_N[ranIndex].ToString();
                    range_N.RemoveAt(ranIndex);
                }
            }

            for (int i = 15; i < 20; i++)
            {
                int ranIndex = ran.Next(0, range_G.Count);

                fields[i].Text = range_G[ranIndex].ToString();
                range_G.RemoveAt(ranIndex);
            }

            for (int i = 20; i < 25; i++)
            {
                int ranIndex = ran.Next(0, range_O.Count);

                fields[i].Text = range_O[ranIndex].ToString();
                range_O.RemoveAt(ranIndex);
            }

        }

        private void MouseHoverEnter(object sender, EventArgs e)
        {
            Color hoverColor = Color.Orange;
            Label lbl = (Label)sender;

            if (!clickedDict[lbl] && lbl.BackColor != Color.DimGray)
            {
                lbl.BackColor = hoverColor;
            }
        }

        private void MouseHoverLeave(object sender, EventArgs e)
        {
            Color defaultColor = SystemColors.Control;
            Label lbl = (Label)sender;

            if (!clickedDict[lbl] && lbl.BackColor != Color.DimGray)
            {
                lbl.BackColor = defaultColor;
            }
        }

        void ClickField(object sender, EventArgs e)
        {
            Color hitColor = Color.Red;
            Label lbl = (Label)sender;

            if (lbl.BackColor == Color.DimGray)
                return;

            if (game.rolledNumbers.Contains(int.Parse(lbl.Text)))
            {
                clickedDict[lbl] = true;
                lbl.BackColor = hitColor;
                lbl.ForeColor = Color.Black;
                return;
            }

            lbl.BackColor = hitColor;
            clickedDict[lbl] = !clickedDict[lbl];
        }

        bool IsBINGO()
        {
            List<Label> verB = new List<Label>() { numLbl1, numLbl2, numLbl3, numLbl4, numLbl5 };
            List<Label> verI = new List<Label>() { numLbl6, numLbl7, numLbl8, numLbl9, numLbl10 };
            List<Label> verN = new List<Label>() { numLbl11, numLbl12, numLbl13, numLbl14, numLbl15 };
            List<Label> verG = new List<Label>() { numLbl16, numLbl17, numLbl18, numLbl19, numLbl20 };
            List<Label> verO = new List<Label>() { numLbl21, numLbl22, numLbl23, numLbl24, numLbl25 };

            List<Label> hor1 = new List<Label>() { numLbl1, numLbl6, numLbl11, numLbl16, numLbl21 };
            List<Label> hor2 = new List<Label>() { numLbl2, numLbl7, numLbl12, numLbl17, numLbl22 };
            List<Label> hor3 = new List<Label>() { numLbl3, numLbl8, numLbl13, numLbl18, numLbl23 };
            List<Label> hor4 = new List<Label>() { numLbl4, numLbl9, numLbl14, numLbl19, numLbl24 };
            List<Label> hor5 = new List<Label>() { numLbl5, numLbl10, numLbl15, numLbl20, numLbl25 };

            List<Label> diaTopLeft = new List<Label>() { numLbl1, numLbl7, numLbl13, numLbl19, numLbl25 };
            List<Label> diaTopRight = new List<Label>() { numLbl5, numLbl9, numLbl13, numLbl17, numLbl21 };

            List<Label> fourCorners = new List<Label>() { numLbl1, numLbl5, numLbl13, numLbl21, numLbl25 };

            List<List<Label>> checkList = new List<List<Label>>() { verB, verI, verN, verG, verO, hor1, hor2, hor3, hor4, hor5, diaTopLeft, diaTopRight, fourCorners };

            bool[] bingoLine = new bool[5];

            int count = 0;
            int curBingos = 0;

            bingoLbls.Clear();

            foreach (List<Label> list in checkList)
            {
                count = 0;
                foreach (Label lbl in list)
                {
                    if (lbl.BackColor == Color.DimGray)
                    {
                        bingoLine[count] = true;
                        goto GoOn;
                    }

                    if (lbl.Text == "")
                    {
                        bingoLine[count] = true;
                    }
                    else
                    {
                        if (game.rolledNumbers.Contains(int.Parse(lbl.Text)) && clickedDict[lbl])
                        {
                            bingoLine[count] = true;
                        }
                        else
                        {
                            bingoLine[count] = false;
                        }
                    }

                    GoOn:

                    count++;
                }

                if (bingoLine[0] && bingoLine[1] && bingoLine[2] && bingoLine[3] && bingoLine[4])
                {
                    bingoLbls.Add(list);
                    curBingos++;
                }
            }

            bingoCount = curBingos;

            if (bingoCount > 0)
            {
                return true;
            }
            return false;
        }

        private void sayBingoBtn_Click(object sender, EventArgs e)
        {
            if (IsBINGO())
            {
                MessageBox.Show("BINGO!");
                game.allBingoCount += bingoCount;
            }
            else
            {
                //Are you protected from bad calls? No? Kill the instance
                if (!game.IsUpgradeBought("protection"))
                {
                    MessageBox.Show("BAD CALL!");
                }
                else
                {
                    MessageBox.Show("Protected from bad call!");
                    game.upgrades.Remove(game.GetUpgradeById("protection"));
                    return;
                }
            }

            KillInstance(false);
        }

        public void Vision()
        {
            foreach (Label field in fields)
            {
                if (field.Text == string.Empty)
                {
                    goto Skip;
                }

                if (game.rolledNumbers.Contains(Convert.ToInt32(field.Text)) && !clickedDict[field])
                {
                    field.BackColor = Color.Lime;
                    field.ForeColor = Color.Blue;
                }

                Skip:;
            }
        }

        public void BingoVision()
        {
            ////NOT FULLY IMPLEMENTED
            //throw new Exception("Has to be implemented");


            //Color[] defCol = new Color[5];

            if (IsBINGO())
            {
                //int count = 0;

                foreach (List<Label> list in bingoLbls)
                {
                    //count = 0;

                    foreach (Label lbl in list)
                    {
                        //defCol[count] = lbl.BackColor;

                        if (lbl.Text != "")
                        {
                            lbl.BackColor = Color.Blue;
                        }

                        //count++;
                    }
                }
            }
        }
      
    }
}
