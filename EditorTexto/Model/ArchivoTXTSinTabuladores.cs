using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoTXTSinTabuladores : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            String textoAConvertir = texto.getText();
            int cont = 0;
            String textoConvertido = "";
            foreach (char c in textoAConvertir)
            {
                texto.getRich().Select(cont, 1);
                Color color = texto.getRich().SelectionColor;
                textoConvertido = textoConvertido + c + "-" + color.Name + ",";
                cont++;

            }
            textoConvertido = textoConvertido + "~";
            textoConvertido = textoConvertido + texto.getText();
            return textoConvertido;
            //throw new NotImplementedException();
        }
        //Despues de abri
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            String[] textoN = textoArchivo.Split('~');
            List<String> textoNormal = textoN.ToList();
            texto.setText(textoNormal[1]);
            
            
            String[] s = textoNormal[0].Split(',');
            List<String> separadores = s.ToList();
            separadores.RemoveAt(separadores.Count - 1);
            int cont = 0;

            foreach (String linea in separadores) {
                Console.WriteLine(linea);
                String[] separadorLinea = linea.Split('-');
                texto.getRich().Select(cont, 1);
                Color color = Color.FromName(separadorLinea[1]);
                texto.getRich().SelectionColor = color;
                Console.WriteLine(cont);
                cont++;
            }
            Console.WriteLine("Si sale");
          //  texto.setText(textoArchivo);
            return null;
            
            //throw new NotImplementedException();
        }
    }
}
