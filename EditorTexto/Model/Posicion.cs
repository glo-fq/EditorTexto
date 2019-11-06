using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class Posicion
    {
        Color color;
        int iniPos;
        int finPos;

        public int getIniPos() {
            return iniPos;
        }
        public int getFinPos() {
            return finPos;
        }
        public Color getColor() {
            return color;
        }
        public void setIniPos(int pIniPos) {
            this.iniPos = pIniPos;
        }
        public void setFinPos(int pFinPos) {
            this.finPos = pFinPos;
        }
        public void setColor(Color color) {
            this.color = color;
        }
    }
}
