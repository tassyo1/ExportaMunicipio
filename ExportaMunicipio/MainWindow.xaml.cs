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
using ExportaMunicipio.DAO;

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

            comboBox.DisplayMemberPath = "Sigla";
            comboBox.SelectedValuePath = "ID";
            comboBox.ItemsSource = ufs;

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox.Text != "")
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

                preencheGrid();
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMunicipios.SelectedCells.Count() > 0)
            {
                Contexto db = new Contexto();
                IList<Municipio> listaMunicipio = new List<Municipio>();

                var itensSelecao = dataGridMunicipios.SelectedItems;

                foreach (var c in itensSelecao)
                {
                    Municipio m = (Municipio)c;
                    listaMunicipio.Add(db.Municipios.Find(m.ID));
                }

                db.Municipios.RemoveRange(listaMunicipio);

                db.SaveChanges();
                MessageBox.Show("Município excluído!");
                db.Dispose();

                preencheGrid();
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.HasItems)
            {
                preencheGrid();
            }
        }

        private void preencheGrid()
        {
            MunicipioDAO dao = new MunicipioDAO();

            IList<Municipio> lista = dao.MunicipiosPorUF(Convert.ToInt32(comboBox.SelectedValue));

            this.dataGridMunicipios.ItemsSource = lista;

            preencheTotal();
        }
    
        private void preencheTotal()
        {
            this.labelT.Content =this.dataGridMunicipios.Items.Count.ToString();
        }
    }
}
