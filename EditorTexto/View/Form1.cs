﻿using EditorTexto.Model;
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

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        IFactory factory;
        Texto texto;
        Archivo archivo=null;
        String ruta;
        Caretaker caretaker;
        int contador = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog Open = new OpenFileDialog();
            //se especifica que tipos de archivos se podran abrir y se verifica si existe
            Open.Filter = "Text Simple [*.txt*]|*.txt| Text Tabuladores [*.txt*]|*.txt|XML [*.xml*]| *.xml| CSV [*.csv*] | *.csv| JSON [*.json*] | *.json";
            Open.CheckFileExists = true;
            Open.Title = "Abrir Archivo";
            Open.ShowDialog(this);
            try
            {
                Open.OpenFile();
                int index = Open.FilterIndex;
                String extension = Path.GetExtension(Open.FileName);
                if (index == 1) {
                    extension = extension+"s";
                }
                else if (index == 2) {
                    extension = extension + "c";
                }
                this.ruta = Open.FileName;
                this.archivo = factory.CrearArchivo(extension);
                String text = this.archivo.abriArchivo(Open.FileName);
                this.archivo.convertirATexto(text, texto);
            }
            catch (Exception) {
            }
        }

        private void otroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void azulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Green;
        }

        private void rosadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Pink;
        }

        private void anaranjadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Orange;
        }

        private void moradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Purple;
        }

        private void amarilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Yellow;
        }

        private void grisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Gray;
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            texto.paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caretaker.add(texto.saveStateToMemento());
            contador = caretaker.size() - 1;
            if (contador < caretaker.size() && contador>=0) {
                texto.getStateFromMemento(caretaker.get(contador-1));
                contador = contador - 1;
            }   
           // richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contador < caretaker.size() - 1) {
                texto.getStateFromMemento(caretaker.get(contador + 1));
                contador = contador + 1;
            }
            //richTextBox1.Redo();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caretaker = new Caretaker();
            factory = new Factory();
            texto = new Texto();
            texto.setRich(this.richTextBox1);
        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.archivo==null)
            {
                GuardarComoToolStripMenuItem_Click(sender, e);
            }
            else {
                String text = (String)archivo.convertirAFormatoDeseado(this.texto);
                archivo.setTexto(text);
                archivo.guardarComo(ruta);
            }

        }
        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se crea un objeto de tipo savefiledialog que nos servira para guardar el archivo
            SaveFileDialog Save = new SaveFileDialog();
           // System.IO.StreamWriter myStreamWriter = null;
            //al igual que para abrir el tipo de documentos aqui se especifica en que extenciones se puede guardar el archivo
            Save.Filter = "Text Simple [*.txt*]|*.txt| Text Tabuladores [*.txt*]|*.txt|XML [*.xml*]| *.xml| CSV [*.csv*] | *.csv| JSON [*.json*] | *.json| PDF [*.pdf*] | *.pdf";
            Save.CheckPathExists = true;
            Save.Title = "Guardar como";
            Save.ShowDialog(this);
           
            try
            {
                int index = Save.FilterIndex;
               
                String extension = Path.GetExtension(Save.FileName);
                if (index == 1)
                {
                    extension = extension + "s";
                }
                else if (index == 2) {
                    extension = extension + "c";
                }
                this.ruta = Save.FileName;
                archivo = factory.CrearArchivo(extension);
                String text = (String)archivo.convertirAFormatoDeseado(this.texto);
                archivo.setTexto(text);
                archivo.guardarComo(Save.FileName);
              

            }
            catch (Exception) { }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Si estoy guardando algo");
            
        }
    }
}
