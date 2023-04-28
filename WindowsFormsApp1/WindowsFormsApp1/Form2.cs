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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Rastchet5.InputInt(textBox1);
            int min = Rastchet5.InputInt(textBox1);
            int max = Rastchet5.InputInt(textBox1);
            int[] arr = new int[n];
            Rastchet5.Enter_mas(arr, n, min, max);
            textBox4.Text = Convert.ToString(Rastchet6.IsDecreasing(arr, n));
            int[] newarr = new int[n];
            Rastchet6.sort_Sheker_mas(arr, n);
            Rastchet5.Output_mas(newarr, n, dataGridView2);
            Rastchet6.InsertionSort(arr);
            Rastchet5.Output_mas(arr, n, dataGridView3);
            Rastchet6.SelectionSort(newarr);
            Rastchet5.Output_mas(newarr, n, dataGridView6);
            Rastchet5.Enter_mas(arr, n, min, max);
            Rastchet6.BubbleSort(arr);
            Rastchet5.Output_mas(arr, n, dataGridView5);
            Rastchet5.Enter_mas(arr, n, min, max);
            Rastchet6.ImprovedBubbleSort(arr);
            Rastchet5.Output_mas(arr, n, dataGridView4);
            Rastchet5.Enter_mas(arr, n, min, max);
            Rastchet6.BinaryInsertionSort(arr);
            Rastchet5.Output_mas(arr, n, dataGridView8);
            Rastchet6.RemoveMaxElement(ref arr, ref n);
            Rastchet5.Output_mas(arr, n, dataGridView7);
            Rastchet6.Add_pdf(n, arr);
            Rastchet6.ZapisBloknot(n, arr);
        }
    }
}
