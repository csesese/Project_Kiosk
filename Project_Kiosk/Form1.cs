using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Kiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_coffee_Click(object sender, EventArgs e)
        {
            Panel_coffee.Visible = true;
            Panel_Juice.Visible = false;
            Panel_etc.Visible = false;

           
        }

        private void Btn_juice_Click(object sender, EventArgs e)
        {

            Panel_Juice.Visible = true;
            Panel_etc.Visible = false;

        }

        private void Btn_etc_Click(object sender, EventArgs e)
        {
            Panel_Juice.Visible = false;
            Panel_etc.Visible = true;
        }


    }
}
