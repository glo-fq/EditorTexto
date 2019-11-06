using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class Texto
    {
        String texto;
        List<Posicion> estructura;
        public String getTexto() {
            return this.texto;
        }
        public void setTexto(String ptexto) {
            texto = ptexto;
        }
        public void setEstructura(List<Posicion> es) {
            this.estructura = es;
        }
        public List<Posicion> getEstructura() {
            return this.estructura;
        }
    }
}
