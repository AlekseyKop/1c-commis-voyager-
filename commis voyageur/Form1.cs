using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace commis_voyageur
{
    public partial class MainForm : Form
    {
        //количество городов
        int n = 0;
        Alghoritms mc = new Alghoritms();
        public MainForm()
        {
            InitializeComponent();
        }

        // блокировка/разблокировка кнопок
        private void SetInterfaceState(bool state)
        {
            butMurovei.Enabled = state;
            butFullPerebor.Enabled = state;
            butGeneration.Enabled = state;
        }
        // добавление городов по одному вручную
        private void butAddOneCity_Click(object sender, EventArgs e)
        {
            void AddOneCity(int i)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Columns.Add("newColumnName", "");
                dataGridView1.Rows[i].HeaderCell.Value = textCity.Text;
                dataGridView1.Columns[i].HeaderCell.Value = textCity.Text;
            }
            bool flag = true;
            for (int i = 0; (flag) && (i < textCity.Text.Length); i++)
            {
                flag = Char.IsLetter(textCity.Text[i]);
            };
            if ((flag) && (textCity.Text.Length != 0))
            {
                AddOneCity(n);
                textCity.Clear();
                n++;
            }
            else
                MessageBox.Show("Введено недопустимое значение!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (n == 2)
            {
                butGeneration.Enabled = true;
            }
            if (n==4)
            {
                butAddOneCity.Enabled = false;
                butAddCities.Enabled = false;
            }
        }
        // условие
        private void butUslovie_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Комивояжер. Торговец выходит из города 1 и в случайном порядке посещает города 2,3,4..N.\n" +
                            "Потом возвращается в первый город.Найти самый кратчайший путь.\n" +
                            "Известна матрица расстояний между городами.\n" +
                            "Перестановки генерируются в лексикографическом порядке.\n" +
                            "Решить задачу 2умя способами - полным перебором и муравьиным алгоритмом.\n" +
                            "Сравнить скорость работы.",
              "Условие", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // добавление городов из файла 
        private void butAddCities_Click(object sender, EventArgs e)
        {
            string[] str;
            StreamReader f = new StreamReader("1.txt", Encoding.GetEncoding(1251));
            {
                str = f.ReadToEnd().Split(new Char[] { ' ', '\n', '\r' });
                int pos = 0;
                for (int i = 0; (i <= dataGridView1.RowCount - 1) && (str.Length != pos); i++)
                {
                    while (str[pos] == "")
                    {
                        pos++;
                    }
                    dataGridView1.Rows.Add();
                    dataGridView1.Columns.Add("newColumnName", "");
                    dataGridView1.Rows[i].HeaderCell.Value = str[pos];
                    dataGridView1.Columns[i].HeaderCell.Value = str[pos];
                    n++;
                    pos++;
                }
                f.Close();
            }
            butGeneration.Enabled = true;
            if (n==4)
            {
                butAddOneCity.Enabled = false;
                butAddCities.Enabled = false;
            }
        }
        // генерация путей (односторонних)
        private void butGeneration_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; (i <= n - 1); i++)
                for (int j = 0; (j <= n - 1); j++)
                {
                    if (i == j)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = "0";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(rand.Next(10, 250));
                    }
                };
            butMurovei.Enabled = true;
            butFullPerebor.Enabled = true;

        }
        //очистка формы
        private void butClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;
            n = 0;
            textBox1.Clear();
            SetInterfaceState(false);
            butAddOneCity.Enabled = true;
            butAddCities.Enabled = true;
        }
        //реализация через "муравьиный алгоритм"
        private void butMurovei_Click(object sender, EventArgs e)
        {
            List<int> X = new List<int>();
            string cities = "";
            int min = 0;
            int[,] TR = new int[dataGridView1.ColumnCount - 1, dataGridView1.ColumnCount - 1];
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    TR[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
            DateTime FirstTime = DateTime.Now;
            X = mc.GetMinPutMuravii(ref TR, ref min);
            DateTime SecondTime = DateTime.Now;
            string time = Convert.ToString(SecondTime.Subtract(FirstTime).TotalSeconds);
            for (int i = 0; i < n; i++)
            {
                cities = cities + dataGridView1.Rows[X[i] - 1].HeaderCell.Value.ToString() + Environment.NewLine;
            }

            textBox1.Text += Environment.NewLine + "Муравьиный алгоритм" + Environment.NewLine + "Минимальное Расстояние:" + Environment.NewLine + Convert.ToString(min) + Environment.NewLine + cities + Environment.NewLine + "Время работы:" + Environment.NewLine + time + Environment.NewLine;
        }
        //реализация через полный перебор
        private void butFullPerebor_Click(object sender, EventArgs e)
        {
            List<int> X = new List<int>();
            string cities = "";
            int min = 0;
            int[,] TR = new int[dataGridView1.ColumnCount - 1, dataGridView1.ColumnCount - 1];
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    TR[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
            DateTime FirstTime = DateTime.Now;
            X = mc.GetMinPut(TR, ref min);
            DateTime SecondTime = DateTime.Now;
            string time = Convert.ToString(SecondTime.Subtract(FirstTime).TotalSeconds);
            for (int i = 0; i < n; i++)
            {
                cities = cities + dataGridView1.Rows[X[i]-1].HeaderCell.Value.ToString()+ Environment.NewLine;
            }

            textBox1.Text += Environment.NewLine + "Полный перебор" + Environment.NewLine + "Минимальное Расстояние:" + Environment.NewLine + Convert.ToString(min) + Environment.NewLine + cities + Environment.NewLine + "Время работы:" + Environment.NewLine + time + Environment.NewLine + "--------------------";
        }
        //при загрузке формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetInterfaceState(false);
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;
           
        }
    }
}
