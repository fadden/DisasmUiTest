using System;
using System.Windows;

namespace DisasmUiTest {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void SimpleList_Click(object sender, RoutedEventArgs e) {
            SimpleListWindow win = new SimpleListWindow();
            win.Show();
        }

        private void MultiColTemplate_Click(object sender, RoutedEventArgs e) {
            MultiColTemplateWindow win = new MultiColTemplateWindow();
            win.Show();
        }

        private void RowPresenter_Click(object sender, RoutedEventArgs e) {
            RowPresenterWindow win = new RowPresenterWindow();
            win.Show();
        }

        private void FullyStyled_Click(object sender, RoutedEventArgs e) {
            FullStyleWindow win = new FullStyleWindow();
            win.Show();
        }

        private void SelectionTest_Click(object sender, RoutedEventArgs e) {
            SelectionTestWindow win = new SelectionTestWindow();
            win.Show();
        }
    }
}
