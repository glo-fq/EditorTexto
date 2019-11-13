using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoJSON : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            String textoAConvertir = texto.getText();
            textoAConvertir = textoAConvertir + "\n";
           // dynamic product = new JObject();
            JArray parrafos = new JArray();
            JArray p = new JArray(); 
            int cont = 0;
            foreach (char c in textoAConvertir) {
                if ((c == '\n')) {
                    parrafos.Add(p);
                    p = new JArray();

                }
                dynamic pp = new JObject();
                texto.getRich().Select(cont, 1);
                Color color = texto.getRich().SelectionColor;
                pp.Letra = Char.ToString(c);
                pp.Estilo = color.Name;
                p.Add(pp);
                cont++;

            }
            //  product.Parrafos = parrafos;
            return parrafos.ToString();
        }
        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            JArray json = JArray.Parse(textoArchivo);
            int cont = 0;
            foreach (JArray parrafo in json) {
                foreach (JObject item in parrafo) {
                    string letra = item.GetValue("Letra").ToString();
                    string estilo = item.GetValue("Estilo").ToString();
                    texto.getRich().AppendText(letra);
                    texto.getRich().Select(cont, 1);
                    Color color = Color.FromName(estilo);
                    texto.getRich().SelectionColor = color;
                    cont++;
                }
            }
         //   Console.WriteLine(o.ToString());
            return texto;
            //throw new NotImplementedException();
        }
    }
}
