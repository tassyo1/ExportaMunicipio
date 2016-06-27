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
            Contexto db = new Contexto();
            Municipio m = new Municipio()
            {
                Nome = textBox.Text,
                ufID = Convert.ToInt32(comboBox.SelectedValue)
            };
            db.Municipios.Add(m);
            db.SaveChanges();

            MessageBox.Show("Município adicionado!");
            textBox.Text = "";
            db.Dispose();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.HasItems)
            {
                Contexto db = new Contexto();

                UF uf = db.Estados.Find(Convert.ToInt32(comboBox.SelectedValue));

                var busca = from m in db.Municipios where m.ufID == uf.ID
                                              orderby m.Nome select m;

                IList<Municipio> lista = busca.ToList();
                this.dataGridMunicipios.ItemsSource = lista;

            }
        }
    }
}
