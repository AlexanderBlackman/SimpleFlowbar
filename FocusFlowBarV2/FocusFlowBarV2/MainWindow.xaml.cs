using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIEx;
using Microsoft.UI.Windowing;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FocusFlowBarV2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx
    {
        public string MemoToStore { get; set; }
        private Windows.Graphics.PointInt32 WindowPosition;
        private Windows.Graphics.SizeInt32 WindowSize;
        public MainWindow()
        {
            this.InitializeComponent();

            this.ExtendsContentIntoTitleBar = true;

            SetTitleBar(TaskEntryBar);
            //this.IsTitleBarVisible = false;
            IsMinimizable = false;
            IsMaximizable = false;
            IsAlwaysOnTop = true;
            RestorePreviousState();
            this.Closed += MainWindow_Closed;
            this.Activated += MainWindow_Activated;
            this.Title = "FocusFlowBar";
            // MemoToStore = "Quible";

        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {

        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
        }

        private void RestorePreviousState()
        {
            GetMemoFromStorage();
            MoveToLastPosition();
        }

        private void GetMemoFromStorage()
        {
            if (ApplicationData.Current.LocalSettings.Values["memoToStore"] is null)
            {
                MemoToStore = String.Empty;
            }
            else
            {
                MemoToStore = ApplicationData.Current.LocalSettings.Values["memoToStore"].ToString();
            }
        }

        private void MoveToLastPosition()
        {
            if (ApplicationData.Current.LocalSettings.Values["lastPositionSize"] is null)
            {
                this.MoveTo(Placement.TopCenter);
            }
        }


        private void TaskEntryBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            MemoToStore = TaskEntryBar.Text;
            ApplicationData.Current.LocalSettings.Values["memoToStore"] = MemoToStore;
        }

        private void miniSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
