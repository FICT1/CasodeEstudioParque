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

        private void cbDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbRutas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMostrarConexiones_Click(object sender, EventArgs e, string v)
        {
            
        }

        private void btnEsConexo_Click(object sender, EventArgs e)
        {

        }

        private void btnRutaCorta_Click(object sender, EventArgs e)
        {

        }

        private void lbSalida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarRuta_Click(object sender, EventArgs e)
        {
            if (cbDesde.Text == "" || cbHasta.Text == "" || tbDistancia.Text == "")
                return;

            if (!int.TryParse(tbDistancia.Text, out int peso))
            {
                MessageBox.Show("Distancia inválida");
                return;
            }

            grafo.AddVertex(cbDesde.Text);
            grafo.AddVertex(cbHasta.Text);
            grafo.AddEdge(cbDesde.Text, cbHasta.Text, peso);

            lbRutas.Items.Add($"{cbDesde.Text} <-> {cbHasta.Text} ({peso})");

            if (!cbDesde.Items.Contains(cbDesde.Text)) cbDesde.Items.Add(cbDesde.Text);
            if (!cbHasta.Items.Contains(cbHasta.Text)) cbHasta.Items.Add(cbHasta.Text);

            tbDistancia.Clear();
        }
    }
}
