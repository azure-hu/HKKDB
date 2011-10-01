using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hkkDataSet.lap' table. You can move, or remove it, as needed.
            //this.lapTableAdapter.Fill(this.hkkDataSet.lap);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*comboBox1.Items.Clear();
            foreach (var item in nevComboBox.Items)
            {
                string _tmp = ((DataRowView)item).Row["nev"].ToString();
                if (_tmp.Contains(textBox1.Text))
                {
                    comboBox1.Items.Add(_tmp);
                }
            }
            comboBox1.SelectedIndex = 0;*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < nevComboBox.Items.Count; i++)
            {
                if (((DataRowView)nevComboBox.Items[i]).Row["nev"].ToString() == comboBox1.Text)
                {
                    nevComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void kepPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Clipboard.SetImage(((PictureBox)sender).Image);                
            }
        }

        private void kepPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "*.jpg|JPEG Formátumú Kép";
                sf.FileName = nevComboBox.SelectedIndex.ToString() + " - " + nevComboBox.SelectedText;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    kepPictureBox.Image.Save(sf.FileName);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.lapTableAdapter.FillBy(this.hkkDataSet.lap, textBox1.Text);
                nevComboBox.SelectedIndex = 0;
            }
        }
    }
}
