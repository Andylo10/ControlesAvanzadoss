using ControlesAvanzados.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ControlesAvanzados
{
    public partial class Archivo : Form
    {
        List<Venta> ventas = new List<Venta>();

        public Archivo()
        {
            InitializeComponent();
            agregarVentas();
            inicializarListBox();
            inicializarComboBoxAnios();
            inicializarComboBoxMeses();
        }

        private void agregarVentas()
        {
            ventas.Add(new Venta(2024, 1, "Guatemala", 100000m));
            ventas.Add(new Venta(2024, 2, "Guatemala", 80000m));
            ventas.Add(new Venta(2024, 3, "Guatemala", 95000m));
            ventas.Add(new Venta(2024, 4, "Guatemala", 120000m));
            ventas.Add(new Venta(2024, 5, "Guatemala", 100000m));
            ventas.Add(new Venta(2024, 6, "Guatemala", 110000m));
            ventas.Add(new Venta(2024, 1, "Jutiapa", 50000m));
            ventas.Add(new Venta(2024, 2, "Jutiapa", 80000m));
            ventas.Add(new Venta(2024, 3, "Jutiapa", 67000m));
            ventas.Add(new Venta(2024, 4, "Jutiapa", 55000m));
            ventas.Add(new Venta(2024, 5, "Jutiapa", 67000m));
            ventas.Add(new Venta(2024, 6, "Jutiapa", 45000m));
            ventas.Add(new Venta(2024, 1, "Chiquimula", 43000m));
            ventas.Add(new Venta(2024, 2, "Chiquimula", 55000m));
            ventas.Add(new Venta(2024, 3, "Chiquimula", 23000m));
            ventas.Add(new Venta(2024, 4, "Chiquimula", 34000m));
            ventas.Add(new Venta(2024, 5, "Chiquimula", 56000m));
            ventas.Add(new Venta(2024, 6, "Chiquimula", 78000m));
            ventas.Add(new Venta(2024, 1, "Escuintla", 86000m));
            ventas.Add(new Venta(2024, 2, "Escuintla", 75000m));
            ventas.Add(new Venta(2024, 3, "Escuintla", 64000m));
            ventas.Add(new Venta(2024, 4, "Escuintla", 78000m));
            ventas.Add(new Venta(2024, 5, "Escuintla", 79000m));
            ventas.Add(new Venta(2024, 6, "Escuintla", 90000m));
            ventas.Add(new Venta(2024, 6, "Zacapa", 10000m));
        }

        private void mostrarVentas()
        {
            listadoVentas.Controls.Clear();

            List<Venta> ventasFiltradas = ventas
                .Where(venta => selectorDepartamento.SelectedItem == null || selectorDepartamento.SelectedItems.Contains(venta.Departamento))
                .Where(venta => venta.Anio == (int)comboBoxAnios.SelectedItem)
                .Where(venta => venta.Mes == comboBoxMeses.SelectedIndex + 1).ToList();

            foreach (Venta venta in ventasFiltradas)
            {
                Label labelVenta = crearEtiquetaVenta(venta);
                listadoVentas.Controls.Add(labelVenta);
            }
        }

        private void inicializarListBox()
        {
            List<string> departamentos = new List<string>();
            foreach (Venta venta in ventas)
            {
                if (!departamentos.Contains(venta.Departamento))
                {
                    departamentos.Add(venta.Departamento);
                }
            }
            foreach (string departamento in departamentos)
            {
                selectorDepartamento.Items.Add(departamento);
            }
        }

        private void inicializarComboBoxAnios()
        {
            List<int> anios = new List<int>();
            foreach (Venta venta in ventas)
            {
                if (!anios.Contains(venta.Anio))
                {
                    anios.Add(venta.Anio);
                }
            }
            foreach (int anio in anios)
            {
                comboBoxAnios.Items.Add(anio);
            }

            comboBoxAnios.SelectedIndex = 0;
        }

        private void inicializarComboBoxMeses()
        {
            List<string> meses = new List<string>();
            foreach (Venta venta in ventas)
            {
                string nombreMes = obtenerNombreMesPorNumero(venta.Mes);
                if (!meses.Contains(nombreMes))
                {
                    meses.Add(nombreMes);
                }
            }
            foreach (string mes in meses)
            {
                comboBoxMeses.Items.Add(mes);
            }

            comboBoxMeses.SelectedIndex = 0;
        }

        private string obtenerNombreMesPorNumero(int numeroMes)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return meses[numeroMes - 1];
        }

        private string FormatearVentas(decimal ventas)
        {
            // Crear una cultura personalizada para Guatemala
            var culturaGuatemala = new CultureInfo("es-GT");
            // Ajustar el formato para que use puntos para miles y comas para decimales
            culturaGuatemala.NumberFormat.NumberGroupSeparator = ".";
            culturaGuatemala.NumberFormat.NumberDecimalSeparator = ",";

            return ventas.ToString("#,##0.00", culturaGuatemala);
        }

        private Label crearEtiquetaVenta(Venta venta)
        {
            Label labelVenta = new Label();
            labelVenta.Text = $"Año: {venta.Anio} \n Mes: {obtenerNombreMesPorNumero(venta.Mes)} \n Departamento: {venta.Departamento} \n Ventas: Q.{FormatearVentas(venta.Ventas)}";
            labelVenta.AutoSize = true;
            labelVenta.Font = new Font("Arial", 12, FontStyle.Bold);
            labelVenta.Padding = new Padding(10);
            labelVenta.BorderStyle = BorderStyle.FixedSingle;
            labelVenta.Margin = new Padding(10);
            labelVenta.BackColor = Color.LightGray;
            return labelVenta;
        }

        private void selectorDepartamento_SelectedValueChanged(object sender, EventArgs e)
        {
            mostrarVentas();
        }

        private void comboBoxAnios_SelectedValueChanged(object sender, EventArgs e)
        {
            mostrarVentas();
        }

        private void comboBoxMeses_SelectedValueChanged(object sender, EventArgs e)
        {
            mostrarVentas();
        }

        private void Archivo_Load(object sender, EventArgs e)
        {

        }
    }
}
