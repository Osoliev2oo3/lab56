using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Rastchet5.InputInt(textBox1);
            int min = Rastchet5.InputInt(textBox2);
            int max = Rastchet5.InputInt(textBox3);
            int[] arr = new int[n];
            Rastchet5.Enter_mas(arr,n,min,max);
            Rastchet5.Output_mas(arr, n, dataGridView1);
            int sum = Rastchet5.FindSum(arr);
            int[] newarr = new int[n];
            Rastchet5.Set_mas(arr, n, out int m, newarr);
            Rastchet5.Output_mas(newarr, m, dataGridView2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2= new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
