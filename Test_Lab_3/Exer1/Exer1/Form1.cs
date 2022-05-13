using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Exer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool IsValidPath(string path)
        {
            return ((Regex.IsMatch(path, @"^((^[a-zA-Z]?:)(\\\w[ \w.]|\\%[ \w.]+%+)+|%[ \w.]+%(\\\w[ \w.]|\\%[ \w.]+%+)*)") || 
                Regex.IsMatch(path, @"^[a-zA-Z]?:") || 
                Regex.IsMatch(path, @"^[a-zA-Z]?:")) && 
                path.IndexOf('/') == -1) ? true : false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                bool checking_the_validity_of_the_path = IsValidPath(textBox1.Text);
                if (checking_the_validity_of_the_path) // если валидный путь ->добавление в правый список
                    listBox1.Items.Add(textBox1.Text);
                else  // путь невалидный -> добавление в левый список
                    listBox2.Items.Add(textBox1.Text);
                textBox1.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Пустая строка!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Вы не выбрали строку для повторной проверки");
            else
                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                MessageBox.Show("Вы не выбрали строку для повторной проверки");
            else
                listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Вы не выбрали строку для повторной проверки");
            else
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
                MessageBox.Show("Вы не выбрали строку для повторной проверки");
            else
            {
                textBox1.Text = listBox2.SelectedItem.ToString();
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
