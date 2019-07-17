using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpControl
{
    public partial class LoadPPL : Form
    {

        private Parser _parse = new Parser();

        public LoadPPL(int pumpaddress)
        {
            InitializeComponent();
            tb_pumpaddress.Text = pumpaddress.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Creates an OpenFileDialog object.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the filter to look for text files.
            openFile1.Filter = "Text Files|*.txt";

            // Once file is selected this will load contents into the rich text box. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Reads the file in string Array
                string[] readText = File.ReadAllLines(openFile1.FileName);
                //richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
                foreach (string str in readText)
                {
                    if (!str[0].Equals(';') && !str[0].Equals('\t') && !str[0].Equals(' '))
                    {
                        richTextBox1.AppendText(str.Replace("\t", ""));
                        richTextBox1.AppendText("\n");
                    }
                    /*if(!str[0].Equals(";"))
                    {
                        richTextBox1.AppendText(str);
                    }*/
                }
            }

           
        }
    }
}
