using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            butAddCities.Enabled = false;
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
            panel1.Visible = true;

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
            butAddCities.Enabled = true;
            panel1.Visible = false;
        }

        //при загрузке формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;
            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = 1;
            panel1.Visible = false;
            dataGridView2.Rows.Add();
            dataGridView2.Columns.Add("newColumnName", "");
            dataGridView2.Rows[0].HeaderCell.Value = "t";
            dataGridView2.Rows[1].HeaderCell.Value = "S";
            dataGridView2.Columns[0].HeaderCell.Value = "Полный перебор";
            dataGridView2.Columns[1].HeaderCell.Value = "Муравьиный алгоритм";
        }

        private void CallFunAntAlg()
        {
            int alfa, beta;
            double startph, p_isp;
            while (!(int.TryParse(textBox2.Text, out alfa)))
            {
                MessageBox.Show("Введено недопустимое значение!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                return;

            }
            while (!(int.TryParse(textBox3.Text, out beta)))
            {
                MessageBox.Show("Введено недопустимое значение!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
                return;
            }
            while ((!double.TryParse(textBox5.Text, out p_isp)) || (!(p_isp >= 0) || !(p_isp <= 1)))
            {
                MessageBox.Show("Введено недопустимое значение!",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Text = "";
                return;
            }
            while (!(double.TryParse(textBox6.Text, out startph)) && (startph != 0))
            {
                MessageBox.Show("Введено недопустимое значение!",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Text = "";
                return;
            }
            List<int> X = new List<int>();
            string cities1 = "";
            int min1 = 0;
            int[,] TR = new int[dataGridView1.ColumnCount - 1, dataGridView1.ColumnCount - 1];
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    TR[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
            DateTime FirstTime1 = DateTime.Now;
            X = mc.FindWayAntAlgorithm(ref TR, ref min1, alfa, beta, p_isp, startph);
            DateTime SecondTime1 = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                cities1 = cities1 + dataGridView1.Rows[X[i] - 1].HeaderCell.Value.ToString() + Environment.NewLine;
            }
            textBox1.Invoke(new Action(() => { textBox1.Text += Environment.NewLine + "Муравьиный алгоритм:" + Environment.NewLine + "Минимальный Путь:" + Environment.NewLine + cities1 + "--------------------"; }));
            string time1 = Convert.ToString(SecondTime1.Subtract(FirstTime1).TotalSeconds);
            dataGridView2.Rows[0].Cells[1].Value = time1;
            dataGridView2.Rows[1].Cells[1].Value = Convert.ToString(min1);
        }

        private void CallFunEs()
        {
            List<int> Es = new List<int>();
            string cities2 = "";
            int min2 = 0;
            int[,] TR = new int[dataGridView1.ColumnCount - 1, dataGridView1.ColumnCount - 1];
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    TR[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
            DateTime FirstTime2 = DateTime.Now;
            Es = mc.FindMinWayExhaustiveSearch(TR, ref min2);
            DateTime SecondTime2 = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                cities2 = cities2 + dataGridView1.Rows[Es[i] - 1].HeaderCell.Value.ToString() + Environment.NewLine;
            }
            textBox1.Invoke(new Action(() => { textBox1.Text += Environment.NewLine + "Полный перебор:" + Environment.NewLine + "Минимальный Путь:" + Environment.NewLine + cities2 + "--------------------"; }));
            string time2 = Convert.ToString(SecondTime2.Subtract(FirstTime2).TotalSeconds);
            dataGridView2.Rows[0].Cells[0].Value = time2;
            dataGridView2.Rows[1].Cells[0].Value = Convert.ToString(min2);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(CallFunAntAlg);
            Thread thread2 = new Thread(CallFunEs);
            thread1.Start();
            thread2.Start();


        }
    }
}
