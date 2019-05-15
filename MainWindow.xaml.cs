using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
