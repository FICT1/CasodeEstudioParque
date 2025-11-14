using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaArbol
{
    public partial class Form1 : Form
    {
        TreeNode nodo;

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

        }

        private void btnNivel_Click(object sender, EventArgs e)
        {

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
    }
}
