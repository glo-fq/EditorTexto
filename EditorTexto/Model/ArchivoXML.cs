using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorTexto.Model
{
    class ArchivoXML : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            RichTextBox rtb = texto.getRich();

            rtb.HideSelection = true;

            string strFinal = "<colores>\n";

            string colorAnterior = "";

            for (int i = 0; i < texto.getText().Length; i++) {
                rtb.Select(i, 1);
                string charac = rtb.SelectedText.ToString();



                string color = getNombreColor(rtb.SelectionColor);
                //Console.WriteLine(i + ". Color: " + rtb.SelectionColor.ToArgb().ToString());


                if (colorAnterior != color) {
                strFinal += "<" + color + ">" + i + "</" + color + ">\n";
                }
                

                colorAnterior = color;

            }

            strFinal += "</colores>\n";
            strFinal += "<texto>\n";
            strFinal += texto.getText();
            strFinal += "\n"; 
            strFinal += "</texto>";

            rtb.DeselectAll();

            rtb.HideSelection = false;

            return strFinal;
        }

        private string quitarWhitespace(string texto) {
            return new string(texto.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        private string getNombreColor(Color colorToCheck) {
            string name = "Unknown";
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                int azul = Color.Blue.ToArgb();
                //Console.WriteLine(azul.ToString());
                int rojo = Color.Red.ToArgb();
                int verde = Color.Green.ToArgb();

                Color known = Color.FromKnownColor(kc);
                //Console.WriteLine(known.Name);
                if (colorToCheck.ToArgb().Equals(known.ToArgb()))
                {
                    name = known.Name;

                }
                
                
            }
            return name;
        }

        public Texto agregarColores(Texto texto, string tagColores) {
            //Extraer colores

            //Extraer nombres
            List<string> arrColores = new List<string>();
            string tempColor = "";
            int indexOf = -1;

            while (tagColores.Contains('>')) {

                //Quitar el primer '<'
                tagColores = tagColores.Remove(0, 1);
                indexOf = tagColores.IndexOf('>');
                //Seleccionar el texto antes del primer '>'
                tempColor = tagColores.Substring(0, indexOf);
                Console.WriteLine(tempColor);
                arrColores.Add(tempColor);

                //Quitar el color del string original
                tagColores = tagColores.Remove(0, indexOf);

            }

            //Extraer indices

            RichTextBox rtb = texto.getRich();
            rtb.HideSelection = true;



            throw new NotImplementedException();
        }

        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            var pieces = textoArchivo.Split(new[] { "</colores>" }, StringSplitOptions.None);

            string colores = pieces[0];
            string text = pieces[1];

            //Quita el tag de colores que queda
            colores = colores.Remove(0, 10);
            Console.WriteLine(colores);

            //Quita los tags de texto
            text = text.Remove(0, 9);
            text = text.Substring(0, text.Length - 11);

            texto.setText(text);

            //texto = agregarColores(texto, colores);

            return texto;

            //throw new NotImplementedException();
        }
    }
}
