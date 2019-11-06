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
            //int colorAnterior = 0;

            for (int i = 0; i < texto.getText().Length; i++) {
                rtb.Select(i, 1);
                string charac = rtb.SelectedText.ToString();



                string color = getNombreColor(rtb.SelectionColor);
                //int color = rtb.SelectionColor.ToArgb();
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

        public RichTextBox agregarColores(Texto texto) {

            RichTextBox rtf = texto.getRich();

            var pieces = texto.getText().Split(new[] { "</colores>" }, StringSplitOptions.None);
            string colores = pieces[0];

            throw new NotImplementedException();
        }

        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            var pieces = textoArchivo.Split(new[] { "</colores>" }, StringSplitOptions.None);

            //string colores = pieces[0];
            string texto = pieces[1];

            //Quita los tags de colores
            //colores.Remove(0, 8);
            //colores.Substring(colores.Length - 9);

            //Quita los tags de texto
            texto = texto.Remove(0, 9);
            texto = texto.Substring(0, texto.Length - 11);

            return texto;

            //throw new NotImplementedException();
        }
    }
}
