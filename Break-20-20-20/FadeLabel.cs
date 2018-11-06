namespace Break_20_20_20
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FadeLabel : Label
    {
        private ColorAnimator mAnim = new ColorAnimator();
        private string mText = "";

        public FadeLabel()
        {
            mAnim.Change += new EventHandler(mAnim_Change);
        }
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; mAnim.Color = value; }
        }
        public override string Text
        {
            get { return base.Text; }
            set { if (base.Text != "") mAnim.Begin(); mText = base.Text; base.Text = value; }
        }
        void mAnim_Change(object sender, EventArgs e)
        {
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            string txt = mAnim.Fading ? mText : base.Text;
            using (Brush br = new SolidBrush(mAnim.Color))
                e.Graphics.DrawString(txt, this.Font, br, this.ClientRectangle);
        }

        internal class ColorAnimator : Timer
        {
            public event EventHandler Change;
            private const int cRate = 5;    // Tweak this
            private Color mColor;
            private int mValue = 255;
            private int mStep = -1;

            public Color Color
            {
                get { return Color.FromArgb(mValue, mColor); }
                set { mColor = value; }
            }
            public void Begin()
            {
                mValue = 255;
                mStep = -cRate;
                Interval = 16;
                Enabled = true;
            }
            public bool Fading
            {
                get { return Enabled && mStep < 0; }
            }
            protected override void OnTick(EventArgs e)
            {
                mValue += mStep;
                if (mValue <= 0) { mValue = 0; mStep = -mStep; }
                if (mValue >= 255) { mValue = 255; Enabled = false; }
                if (Change != null) Change(this, EventArgs.Empty);
            }
        }
    }
}