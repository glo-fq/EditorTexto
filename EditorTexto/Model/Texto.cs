using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EditorTexto.Model
{
    class Texto 
    {

        RichTextBox rich;
        public Texto()
        {

        }
        public RichTextBox getRich() {
            return this.rich;
        }
        public void setRich(RichTextBox ptexto) {
            rich = ptexto;
        }
        public String getText() {
            return rich.Text;
        }
        public void setText(String text) {
            this.rich.Text = text;
        }

        public void copy() {
            this.rich.Copy();
        }
        public void paste() {
            this.rich.Paste();
        }
        public Memento saveStateToMemento()
        {
            RichTextBox r = new RichTextBox();
            r.Text = rich.Text;
            List<Color> colores = new List<Color>();
            int contador = 0;
            foreach (char c in rich.Text) {
                rich.Select(contador, 1);
                Color color=rich.SelectionColor;
                colores.Add(color);
                contador++;
            }
            return new Memento(r,colores);
        }

        public void getStateFromMemento(Memento memento)
        {
            Console.WriteLine(memento.getState().Text);
            this.rich.Text = memento.getState().Text;
            int contador = 0;
            foreach (char c in rich.Text) {
                rich.Select(contador, 1);
                rich.SelectionColor = memento.getColores().ElementAt(contador);
                contador++;
            }
        }

    }
}
