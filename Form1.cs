using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ArrayList a_jogo;/*Jogo individual*/
        ArrayList T_jogo;/*Total de jogos*/
        ArrayList a_sorteado;
        ArrayList Cartela = new ArrayList();
        int sorteio = 1;
        int identificador = 1;
        int nr_max;
        bool b_novo = true;

        public Form1()
        {
            InitializeComponent();
            nr_max = 0;
            a_jogo = new ArrayList();/*Jogo individual*/
            T_jogo = new ArrayList();/*Total de jogos*/
        }

        public void VerificaNroMaximo(CheckBox ch, int number)
        {
            if (b_novo)
            {

                if (ch.Checked)
                {
                    nr_max++;
                    a_jogo.Add(number);
                }
                else
                {
                    nr_max--;
                    a_jogo.Remove(number);
                }

                if (nr_max > Convert.ToInt32(txt_Jogos.Text))
                {
                    MessageBox.Show("O número máximo de números por jogo é de:" + txt_Jogos.Text);
                }
                else
                {
                    if (nr_max == Convert.ToInt32(txt_Jogos.Text))
                    {
                        InserirJogo();
                    }

                }
            }
            return;
        }


        public void InserirJogo()
        {
            if (nr_max < Convert.ToInt32(txt_Jogos.Text) || nr_max > Convert.ToInt32(txt_Jogos.Text))
            {
                MessageBox.Show("A Quantidade de Números escolhidos deve ser : " + txt_Jogos.Text + " números e você escolheu só " + nr_max + " números.");
                return;
            }


            if (!VerificaRepeticao())
            {
                T_jogo.Add(identificador);
                T_jogo.Add(a_jogo);
                T_jogo.Add("Horário: " + DateTime.Now.ToString());
                Cartela.Add(T_jogo);
                identificador++;
                nr_max = 0;
                InserirJogo_lista();
                Limpar();
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Este jogo já existe. Favor escolha novos jogos.");
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GerarAutomatico();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InserirJogo();

        }
        public void Limpar()
        {
            b_novo = false;
            Limpar_Jogo(nr1); Limpar_Jogo(nr2); Limpar_Jogo(nr3); Limpar_Jogo(nr4); Limpar_Jogo(nr5); Limpar_Jogo(nr6);
            Limpar_Jogo(nr7); Limpar_Jogo(nr8); Limpar_Jogo(nr9); Limpar_Jogo(nr10); Limpar_Jogo(nr11); Limpar_Jogo(nr12);
            Limpar_Jogo(nr13); Limpar_Jogo(nr14); Limpar_Jogo(nr15); Limpar_Jogo(nr16); Limpar_Jogo(nr17); Limpar_Jogo(nr18);
            Limpar_Jogo(nr19); Limpar_Jogo(nr20); Limpar_Jogo(nr21); Limpar_Jogo(nr22); Limpar_Jogo(nr23); Limpar_Jogo(nr24);
            Limpar_Jogo(nr25); Limpar_Jogo(nr26); Limpar_Jogo(nr27); Limpar_Jogo(nr28); Limpar_Jogo(nr29); Limpar_Jogo(nr30);
            Limpar_Jogo(nr31); Limpar_Jogo(nr32); Limpar_Jogo(nr33); Limpar_Jogo(nr34); Limpar_Jogo(nr35); Limpar_Jogo(nr36);
            Limpar_Jogo(nr37); Limpar_Jogo(nr38); Limpar_Jogo(nr39); Limpar_Jogo(nr40); Limpar_Jogo(nr41); Limpar_Jogo(nr42);
            Limpar_Jogo(nr43); Limpar_Jogo(nr44); Limpar_Jogo(nr45); Limpar_Jogo(nr46); Limpar_Jogo(nr47); Limpar_Jogo(nr48);
            Limpar_Jogo(nr49); Limpar_Jogo(nr50); Limpar_Jogo(nr51); Limpar_Jogo(nr52); Limpar_Jogo(nr53); Limpar_Jogo(nr54);
            Limpar_Jogo(nr55); Limpar_Jogo(nr56); Limpar_Jogo(nr57); Limpar_Jogo(nr58); Limpar_Jogo(nr59); Limpar_Jogo(nr60);
            b_novo = true;
            a_jogo = new ArrayList();/*Jogo individual*/
            T_jogo = new ArrayList();/*Total de jogos*/
        }
        private void Limpar_Jogo(CheckBox ch)
        {
            ch.Checked = false;
        }

        public void ValidarEscolha(object sender, EventArgs e)
        {
            VerificaNroMaximo((System.Windows.Forms.CheckBox)sender, PegaNumero(sender));
        }

        private void InserirJogo_lista()
        {
            int contador = 1;
            string jogo = "";
            jogo = "SEQ: " + T_jogo[0] + " Jogo:( ";
            foreach (object a in a_jogo)
            {
                if (contador < Convert.ToInt32(txt_Jogos.Text))
                {
                    jogo = jogo + a.ToString() + "-";
                }
                else
                {
                    if (contador >= Convert.ToInt32(txt_Jogos.Text))
                    {
                        jogo = jogo + a.ToString() + " ) ";
                    }
                }

                contador++;
            }
            jogo = jogo + T_jogo[2];
            listBox1.Items.Add(jogo);
        }

        private int PegaNumero(object sender)
        {
            string nome_check = ((System.Windows.Forms.ButtonBase)(sender)).Text;
            int nro_check = Convert.ToInt32(nome_check);
            return nro_check;
        }

        private bool VerificaRepeticao()
        {
            bool encontrou = false;
            bool existe = false;
            foreach (ArrayList a in Cartela)
            {
                ArrayList b = (ArrayList)a[1];//Pra cada Jogo da cartela

                b.Sort();
                a_jogo.Sort();

                for (int i = 0; i < Convert.ToInt32(txt_Jogos.Text); i++)
                {
                    if (Convert.ToInt32(b[i]) == Convert.ToInt32(a_jogo[i]))
                    {

                        existe = true;
                        continue;
                    }
                    else
                    {
                        existe = false;
                        break;
                    }
                }
                if (existe && !encontrou)
                {
                    encontrou = true;
                }
            }
            return encontrou;
        }
        public void GerarAutomatico()
        {

            int i = 1;
            int x;
            Random gerador = new Random();
            while (i <= Convert.ToInt32(txt_Jogos.Text))
            {
                x = gerador.Next(1, Convert.ToInt32(txt_Maximo.Text));
                if (!a_jogo.Contains(x))
                {
                    a_jogo.Add(x);
                    i++;
                    nr_max++;
                }
            }
            if (!VerificaRepeticao())
            {
                InserirJogo();
            }
            else
            {
                a_jogo.Clear();
                GerarAutomatico();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a_sorteado = new ArrayList();
            int i = 1;
            int x;
            Random gerador = new Random();
            while (i <= Convert.ToInt32(txt_Jogos.Text))
            {
                x = gerador.Next(1, Convert.ToInt32(txt_Maximo.Text));
                if (!a_sorteado.Contains(x))
                {
                    a_sorteado.Add(x);
                    i++;
                }
            }
            a_sorteado.Sort();

            int contador = 1;
            string jogo = "";
            foreach (object a in a_sorteado)
            {
                if (contador < Convert.ToInt32(txt_Jogos.Text))
                {
                    jogo = jogo + a.ToString() + "-";
                }
                else
                {
                    if (contador >= Convert.ToInt32(txt_Jogos.Text))
                    {
                        jogo = jogo + a.ToString();
                    }
                }

                contador++;
            }

            txtsorteados.Text = "Sorteio N°("+sorteio +") "+ jogo;
            sorteio++;

        }


        private void RecuperaGanhadores()
        {
            int acertos;
            bool sena = false, quadra = false, quina = false;
            string s_resultado = "";
            ArrayList a_ganhadores = new ArrayList();
            a_ganhadores.Add("Ganhador Quadra: ");
            a_ganhadores.Add("Ganhador Quina: ");
            a_ganhadores.Add("Ganhador Sena: ");
            foreach (ArrayList a in Cartela)
            {
                acertos = 0;
                ArrayList b = (ArrayList)a[1];//Pra cada Jogo da cartela

                b.Sort();
                a_sorteado.Sort();

                for (int i = 0; i < Convert.ToInt32(txt_Jogos.Text); i++)
                {
                    for (int j = 0; j < Convert.ToInt32(txt_Jogos.Text); j++)
                    {
                        if (Convert.ToInt32(b[i]) == Convert.ToInt32(a_sorteado[j]))
                        {

                            acertos++;
                        }
                    }
                }

                if (acertos == 4)
                {
                    a_ganhadores[0] += a[0] + ",";
                    quadra = true;
                }
                else if (acertos == 5)
                {
                    a_ganhadores[1] += a[0] + ",";
                    quina = true;
                }
                else if (acertos == 6)
                {
                    a_ganhadores[2] += a[0] + ",";
                    sena = true;
                }
            }


            if (!sena && !quina && !quadra)
            {
                MessageBox.Show("Não Houveram Ganhadores");
            }
            else
            {
                if (sena)
                { s_resultado = "\n" + a_ganhadores[2]; }
                if (quina)
                { s_resultado += "\n" + a_ganhadores[1]; }
                if (quadra)
                { s_resultado += "\n"+ a_ganhadores[0]; }

                MessageBox.Show("Atenção para os Ganhadores." + s_resultado + " .");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RecuperaGanhadores();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

      
       


    }
}
