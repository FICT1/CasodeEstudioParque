using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticaArbol.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;



namespace PracticaArbol
{
    

    public partial class Form1 : Form
    {
        TreeNode nodo;
        Graph grafo = new Graph();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (tvParque.Nodes.Count == 0)
            {
                TreeNode root = new TreeNode("Presidente General (CEO)");
                root.Name = "CEO";
                tvParque.Nodes.Add(root);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbParque.Text == "")
                return;

            TreeNode nuevo = new TreeNode(tbParque.Text);

            if (tvParque.SelectedNode != null)
            {
                tvParque.SelectedNode.Nodes.Add(nuevo);
            }
            else
            {
                MessageBox.Show("Seleccione un nodo para agregar un elemento.");
                return;
            }

            tbParque.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tvParque.SelectedNode != null)
            {
                if (tvParque.SelectedNode.Name == "CEO")
                {
                    MessageBox.Show("El nodo 'Presidente General (CEO)' no puede eliminarse.");
                    return;
                }
             


                tvParque.SelectedNode.Remove();
                tbParque.Clear();


            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (tbParque.Text == "")
                return;
            foreach (TreeNode nodo in tvParque.Nodes)
                {
                TreeNode resultado = BuscarNodo(nodo, tbParque.Text);
                if (resultado != null)
                {
                    tvParque.SelectedNode = resultado;
                    MessageBox.Show($"Nodo '{tbParque.Text}' encontrado.");
                    return;
                }
                else
                {
                    MessageBox.Show($"Nodo '{tbParque.Text}' no encontrado. \nPorfavor intentar nuevamente.");

                }
            }
        }

        private void btnNivel_Click(object sender, EventArgs e)
        {

            if (tvParque.SelectedNode != null)
            {
                int nivel = CalcularNivel(tvParque.SelectedNode);
                MessageBox.Show($"El nodo '{tvParque.SelectedNode.Text}' está en el nivel {nivel}.");
            }
            else
            {
                MessageBox.Show("Seleccione un nodo para calcular su nivel.");
            }

        }

        private void btnContar_Click(object sender, EventArgs e)
        {
           foreach (TreeNode nodo in tvParque.Nodes)
           {
               int totalNodos = ContarNodos(nodo.Nodes) + 1; //para agregar la raiz CEO
               MessageBox.Show($"El árbol tiene un total de {totalNodos} nodos.");
            }
        }

        private int ContarNodos(TreeNodeCollection nodos)
        {
            int contador = 0;
            foreach (TreeNode nodo in nodos)
            {
                contador++;
                contador += ContarNodos(nodo.Nodes);
            }
            return contador;
        }

        private TreeNode BuscarNodo(TreeNode nodo, string texto)
        {
            if (nodo.Text == texto)
                return nodo;

            foreach (TreeNode hijo in nodo.Nodes)
            {
                TreeNode r = BuscarNodo(hijo, texto);
                if (r != null)
                    return r;
            }

            return null;

        }
        
        private void lblLugar_Click(object sender, EventArgs e)
        {

        }

        private int CalcularNivel(TreeNode nodo)
        {
            int nivel = 0;
            TreeNode actual = nodo;
            while (actual.Parent != null)
            {
                nivel++;
                actual = actual.Parent;
            }
            return nivel;
        }

        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            lbRecorrido.Items.Clear();

            if (tvParque.Nodes.Count > 0)
                RecorridoPreorden(tvParque.Nodes[0], 0);
        }



        private void RecorridoPreorden(TreeNode nodo, int nivel)
        {
            if (nodo == null)
                return;

            lbRecorrido.Items.Add("-_" + new string(' ', nivel * 2) + nodo.Text);

            foreach (TreeNode hijo in nodo.Nodes)
            {
                RecorridoPreorden(hijo, nivel + 1);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tbDistancia_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbRutas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMostrarConexiones_Click(object sender, EventArgs e)
        {
            lbSalida.Items.Clear();

            var nodos = grafo.ObtenerNodos();

            foreach (var nodo in nodos)
            {
                lbSalida.Items.Add($"Edificio: {nodo}");

                var conexiones = grafo.ObtenerConexiones(nodo);

                foreach (var c in conexiones)
                {
                    lbSalida.Items.Add($"   → {c.Destino} (distancia: {c.Distancia})");
                }

                lbSalida.Items.Add("");
            }
        }



        private void btnEsConexo_Click(object sender, EventArgs e)
        {
            lbSalida.Items.Clear();

            bool conexo = grafo.EsConexo();

            lbSalida.Items.Add(conexo ?
                "El grafo ES conexo." :
                "El grafo NO es conexo.");
        }


        private void btnRutaCorta_Click(object sender, EventArgs e)
        {
            lbSalida.Items.Clear();

            string[] partes = tbDistancia.Text.Split(',');

            if (partes.Length != 2)
            {
                lbSalida.Items.Add("Formato correcto: ORIGEN,DESTINO");
                return;
            }

            string origen = partes[0];
            string destino = partes[1];

            var ruta = grafo.RutaMasCorta(origen, destino);

            lbSalida.Items.Add("Ruta más corta:");
            foreach (var r in ruta)
                lbSalida.Items.Add(" → " + r);
        }

        private void lbSalida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarRuta_Click(object sender, EventArgs e)
        {
            lbSalida.Items.Clear();

            string entrada = tbDistancia.Text.Trim();
            if (string.IsNullOrEmpty(entrada)) return;

            string[] partes = entrada.Split(',');

            if (partes.Length == 1)
            {
                grafo.AgregarNodo(partes[0]);
                lbSalida.Items.Add($"Nodo agregado: {partes[0]}");
            }
            else if (partes.Length == 3)
            {
                grafo.AgregarConexion(partes[0], partes[1], int.Parse(partes[2]));
                lbSalida.Items.Add($"Conexión agregada: {partes[0]} ↔ {partes[1]} ({partes[2]})");
            }
            else
            {
                lbSalida.Items.Add("Formato inválido. Use:");
                lbSalida.Items.Add("Nodo: A");
                lbSalida.Items.Add("Ruta: A,B,5");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
