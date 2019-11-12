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
        public Memento saveStateToMemento()
        {
            return new Memento(rich);
        }
        
        public void getStateFromMemento(Memento memento)
        {
            rich = memento.getState();
        }
        public void copy() {
            this.rich.Copy();
        }
        public void paste() {
            this.rich.Paste();
        }

    }
}
