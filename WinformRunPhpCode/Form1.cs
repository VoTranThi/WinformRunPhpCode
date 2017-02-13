using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformRunPhpCode
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                this.lbls.Text = fbd.SelectedPath;                
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!File.Exists(string.Format(@"{0}\{1}", this.lbls.Text.Trim(), "php.exe")))
            {
                MessageBox.Show("khong the tim thay file php.exe");
                return;
            }        

            string fileContent = Properties.Resources.String1;
            fileContent = fileContent.Replace(@"D:\xampp\php", this.lbls.Text);
            fileContent = fileContent.Replace(@"D:\xampp\htdocs\nukeviet", this.lbls2.Text);


            string fileNameTmp = Path.GetTempPath() + Guid.NewGuid().ToString() + ".bat";

            //File.Delete("startPhpserver.bat");
            File.WriteAllText(fileNameTmp, fileContent);
            //File.SetAttributes(fileNameTmp, File.GetAttributes(fileNameTmp) | FileAttributes.Hidden);

            using (Process pr = new Process())
            {
                pr.StartInfo.FileName = fileNameTmp;
                pr.Start();
            }

            this.Close();
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                this.lbls2.Text = fbd.SelectedPath;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process pr = new Process())
            {
                pr.StartInfo.FileName = "explorer.exe";
                pr.StartInfo.Arguments = "http://www.votranthi.net";
                pr.Start();
            }
        }
    }
}
