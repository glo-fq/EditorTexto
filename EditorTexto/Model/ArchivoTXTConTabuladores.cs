using System;
using System.Collections.Generic;
using System.Drawing;
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
            String textoConvertido = "";
            int cont = 1;
            int i = 0;
            foreach (char c in txt) {
                nuevoTxt = nuevoTxt + c;
                texto.getRich().Select(i, 1);
                Color color = texto.getRich().SelectionColor;
                textoConvertido = textoConvertido + c + "-" + color.Name + ",";
                i++;
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
            textoConvertido = textoConvertido +"~"+ nuevoTxt;
            return textoConvertido;
        }
        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            String[] textoN = textoArchivo.Split('~');
            List<String> textoNormal = textoN.ToList();
            String nuevoTxt = "";
            int cont = 1;
            foreach (char c in textoNormal[1]) {
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
            texto.setText(nuevoTxt);
            String[] s = textoNormal[0].Split(',');
            List<String> separadores = s.ToList();
            separadores.RemoveAt(separadores.Count - 1);
            int ii = 0;

            foreach (String linea in separadores)
            {
                Console.WriteLine(linea);
                String[] separadorLinea = linea.Split('-');
                texto.getRich().Select(ii, 1);
                Color color = Color.FromName(separadorLinea[1]);
                texto.getRich().SelectionColor = color;
                Console.WriteLine(cont);
                ii++;
            }

            return texto;

        }
    }
}
