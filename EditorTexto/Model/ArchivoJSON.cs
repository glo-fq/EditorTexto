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
            dynamic product = new JObject();
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
            product.Parrafos = parrafos;
            return product.ToString();
        }
        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            throw new NotImplementedException();
        }
    }
}
