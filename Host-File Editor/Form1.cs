using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Host_File_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dgv.Columns.Add(chk);
            chk.HeaderText = "#";
            dgv.Columns.Add("spIP", "IP");
            dgv.Columns.Add("spName", "Name");
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Breite auf 100%
            //this.dgv.Columns[2].AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            string path = @"C:\Windows\System32\drivers\etc\hosts";
            string[] s = File.ReadAllLines(path);
            foreach (string x in s)
            {
                string y = x.Replace("\t", " ");
                while (y.IndexOf("  ") > 0)
                {
                    y = y.Replace("  ", " ");
                }
                string[] lines = y.Split(' ');

                bool status = true;
                string ip = lines[0];
                string host = lines[1];

                if(ip == "#")
                {
                    status = false;
                    ip = lines[1];
                    host = lines[2];
                }
                dgv.Rows.Add(status, ip, host);

            }
        }
        private void cmdSpeichern_Click(object sender, EventArgs e)
        {

        }
    }
}
