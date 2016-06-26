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
using ExportaMunicipio.Model;


namespace ExportaMunicipio
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Contexto db = new Contexto();
            var lista = db.Estados.OrderBy(uf => uf.Sigla);
            IList<UF> ufs = lista.ToList();
            
            comboBox.DisplayMemberPath ="Sigla";
            comboBox.SelectedValuePath = "ID";
            comboBox.ItemsSource = ufs;
            
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
