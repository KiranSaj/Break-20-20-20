using System;
using System.Drawing;
using System.Windows.Forms;

namespace Break_20_20_20;

/// <summary>
/// A custom label control that fades text in and out using color animation.
/// </summary>
public class FadeLabel : Label
{
    private readonly ColorAnimator _colorAnimator = new();
    private string _currentText = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="FadeLabel"/> class.
    /// </summary>
    public FadeLabel()
    {
        _colorAnimator.Change += OnColorChange;
    }

    /// <summary>
    /// Gets or sets the foreground color of the label.
    /// </summary>
    public override Color ForeColor
    {
        get => base.ForeColor;
        set
        {
            base.ForeColor = value;
            _colorAnimator.Color = value;
        }
    }

    /// <summary>
    /// Gets or sets the text displayed in the label with fade animation.
    /// </summary>
    public override string? Text
    {
        get => base.Text;
        set
        {
            if (!string.IsNullOrEmpty(base.Text))
            {
                _colorAnimator.Begin();
            }

            _currentText = base.Text ?? string.Empty;
            base.Text = value;
        }
    }

    /// <summary>
    /// Handles the change event of the color animator.
    /// </summary>
    private void OnColorChange(object? sender, EventArgs e)
    {
        Invalidate();
    }

    /// <summary>
    /// Paints the label with the animated color.
    /// </summary>
    protected override void OnPaint(PaintEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        string textToDraw = _colorAnimator.Fading ? _currentText : (base.Text ?? string.Empty);

        using var brush = new SolidBrush(_colorAnimator.Color);
        e.Graphics.DrawString(textToDraw, Font, brush, ClientRectangle);
    }

    /// <summary>
    /// Disposes of the resources used by the label.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _colorAnimator?.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Internal color animator class that handles fade animations using a timer.
    /// </summary>
    internal sealed class ColorAnimator : Timer
    {
        #region Constants

        private const int AnimationRate = 5;

        #endregion

        #region Fields

        private Color _baseColor = Color.Black;
        private int _alphaValue = 255;
        private int _animationStep = -1;

        #endregion

        /// <summary>
        /// Triggered when the color value changes.
        /// </summary>
        public event EventHandler? Change;

        /// <summary>
        /// Gets or sets the base color for the animation.
        /// </summary>
        public Color Color
        {
            get => Color.FromArgb(_alphaValue, _baseColor);
            set => _baseColor = value;
        }

        /// <summary>
        /// Gets a value indicating whether the animation is currently fading.
        /// </summary>
        public bool Fading => Enabled && _animationStep < 0;

        /// <summary>
        /// Begins the fade animation.
        /// </summary>
        public void Begin()
        {
            _alphaValue = 255;
            _animationStep = -AnimationRate;
            Interval = 16;
            Enabled = true;
        }

        /// <summary>
        /// Handles the timer tick event to update the animation.
        /// </summary>
        protected override void OnTick(EventArgs e)
        {
            _alphaValue += _animationStep;

            if (_alphaValue <= 0)
            {
                _alphaValue = 0;
                _animationStep = -_animationStep;
            }

            if (_alphaValue >= 255)
            {
                _alphaValue = 255;
                Enabled = false;
            }

            Change?.Invoke(this, EventArgs.Empty);
        }
    }
}