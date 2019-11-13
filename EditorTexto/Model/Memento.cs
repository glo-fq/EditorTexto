using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorTexto.Model
{
    class Memento
    {
        List<Color> colores;
        RichTextBox state;
        public Memento(RichTextBox t, List<Color> c) {
            this.state = t;
            this.colores = c;
        }
        
        public RichTextBox getState() {
            return this.state;
        }
        public List<Color> getColores() {

            return colores;
        }


    }
}
