using System.Windows;
using System.Windows.Input;

namespace YoutubeDownloader.Views.Components;

public partial class DashboardView
{
    public DashboardView()
    {
        InitializeComponent();
    }

    private void QueryTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        // Disable new lines when pressing enter without shift
        if (e.Key == Key.Enter && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
        {
            e.Handled = true;

            // We handle the event here so we have to directly "press" the default button
            AccessKeyManager.ProcessKey(null, "\x000D", false);
        }
    }

    private void QueryTextBox_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (QueryTextBox.SelectionLength == 0)
        {
            QueryTextBox.SelectAll();
        }
    }

    private void QueryTextBox_OnLostMouseCapture(object sender, MouseEventArgs e)
    {
        // If user highlights some text, don't override it
        if (QueryTextBox.SelectionLength == 0)
            QueryTextBox.SelectAll();

        // further clicks will not select all
        QueryTextBox.LostMouseCapture -= QueryTextBox_OnLostMouseCapture;
    }


    private void QueryTextBox_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        QueryTextBox.LostMouseCapture += QueryTextBox_OnLostMouseCapture;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        QueryTextBox.Clear();
    }
}