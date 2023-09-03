using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcul_dimention_patch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
         InitializeComponent();
            button3.BackColor = Color.MediumTurquoise;
            panelAlimentation.Visible = true;
            panelAdaptation.Visible = false;
            comboBox1.Items.Add("mm");
            comboBox1.Items.Add("cm");
            comboBox1.Items.Add("m");
            comboBox2.Items.Add("Hz");
            comboBox2.Items.Add("MHz");
            comboBox2.Items.Add("GHz");
            comboBox1.Text = "mm";
            comboBox2.Text = "GHz";
            data2.Text = comboBox1.Text;
            data4.Text = comboBox1.Text;
            data5.Text = comboBox1.Text;
            largeurlignemicroruban2.Text = "0";
            label10.Text = "0";
            LongeurL1.Text = "0";
            LongeurL2.Text = "0";
            LargeurW1.Text = "0";
            LargeurW2.Text = "0";
            label17.Text = "0";
            largeurlignemicroruban1.Text = "0";
            largeurlignemicroruban2.Text = "0";
            label9.Text = "0";
            label12.Text = "0";
            label124.Text = "0";
            label13.Text = "0";
            label22.Text = "0";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double c = 300000000;
            double Fr = 0;
            double W = 0;
            double Er1 = 0;
            double Er2 = 0;
            double Eeff = 0;
            double Eeff1 = 0;
            double h = 0;
            double Leff = 0;
            double dl = 0;
            double L = 0;
            double Er3 = 0;
            double conv = 10;
            double conv1 = 0;
            double Er = 0;
            double Rin = 0;
            double B = 0;
            double k0 = 0;
            double C = 0;
            double C1 = 0;
            double C2 = 0;
            double C3 = 0;
            double pi = Math.PI;
            double A2 = 0;
            double C4 = 0;
            double t = 0;
            double rap = 0;
            double rap1 = 0;
            double N1 = 0;
            double N2 = 0;
            double N3 = 0;
            double w = 0;
            double ro = 0;
            double wc = 0;
            double Fcte = 8.791E18;
            double weff = 0;
            try
            {
                Fr = double.Parse(fréquence.Text.Replace(".", ",")); /*replacer . par ,*/
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Veuillez écrire une valeur de fréquence valide", "Valeur invalide"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("L'espace texte Fréquence de fonctionnement  doit contenir que des valeurs numériques", "Information"
, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Er = double.Parse(Permittivité.Text.Replace(".", ",")); /*replacer . par ,*/
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Veuillez écrire une valeur de Permittivité valide","Valeur invalide"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                MessageBox.Show("L'espace texte Permittivité relative εr doit contenir que des valeurs numériques", "Information"

, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            try
            {
                Rin = double.Parse(impédancederéference.Text.Replace(".", ","));
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Veuillez écrire une valeur de impédance de réference valide", "Valeur invalide"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("L'espace texte impédance de référence doit contenir que des valeurs numériques", "Information"

, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                t = double.Parse(épc.Text.Replace(".", ","));               
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Veuillez écrire une valeur de épaisseur du conducteur valide","Valeur invalide"

                    ,MessageBoxButtons.OK,MessageBoxIcon.Warning);

                MessageBox.Show("L'espace texte épaisseur du conducteur doit contenir que des valeurs numériques", "Information"

, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ;                
            }       
            try
            {
                h = double.Parse(épd.Text.Replace(".", ","));
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Veuillez écrire une valeur de épaisseur du diélectrique valide","Valeur invalide",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("l'espace texte épaisseur du diélectrique doit contenir que des valeurs numériques", "Information"

, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (comboBox2.Text == "MHz")
                {
                    conv1 = Math.Pow(conv, 6);
                    Fr = Fr * conv1;
                Fcte = Fcte*1E-06;
                }
                else
                {
                    if (comboBox2.Text == "GHz")
                    {
                        conv1 = Math.Pow(conv, 9);
                        Fr = Fr * conv1;
                    Fcte = Fcte * 1E-09;
                }                    
                }           
                if (comboBox1.Text == "mm")
                {
                    conv1 = Math.Pow(conv, -3);
                    h = h * conv1;
                }
                else
                {
                    if (comboBox1.Text == "cm")
                    {
                        conv1 = Math.Pow(conv, -2);
                        h = h * conv1;
                    }
                }
                Er1 = (Er + 1) / 2;
                Er2 = (Er - 1) / 2;
                Er3 = Math.Pow(Er1, -0.5); /*Er2=Er^(-0.5)*/
            double Er4 = Math.Pow(Er1, 0.5);
            double Er5 = Math.Pow(Er, 0.5);
            W = ((c * Er3) / (2 * Fr));
                double D = (1 + ((12 * h) / W));
                double A1 = Math.Pow(D, -0.5);
                double B1 =Math.Log((2*h/t));
                if (W / h > 1)
                {
                    Eeff = (Er2 * A1) + Er1;
                    Eeff1 = Math.Pow(Eeff, 0.5);
                    Leff = (c / (2 * Fr * Eeff1)); /*Eff1=Eff^(1/2)*/
                    dl = ((0.412 * h) * (Eeff + 0.3) * ((W / h) + 0.264)) / (((Eeff - 0.258) * ((W / h) + 0.8)));
                }
                else
                {
                    MessageBox.Show("Le rapport (largeur de l'élément rayonnent/épaisseur du diélectrique) doit être supérieur à 1", "Valeur invalide",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
                }
                double LANDA0 = c / Fr;
                k0 = (pi * 2) / LANDA0;
                A2 = (k0 * h);
               double E = Math.Pow(A2, 2);
                double G1 = (W * (1 - (E / 24))) / (120 * LANDA0);
                double A3 = Math.Log(A2);
                B1 = (W * (1 - (0.636 * C))) / (120 * LANDA0);
            double Rin0 = 1 / (2 * G1); ;
            //Rin0 = 322.22;
            C1 = Rin / Rin0;
                C2 = Math.Pow(C1, 0.5);
                C3 = Math.Acos(C2);                
                double A=((Rin*Er4/60))+(((Er-1)*(0.23+(0.11/Er)))/(Er+1));
                double N = Math.Exp(A);
                B = ((377 * pi) / (2 * Rin * Er5));
                N1 = Math.Exp(2*A);
                 N2 = Math.Log(B - 1);
                 N3 = Math.Log((2 * B) - 1);                
                 rap = (8 * N*h) / (N1 - 2);
                 rap1 = (((N2 + 0.39 - (0.61 / Er)) * (Er2 / Er)) + ((B - 1 - N3))) * (2*h / pi);                       
                label12.Text = Rin0.ToString("0.##");
                label13.Text = Rin0.ToString("0.##");                               
                if(rap<(2*h))
                {
                    weff=rap;
                }
                else
                {
                weff = rap1;
                }               
            double Rinc = Math.Pow(Rin * Rin0, 0.5);
             A1 = ((Rinc * Er4 / 60)) + (((Er - 1) * (0.23 + (0.11 / Er))) / (Er + 1));
            double N4 = Math.Exp(A1);
            double B2 = ((377 * pi) / (2 * Rinc * Er4));
            double N5 = Math.Exp(2 * A1);
            double N6 = Math.Log(B2 - 1);
            double N7 = Math.Log((2 * B2) - 1);
            double rap2 = (8 * N4 * h) / (N5 - 2);
            double rap3 = (((N6 + 0.39 - (0.61 / Er)) * (Er2 / Er)) + ((B2 - 1 - N7))) * (2 * h / pi);                      
            if (rap < (2 * h))
            {
                wc = rap2;
            }
            else
            {
                wc = rap3;
            }                      
            double LANDAG = c / (Fr * 4);
            if (comboBox1.Text == "mm")
                {
                double w1 = Math.Log((2 * h) / (t*0.001));
                weff = weff * 1000;
                w = weff - ((t * (1 + w1)) / pi);
                dl = dl * 1000;
                    Leff = Leff * 1000;
                    L = Leff - (2 * dl);
                    C4 = (C3 * L) / pi;                             
                W = W * 1000;                            
                LANDAG = LANDAG * 1000;
                wc=wc * 1000;
                double C5 = ((W - (3 * w))/ 2);
                label124.Text = wc.ToString("0.######");
                label22.Text = LANDAG.ToString("0.###");
                largeurlignemicroruban2.Text = w.ToString("0.###");
                    LongeurL1.Text = L.ToString("0.##");
                    LongeurL2.Text = L.ToString("0.##");
                    LargeurW1.Text = W.ToString("0.##");
                    LargeurW2.Text = W.ToString("0.##");
                    label17.Text = C4.ToString("0.##");
                    largeurlignemicroruban1.Text = w.ToString("0.###");
                    largeurlignemicroruban2.Text = w.ToString("0.###");
                    label9.Text = w.ToString("0.###");
                    label10.Text = C5.ToString("0.####");
            }
                else
                {
                    if (comboBox1.Text == "cm")
                    {
                    double w1 = Math.Log((2 * h) / (t*0.01));
                    weff = weff * 100;
                    w = weff - ((t * (1 + w1)) / pi);
                    dl = dl * 100;
                        Leff = Leff * 100;
                        L = Leff - (2 * dl);
                        C4 = (C3 * L) / pi;
                        ro = ro * 100;
                    W = W * 100;
                    wc = wc * 100;
                    double C5 = (W - (3 * w)) / 2;
                    label124.Text = wc.ToString("0.######");
                    largeurlignemicroruban2.Text = w.ToString("0.###");
                    largeurlignemicroruban2.Text = w.ToString("0.###");
                        LongeurL1.Text = L.ToString("0.##");
                        LongeurL2.Text = L.ToString("0.##");
                        LargeurW1.Text = W.ToString("0.##");
                        LargeurW2.Text = W.ToString("0.##");
                        label17.Text = C4.ToString("0.##");
                        largeurlignemicroruban1.Text = w.ToString("0.###");
                        label9.Text = w.ToString("0.###");
                        label10.Text = C5.ToString("0.######");
                    }
                    else
                {
                    double w1 = Math.Log((2 * h) / t);
                    w = weff - ((t * (1 + w1)) / pi);
                    L = Leff - (2 * dl);
                        C4 = (C3 * L) / pi;
                    double C5 = (W - (3 * w)) / 2; ;
                    label22.Text = LANDAG.ToString("0.###");
                    largeurlignemicroruban2.Text = w.ToString("0.###");
                    label10.Text = C5.ToString("0.##########");
                     LongeurL1.Text = L.ToString("0.##");
                        LongeurL2.Text = L.ToString("0.##");
                        LargeurW1.Text = W.ToString("0.##");
                        LargeurW2.Text = W.ToString("0.##");
                        label17.Text = C4.ToString("0.##");
                        largeurlignemicroruban1.Text = w.ToString("0.###");
                        largeurlignemicroruban2.Text = w.ToString("0.###");
                        label9.Text = w.ToString("0.###");
                    label124.Text = wc.ToString("0.######");
                }
                }
        }                                                 
        private void button3_Click(object sender, EventArgs e)
        {
            panelAlimentation.Visible = true;
            panelAdaptation.Visible = false;
            button3.BackColor = Color.MediumTurquoise;
            button4.BackColor = Color.Transparent;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelAdaptation.Visible = true;            
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.LightSteelBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fréquence.Text = "";
            Permittivité.Text = "";
            épd.Text = "";
            épc.Text = "";
            impédancederéference.Text = "";
            largeurlignemicroruban2.Text = "0";
            label10.Text = "0";
            LongeurL1.Text = "0";
            LongeurL2.Text = "0";
            LargeurW1.Text = "0";
            LargeurW2.Text = "0";
            label17.Text = "0";
            largeurlignemicroruban1.Text = "0";
            largeurlignemicroruban2.Text = "0";
            label9.Text = "0";
            label12.Text = "0";
            label124.Text = "0";
            label13.Text = "0";
            label22.Text = "0";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            data2.Text = comboBox1.Text;
            data4.Text = comboBox1.Text;
            data5.Text = comboBox1.Text;
            label11.Text= comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            data1.Text = comboBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Dimmention patch calculateur Version:1.0 build 04-18-2018 beta." + "\n" + "-Binome:sekkai samy. " + "\n" + "                Boudjema Mohamed Badreddine." + "\n" + "-Language de programmation  utilisé:C#" + "\n" + "-Theme du projet:Développement d'un programme de dimensionnement des antennes patch avec C Sharp." + "\n" + "-Projet pour diplôme de: licence en télécommunication", "Information sur le programme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panelAdaptation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void épd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}