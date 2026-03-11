using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bingo
{
    public class Sequence
    {
        private List<Panel> fields;
        private Color defaultColor, sequenceColor;
        private int resetInterval;

        private Timer timer = new Timer();


        public Sequence(List<Panel> fields, SequenceInfo sequenceInfo)
        {
            this.fields = fields;
            this.defaultColor = sequenceInfo.DefaultColor;
            this.sequenceColor = sequenceInfo.SequenceColor;
            this.resetInterval = sequenceInfo.ResetInterval;
        }

        public Sequence(SequenceInfo sequenceInfo, params Panel[] fields)
        {
            this.fields = fields.ToList();
            this.defaultColor = sequenceInfo.DefaultColor;
            this.sequenceColor = sequenceInfo.SequenceColor;
            this.resetInterval = sequenceInfo.ResetInterval;
        }

        public Sequence(List<Panel> fields, Color defaultColor, Color sequenceColor, int resetInterval)
        {
            this.fields = fields;
            this.defaultColor = defaultColor;
            this.sequenceColor = sequenceColor;
            this.resetInterval = resetInterval;
        }

        public Sequence(Color defaultColor, Color sequenceColor, int resetInterval, params Panel[] fields)
        {
            this.fields = fields.ToList();
            this.defaultColor = defaultColor;
            this.sequenceColor = sequenceColor;
            this.resetInterval = resetInterval;
        }

        public void Play()
        {
            foreach (Panel panel in fields)
            {
                panel.BackColor = sequenceColor;
            }

            timer.Interval = resetInterval;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Reset()
        {
            foreach (Panel panel in fields)
            {
                panel.BackColor = defaultColor;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Reset();
            timer.Stop();
            timer.Dispose();
        }
    }

    public class SequenceInfo
    {
        private Color defaultColor;
        private Color sequenceColor;
        private int resetInterval;

        public Color DefaultColor { get => defaultColor; }
        public Color SequenceColor { get => sequenceColor; }
        public int ResetInterval { get => resetInterval; }

        public SequenceInfo(Color defaultColor, Color sequenceColor, int resetInterval)
        {
            this.defaultColor = defaultColor;
            this.sequenceColor = sequenceColor;
            this.resetInterval = resetInterval;
        }
    }
}
