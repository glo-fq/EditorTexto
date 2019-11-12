using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorTexto.Model
{
    class Memento
    {
        RichTextBox state;
        public Memento(RichTextBox t) {
            this.state = t;
        }
        public RichTextBox getState() {
            return this.state;
        }
    }
}
