using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bingo
{
    public partial class BingoWins : Form
    {
        List<Sequence> sequences;
        Color defaultColor = SystemColors.Control;
        Color sequenceColor = Color.Red;
        int interval;

        int sequence = 1;

        public BingoWins()
        {
            InitializeComponent();

            interval = sequencesTimer.Interval;

            SequenceInfo seqInfo = new SequenceInfo(defaultColor, sequenceColor, interval);

            sequences = new List<Sequence>()
            {
                new Sequence(seqInfo, numField1, numField2, numField3, numField4, numField5),
                new Sequence(seqInfo, numField6, numField7, numField8, numField9, numField10),
                new Sequence(seqInfo, numField11, numField12, numField13, numField14, numField15),
                new Sequence(seqInfo, numField16, numField17, numField18, numField19, numField20),
                new Sequence(seqInfo, numField21, numField22, numField23, numField24, numField25),

                new Sequence(seqInfo, numField1, numField6, numField11, numField16, numField21),
                new Sequence(seqInfo, numField2, numField7, numField12, numField17, numField22),
                new Sequence(seqInfo, numField3, numField8, numField13, numField18, numField23),
                new Sequence(seqInfo, numField4, numField9, numField14, numField19, numField24),
                new Sequence(seqInfo, numField5, numField10, numField15, numField20, numField25),

                new Sequence(seqInfo, numField1, numField7, numField13, numField19, numField25),
                new Sequence(seqInfo, numField21, numField17, numField13, numField9, numField5),

                new Sequence(seqInfo, numField1, numField5, numField21, numField25),
            };

            sequences[0].Play();
        }

        private void sequencesTimer_Tick(object sender, EventArgs e)
        {
            if (sequence == sequences.Count)
            {
                sequence = 0;
            }

            sequences[sequence].Play();

            sequence++;
        }
    }
}
