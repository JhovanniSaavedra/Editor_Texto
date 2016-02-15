using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Formulario_Editor
{
    public partial class Form1 : Form
    {
        String archivo;

        public Form1()
        {InitializeComponent();}

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbrirArchivo = new OpenFileDialog();
            AbrirArchivo.Filter = "Texto|*.txt";

            if (AbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                archivo = AbrirArchivo.FileName;
                using (StreamReader leer = new StreamReader(archivo))
                { richTextBox1.Text = leer.ReadToEnd(); }
            }
        }

        private void guardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog GuardarArchivo = new SaveFileDialog();
            GuardarArchivo.Filter = "Texto|*.txt";
            if (archivo != null)
            {
                using (StreamWriter escribir = new StreamWriter(archivo))
                {escribir.Write(richTextBox1.Text);}
            }

            else
            {
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    archivo = GuardarArchivo.FileName;
                    using (StreamWriter escribir = new StreamWriter(GuardarArchivo.FileName))
                    {escribir.Write(richTextBox1.Text);
                    MessageBox.Show("Archivo Guardado");
                    }
                }
            }
        }

        private void crearArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            archivo = null;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro desea salir?", "Aviso",  MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {Application.Exit();}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }// Fin clase publica
} // Fin llave namespace
