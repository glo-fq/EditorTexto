using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoTXTConTabuladores : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            String txt = texto.getText();
            String nuevoTxt = "";
            int cont = 1;
            foreach (char c in txt) {
                nuevoTxt = nuevoTxt + c;
                if (cont == 10)
                {
                    nuevoTxt = nuevoTxt + "\t\t\t";
                    cont = 1;
                }
                else
                {
                    cont++;
                }               
            }
            return nuevoTxt;
            //throw new NotImplementedException();
        }
        //Despues de abrir
        public override string convertirATexto(string textoArchivo)
        {
            String nuevoTxt = "";
            int cont = 1;
            foreach (char c in textoArchivo) {
                if (cont < 11 && cont < 13)
                {
                    nuevoTxt = nuevoTxt + c;
                    cont++;
                }
                else {
                    if (cont == 13)
                    {
                        cont = 1;
                    }
                    else {
                        cont++;
                    }
                }

                

            }

            throw new NotImplementedException();
        }
    }
}
