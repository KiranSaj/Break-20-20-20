using System;
using System.Drawing;
using System.Windows.Forms;

namespace Break_20_20_20;

/// <summary>
/// Break reminder form implementing the 20-20-20 eye rule.
/// Every 20 minutes, look at something 20 feet away for 20 seconds.
/// </summary>
public partial class frmBreakSlide : Form
{
    #region Constants

    private const int BreakDurationSeconds = 60;
    private const int ProgressBarMaxValue = 540; // 9 minutes in 100ms intervals
    private const int MainIntervalMilliseconds = 1200000; // 20 minutes
    private const double OpacityIncrement = 0.025;
    private const int MessageFadeOutSecond = 55;
    private const int FocusEyesSecond = 45;
    private const int StretchSecond = 25;
    private const string NotificationSoundPath = @"C:\Windows\Media\notify.wav";

    #endregion

    #region Fields

    private int _secondsRemaining = BreakDurationSeconds;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="frmBreakSlide"/> class.
    /// </summary>
    public frmBreakSlide()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the Load event of the frmBreakSlide control.
    /// </summary>
    private void frmBreakSlide_Load(object sender, EventArgs e)
    {
        Initialize();
    }

    /// <summary>
    /// Initializes the break slide form.
    /// </summary>
    private void Initialize()
    {
        Opacity = 0;
        Show();
        progressBar1.Value = ProgressBarMaxValue;
        _secondsRemaining = BreakDurationSeconds;
        CenterControlPanel();
        fadeLblMsg.Text = "    ";
        FormLoadTimer.Start();
    }

    /// <summary>
    /// Centers the control panel on the form.
    /// </summary>
    private void CenterControlPanel()
    {
        controlPanel.Left = (controlPanel.Parent.Width - controlPanel.Width) / 2;
        controlPanel.Top = (controlPanel.Parent.Height - controlPanel.Height) / 2;
    }

    /// <summary>
    /// Handles the Tick event for form load fade-in animation.
    /// </summary>
    private void FormLoadTimer_Tick(object? sender, EventArgs e)
    {
        if (Opacity < 1)
        {
            Opacity += OpacityIncrement;
        }
        else
        {
            FormLoadTimer.Stop();
            progressBarTimer.Start();
            secondCountTimer.Start();
            fadeLblMsg.Text = @"Take a deep breath";
        }
    }

    /// <summary>
    /// Handles the KeyPress event to close the form when ESC is pressed.
    /// </summary>
    private void frmBreakSlide_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 27) // ESC key
        {
            Hide();
            e.Handled = true;
        }
    }

    /// <summary>
    /// Handles the Tick event for progress bar update.
    /// </summary>
    private void progressBarTimer_Tick(object? sender, EventArgs e)
    {
        if (progressBar1.Value > 0)
        {
            progressBar1.Value -= 1;
        }
        else
        {
            progressBarTimer.Stop();
            Hide();
        }
    }

    /// <summary>
    /// Handles the Tick event for second countdown.
    /// </summary>
    private void secondCountTimer_Tick(object? sender, EventArgs e)
    {
        if (_secondsRemaining > 0)
        {
            _secondsRemaining--;
            lblCounter.Text = $"{_secondsRemaining}s";

            // Display messages at specific intervals
            switch (_secondsRemaining)
            {
                case MessageFadeOutSecond:
                    PlayNotificationSound();
                    fadeLblMsg.Text = @"Rub your palms and close your eyes with it";
                    break;
                case FocusEyesSecond:
                    PlayNotificationSound();
                    fadeLblMsg.Text = @"Focus your eyes on something at least 20 feet away";
                    break;
                case StretchSecond:
                    PlayNotificationSound();
                    fadeLblMsg.Text = @"Stretch your arms and legs";
                    break;
            }
        }
        else
        {
            _secondsRemaining = BreakDurationSeconds;
            secondCountTimer.Stop();
            fadeLblMsg.Text = "    ";
            PlayNotificationSound();
        }
    }

    /// <summary>
    /// Handles the ResizeEnd event to recenter the control panel.
    /// </summary>
    private void frmBreakSlide_ResizeEnd(object? sender, EventArgs e)
    {
        CenterControlPanel();
    }

    /// <summary>
    /// Handles the Tick event for the main time watcher (20-minute intervals).
    /// </summary>
    private void MainTimeWatcher_Tick(object? sender, EventArgs e)
    {
        Initialize();
    }

    /// <summary>
    /// Plays the notification sound.
    /// </summary>
    private static void PlayNotificationSound()
    {
        try
        {
            using var player = new System.Media.SoundPlayer(NotificationSoundPath);
            player.Play();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to play notification sound: {ex.Message}");
        }
    }

    /// <summary>
    /// Disposes of the resources used by the form.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            FormLoadTimer?.Dispose();
            progressBarTimer?.Dispose();
            secondCountTimer?.Dispose();
            MainTimeWatcher?.Dispose();
        }

        base.Dispose(disposing);
    }
}
