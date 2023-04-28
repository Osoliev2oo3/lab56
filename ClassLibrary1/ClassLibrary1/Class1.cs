using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace ClassLibrary1
{
    public class Rastchet5
    {
        public static int InputInt(TextBox t)
        {
            return Convert.ToInt32(t.Text);
        }
        // Генерация массива
        public static void Enter_mas(int[] mas, int length, int a, int b)
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                mas[i] = rnd.Next(a, b);
            }
        }
        // Вывод исходного массива
        public static void Output_mas(int[] mas, int length, DataGridView grid)
        {
            grid.ColumnCount = length;
            grid.RowCount = 2;
            for (int i = 0; i < length; i++)
            {
                grid.Rows[0].Cells[i].Value = "[" + i + "]";
                grid.Rows[1].Cells[i].Value = mas[i];
            }
        }
        // Нахождение суммы индексов максимального и минимального элементов
        public static int FindSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]%3 == 0 && array[i]%4 != 0)
                {
                    sum += array[i];
                }
            }
            return sum;
        }
        // Вывод нового массива
        public static void Set_mas(int[] newArray, int c, out int j, int[] rezmas)
        {
            j = 0;
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                if (newArray[i] > c)
                {
                    rezmas[j] = newArray[i];
                    j++;
                }
            }
        }
    }   
    public class Rastchet6
    {
        //Удаления максимального элемента в массиве
        public static void RemoveMaxElement(ref int[] arr, ref int n)
        {
            int maxIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }
            for (int i = maxIndex; i < n - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            n--;
        }
        //проверка на монотоность
        public static bool IsDecreasing(int[] arr, int n)
        {
            int i = 0;
            bool flag = true;
            while (i < n - 1 && flag)
            {
                if (arr[i] >= arr[i + 1])
                {
                    i++;
                }
                else { flag = false; }
            }
            return flag;
        }
        //Сортировка простой вставкой 
        public static void InsertionSort(int[] array)
        {
            for (int i = 2; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                array[0] = key;
                while (key < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
        //сортировка бинарными вставками
        public static void BinaryInsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int left = 0;
                int right = i - 1;
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (array[mid] > key)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                for (int j = i - 1; j >= left; j--)
                {
                    array[j + 1] = array[j];
                }
                array[left] = key;
            }
        }
        //Сортировка простым выбором
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int x = array[i];
                int k = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < x)
                    {
                        x = array[j];
                        k = j;
                    }
                }
                array[k] = array[i];
                array[i] = x;
            }
        }
        //сортировка простым обменом(1 способ)
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        //сортировка простым обменом(2 способ)
        public static void ImprovedBubbleSort(int[] array)
        {
            int n = array.Length;
            int m = n - 1;
            bool Flag = true;
            while (Flag && m > 1)
            {
                Flag = false;
                for (int i = 0; i < m; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        Flag = true;
                    }
                }
                m--;
            }
        }
        public static void Add_pdf(int lenght, params int[] mas)
        {
            var Document = new Document();
            var Zap = PdfWriter.GetInstance(Document, new
           System.IO.FileStream("Massivs.pdf", System.IO.FileMode.Create));
            Document.Open();
            var Shrift = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\times.ttf", "CP1251", BaseFont.EMBEDDED);

            var ft = new Font(Shrift, 10, Font.NORMAL, BaseColor.BLUE);
            var tabl = new PdfPTable(1);
            var cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Colspan = 2;
            cell.Border = 0;
            cell.FixedHeight = 16.0F;
            cell.Phrase = new Phrase("Одномерные массивы", ft);
            tabl.AddCell(cell);
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.Colspan = 1;
            cell.Border = 15;
            for (int i = 0; i < lenght; i++)
            {
                cell.Phrase = new Phrase(mas[i].ToString(), ft);
                tabl.AddCell(cell);
            }
            tabl.TotalWidth = Document.PageSize.Width - 400;
            tabl.WriteSelectedRows(0, -1, 40, Document.PageSize.Height - 30,
           Zap.DirectContent);
            Document.Close();
            Zap.Close();
            System.Diagnostics.Process.Start("IExplore.exe",
            System.IO.Directory.GetCurrentDirectory() + @"\Massivs.pdf");
        }
        public static void ZapisBloknot(int length, params int[] mas)
        {
            StreamWriter rez = File.CreateText("Исходный массив.txt");
            for (int i = 0; i < length; i++)
                rez.WriteLine(mas[i]);
            rez.Close();
            System.Diagnostics.Process.Start("Исходный массив.txt");
        }
        //Сортировка методом шейкера
        public static void sort_Sheker_mas(int[] arr, int n)
        {
            int left = 0, right = n - 1, k = n - 1;

            while (left < right)
            {
                // проход справа налево
                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        k = i;
                    }
                }
                left = k + 1;

                // проход слева направо
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        k = i;
                    }
                }
                right = k - 1;
            }
        }
    }
}
