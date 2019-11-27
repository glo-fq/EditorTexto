using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EditorTexto.Model
{
    class ArchivoPDF : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            //byte[] bytes = Encoding.UTF8.GetBytes(texto.getText());

            throw new NotImplementedException();
        }


        public void guardarPdf(string fileName, Texto texto)
        {
            RichTextBox rtb = texto.getRich();

            iTextSharp.text.Document myDocument = new iTextSharp.text.Document(PageSize.A4.Rotate());

            try
            {
                // step 2:
                // Now create a writer that listens to this doucment and writes the document to desired Stream.

                PdfWriter.GetInstance(myDocument, new FileStream(fileName, FileMode.Create));

                // step 3:  Open the document now using
                myDocument.Open();

                // step 4: Now add some contents to the document
                myDocument.Add(new iTextSharp.text.Paragraph(rtb.Text));
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            // step 5: Remember to close the documnet
            myDocument.Close();
        }

        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {

            throw new NotImplementedException();
        }
    
    }
}
