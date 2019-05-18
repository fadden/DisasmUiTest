using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DisasmUiTest {
    /// <summary>
    /// Interaction logic for SimpleListWindow.xaml
    /// </summary>
    public partial class SimpleListWindow : Window {
        public SimpleListWindow() {
            InitializeComponent();

#if false
            // Add a button that captures the style.  Probably easier to just use the approach
            // from https://stackoverflow.com/a/38875063/294248 (especially since I can't
            // figure out how to extract a ListViewItem's style).
            Button bt = new Button();
            bt.Name = "CaptureStyle";
            bt.Content = "Capture Style";
            bt.Click += CaptureStyle_Click;
            rootPanel.Children.Add(bt);
#endif
        }

        private void CaptureStyle_Click(object obj, EventArgs e) {
            string outFile = @"C:\Src\template.xaml";
            string xaml;

            xaml = XamlWriter.Save(codeListView.Template); // template for ListView obj

            //xaml = XamlWriter.Save(codeListView.ItemTemplate); // null
            //xaml = XamlWriter.Save(codeListView.ItemContainerStyle); // null

            File.WriteAllText(outFile, xaml);
            Debug.WriteLine("Written to '" + outFile + "'");
        }
    }
}
