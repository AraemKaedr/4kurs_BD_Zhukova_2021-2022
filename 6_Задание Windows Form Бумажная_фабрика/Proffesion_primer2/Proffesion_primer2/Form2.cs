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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            // готовим строку для подключения к БД
            string connStr = "server=192.168.4.211; user=student; database=morozov; password=12345; charset=utf8; SslMode=none;";
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                try
                {
                    // вводимая пользователем фамилия
                    string fam_pol = textBox1.Text;
                    // вводимое пользователем имя
                    string imo_pol = textBox2.Text;
                    // вводимый пользователем логин
                    string login_pol = textBox3.Text;
                    // вводимый пользователем пароль
                    string pass_pol = textBox4.Text;
                    // вводимая пользователем роль
                    //string rol_pol = textBox5.Text;

                    string sql = "INSERT INTO polzovateli (id_polzov, Familia, ImyaOtchestvo, Login, Password)" +
                   "VALUES (null, @Familia, @ImyaOtchestvo, @Login, @Password);";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    cmd.Parameters.AddWithValue("@Familia", fam_pol);
                    cmd.Parameters.AddWithValue("@ImyaOtchestvo", imo_pol);
                    cmd.Parameters.AddWithValue("@Login", login_pol);
                    cmd.Parameters.AddWithValue("@Password", pass_pol);
                    //cmd.Parameters.AddWithValue("@Role", rol_pol);
                    cmd.ExecuteNonQuery();

                    LoginForm myForm = new LoginForm();
                    this.Hide();
                    myForm.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm myForm = new LoginForm();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
