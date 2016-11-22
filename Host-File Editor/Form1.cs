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
        //Pfad definieren
        private string path = @"C:\Windows\System32\drivers\etc\hosts";

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dgv.Columns.Add(chk);
            chk.HeaderText = "#";
            dgv.Columns.Add("spIP", "IP");
            dgv.Columns.Add("spName", "Name");
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Daten einlesen
            readFile(path);


        }
        
        private void readFile(string path)
        {
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

                if (ip == "#")
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
            //Bestehende Daten löschen
            //File.WriteAllText(path, String.Empty);

            TextWriter writer = new StreamWriter(path);
            for (int ir = 0; ir < dgv.Rows.Count - 1; ++ir)
            {
                string status = dgv.Rows[ir].Cells[0].Value.ToString();
                if (status == "False") {
                    writer.Write("# ");
                }
                writer.Write(dgv.Rows[ir].Cells[1].Value.ToString() + " ");
                writer.Write(dgv.Rows[ir].Cells[2].Value.ToString() + "\n");

            }
            writer.Close();
            
        }
        
    }
}
