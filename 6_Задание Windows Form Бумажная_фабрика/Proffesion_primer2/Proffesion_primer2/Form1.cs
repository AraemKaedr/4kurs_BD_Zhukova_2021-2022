using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proffesion_primer2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // готовим строку для подключения к БД
            string connStr = "server=192.168.4.211; user=student; database=morozov; password=12345; charset=utf8; SslMode=none;";

            // вводимый пользователем логин
            string login = textBox1.Text;
            // вводимый пользователем пароль
            string pass = textBox2.Text;

            // conn – экзепмляр класса подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // поиск введёного логина и пароля в базе данных в таблице users
            string logingbd = "SELECT Login,Password FROM users WHERE Login = '" + login + "' and Password = '" + pass + "';";

            MySqlCommand command = new MySqlCommand(logingbd, conn);


            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (login == "" || pass == "")
                {
                    MessageBox.Show("Заполните поле логина и пароля.", "Уведомления");
                }
                else
                {
                    MessageBox.Show("Вы вошли.\nПриятной Вам работы!", "Уведомления");
                }                
                    // запрос MySql
                    //string sql = "SELECT Password FROM users WHERE Login = 'loginDEaaf2018'";
                    // объект для выполнения SQL-запроса 
                    //MySqlCommand command = new MySqlCommand(sql, conn);
                    //выполняем запрос и получаем ответ
                    //string Password = command.ExecuteScalar().ToString();
                    //выводим ответ в консоль
                    //Console.WriteLine(Password);
                    //закрываем соединение с БД
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Введен неверный логин или пароль");
            }
            // прекращаем соединение с БД
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            String message = "Вы действительно хотите выйти?";
            String caption = "Выход";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterForm myForm = new RegisterForm();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
