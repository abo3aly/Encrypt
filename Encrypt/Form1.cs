using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string Encrypt(string password)
        {
            char[] pass = password.ToCharArray();
            string[] Sysb = { "*", "#", "&", "@", "%" };
            string NewPass = "";
            Random rm = new Random();
            for (int i = pass.Length - 1; i >= 0; i--)
            {
                NewPass += ((int)pass[i]).ToString() + Sysb[rm.Next(0, 5)];
            }

            return NewPass;
        }
        public static string Decrypt(string password)
        {
            string[] tokens = password.Split('*', '#', '&', '@', '%');
            string pass = "";

            for (int i = tokens.Length - 2; i >= 0; i--)
            {
                pass += ((char)Convert.ToInt32(tokens[i])).ToString();

            }
            return pass;

        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {

            if (txt_Encrypt.Text == "")
            {
                MessageBox.Show("ادخل المراد تشفيره");
                txt_Encrypt.Focus();
                return;
            }
            else
            {
                txt_Decrypt.Text = Encrypt(txt_Encrypt.Text);

            }
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            if (txt_Decrypt.Text == ""){
                MessageBox.Show("ادخل رموز التشفير");
                txt_Decrypt.Focus();
                return;
            }
            else
            {
                txt_Encrypt.Text = Decrypt(txt_Decrypt.Text);
            }

            
            
        }
    }
}
