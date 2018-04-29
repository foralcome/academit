using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            nameSourceTemp.Items.Add("Цельсия");
            nameSourceTemp.Items.Add("Фаренгейта");
            nameSourceTemp.Items.Add("Кельвина");
            nameSourceTemp.SelectedIndex = 0;

            nameDestinationTemp.Items.Add("Цельсия");
            nameDestinationTemp.Items.Add("Фаренгейта");
            nameDestinationTemp.Items.Add("Кельвина");
            nameDestinationTemp.SelectedIndex = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private double CelciumToFarengeit(double t)
        {
            //Цельсий х 1,8 + 32 = Фаренгейт
            return (double)(t * 1.8 + 32);
        }
        private double CelciumToKelvin(double t)
        {
            //Цельсий х 1,8 + 32 = Фаренгейт
            return (double)(t + 273.15);
        }

        private double FarengeitToCelcium(double t)
        {
            //(Фаренгейт — 32) : 1,8
            return (double)(t - 32) / 1.8;
        }
        private double FarengeitToKelvin(double t)
        {
            //Цельсий х 1,8 + 32 = Фаренгейт
            return CelciumToKelvin(FarengeitToCelcium(t));
        }

        private double KelvinToCelcium(double t)
        {
            //Цельсий х 1,8 + 32 = Фаренгейт
            return (double)(t - 273.15);
        }

        private double KelvinToFarengeit(double t)
        {
            //Цельсий х 1,8 + 32 = Фаренгейт
            return (double)CelciumToFarengeit(KelvinToCelcium(t));
        }


        private void StartConvertor_Click(object sender, EventArgs e)
        {
            

            if (nameSourceTemp.SelectedIndex == nameDestinationTemp.SelectedIndex)
            {
                valueDestinationTemp.Text = valueSourceTemp.Text;
            }
            else
            {
                double result = 0.0;

                switch (nameSourceTemp.SelectedIndex)
                {
                    case 0:
                        if (nameDestinationTemp.SelectedIndex == 1)
                        {
                            result = CelciumToFarengeit(Convert.ToDouble(valueSourceTemp.Text));
                        }
                        else if (nameDestinationTemp.SelectedIndex == 2)
                        {
                            result = CelciumToKelvin(Convert.ToDouble(valueSourceTemp.Text));
                        }
                        break;
                    case 1:
                        if (nameDestinationTemp.SelectedIndex == 0)
                        {
                            result = FarengeitToCelcium(Convert.ToDouble(valueSourceTemp.Text));
                        }
                        else if (nameDestinationTemp.SelectedIndex == 2)
                        {
                            result = FarengeitToKelvin(Convert.ToDouble(valueSourceTemp.Text));
                        }
                        break;
                    case 2:
                        if (nameDestinationTemp.SelectedIndex == 0)
                        {
                            result = KelvinToCelcium(Convert.ToDouble(valueSourceTemp.Text));
                        }
                        else if (nameDestinationTemp.SelectedIndex == 1)
                        {
                            result = KelvinToFarengeit(Convert.ToDouble(valueSourceTemp.Text));
                        }
                        break;
                    default:
                        break;
                }

                valueDestinationTemp.Text = result.ToString();
            }
        }

        private void nameSourceTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueDestinationTemp.Text = "";
        }

        private void nameDestinationTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueDestinationTemp.Text = "";
        }

        private void valueSourceTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                // && !Char.IsControl(number)
                if (number == '-' && valueSourceTemp.SelectionStart==0 && !valueSourceTemp.Text.Contains("-"))
                {
                    e.Handled = false;
                }
                else if (number == '.' && !valueSourceTemp.Text.Contains('.'))
                {
                    e.Handled = false;
                }
                else
                {
                    MessageBox.Show("Это поле может содержать только число!");
                    e.Handled = true;
                }
            }
        }
    }
}
