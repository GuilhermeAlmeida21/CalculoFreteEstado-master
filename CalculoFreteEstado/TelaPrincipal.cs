using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoFreteEstado
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }


        decimal frete = 0;
       private void CalcularFrete()
        {
                switch (cbEstado.Text.ToUpper())
                {
                case "Escolha UF":
                    frete = 0.0m;
                    break;
                    case "AM":
                        frete = 0.6m;
                        break;
                    case "MG":
                        frete = 0.35m;
                        break;
                    case "RJ":
                        frete = 0.30m;
                        break;
                    case "SP":
                        frete = 0.20m;
                        break;
                    default:
                        frete = 0.70m;
                        break;
                }
            
            // N3 é para colocar os valores em decimal com 3 casas

            txtPorcento.Text = frete.ToString("P0");

            //lblResultado.Text = (frete * (1 + porcentagem)).ToString("c2");

        }

        private void LimparTudo()
        {
            txtNome.Text = string.Empty;
            txtValor.Text = string.Empty;
            cbEstado.SelectedIndex = -1;
            txtPorcento.Text = string.Empty;
            lblResultado.Text = string.Empty;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal valor = 0;

            

            if(txtValor.Text == "")
            {
                MessageBox.Show("O valor está em branco");
            }
            else
            {
                valor = Convert.ToDecimal(txtValor.Text);
                //decimal = Convert.ToDecimal(txtValor.Text = (valor * (frete + 1)).ToString();
                lblResultado.Text = (valor * (frete + 1)).ToString("c2");
            }


            if (txtNome.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Nome é  obrigatório", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return;
            }

            if (txtValor.Text.Trim().Equals(""))
            {
                MessageBox.Show("O campo Valor é  obrigatório", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValor.Focus();
                return;
            }

           
        }
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
          CalcularFrete();
        }

      

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            cbEstado.SelectedIndex = 0;        
        }

        private void TelaPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                LimparTudo();
            }
        }
    }
}
