using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        class produto
        {
            public string nome;
            public double preco;
        }

        List<produto> LISTA_PRODUTOS;
        List<produto> LISTA_COMPRAS;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LISTA_PRODUTOS = new List<produto>(){
           
               new produto(){ nome = "cu do miracle", preco = 29.90},
               new produto(){ nome = "Remedio 2", preco = 19.90},
               new produto(){ nome = "Remedio 3", preco = 9.90},
               new produto(){ nome = "Remedio 4", preco = 59.90},
               new produto(){ nome = "Remedio 5", preco = 37.90},
               new produto(){ nome = "Remedio 6", preco = 21.90},
               new produto(){ nome = "Remedio 7", preco = 23.90},
               new produto(){ nome = "Remedio 8", preco = 90.99},
               new produto(){ nome = "Remedio 9", preco = 150.90},
               new produto(){ nome = "Remedio 10", preco = 220.90
},
           };

            foreach (produto p in LISTA_PRODUTOS)
            {
                lst_produtos.Items.Add(ConstruirLinhaProduto(p));
            }

            IniciarCompras();
        }

        private string ConstruirLinhaProduto(produto p)
        {
            string preco = p.preco.ToString("0.00") + " $";
            return p.nome + new string(' ', 50 - p.nome.Length - preco.Length) + preco;
        }
        
        private void IniciarCompras()
        {
            LISTA_COMPRAS = new List<produto>();
            lst_compras.Items.Clear();
            label_total.Text = "0,00 $";
        }
        private void lst_produtos_DoubleClick(object sender, EventArgs e)
        {
            if (lst_produtos.SelectedIndex == -1) return;
            produto p = LISTA_PRODUTOS[lst_produtos.SelectedIndex];
            AdicionarProdutoCompra(p);
        }

        private void AdicionarProdutoCompra(produto p)
        {
            LISTA_COMPRAS.Add(p);
            lst_compras.Items.Add(ConstruirLinhaProduto(p));

            var total = LISTA_COMPRAS.Sum(i => i.preco);
            label_total.Text = total.ToString("0.00") + "$";
        }

        private void cmd_nova_compra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nova compra iniciada" + Environment.NewLine);
            IniciarCompras();
        }

        private void cmd_finalizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compra Realizada Tenha um Otimo dia!!" + Environment.NewLine + label_total.Text);
            IniciarCompras();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lst_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
