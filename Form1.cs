using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchnuppiProjekt
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        CheckBox[] checkBoxes;

        public enum ReservierungsStatus
        {
            Reserved = 0,
            Bought = 1 
        }

        public int Wallet = 0;

        public int KinoWallet = 0;

        public int Price = 15;

        public Form1()
        {
            InitializeComponent();
            checkBoxes = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26 };
            
            Wallet = rnd.Next(100, 400);

            textBox2.Text = Wallet.ToString();

            textBox1.Text = KinoWallet.ToString();
        }

        private void btnReservieren_Click(object sender, EventArgs e)
        {

            for(int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    if(checkBoxes[i].Tag != ReservierungsStatus.Reserved.ToString() && checkBoxes[i].Tag != ReservierungsStatus.Bought.ToString())
                    {
                        checkBoxes[i].BackColor = Color.Green;
                        checkBoxes[i].Tag = ReservierungsStatus.Reserved.ToString();
                        checkBoxes[i].Checked = false;
                    }
                }
            }
        }

        private void btnKaufen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    if(checkBoxes[i].Tag != ReservierungsStatus.Bought.ToString())
                    {
                        if(Wallet >= Price)
                        {
                            checkBoxes[i].BackColor = Color.Red;
                            checkBoxes[i].Tag = ReservierungsStatus.Bought.ToString();
                            checkBoxes[i].Checked = false;

                            Wallet -= Price;
                            KinoWallet += Price;

                            textBox2.Text = Wallet.ToString();

                            textBox1.Text = KinoWallet.ToString();
                        }
                        else
                        {
                            MessageBox.Show("u broke bitch!");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Sorry this Seat is already taken.");
                    }
                }
            }
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DropDown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
