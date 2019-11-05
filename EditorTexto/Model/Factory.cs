using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class Factory : IFactory
    {
        public Archivo CrearArchivo(string formato)
        {
            switch (formato) {
                case "CSV":
                    return new ArchivoCSV();
                case "JSON":
                    return new ArchivoJSON();
                case "PDF":
                    return new ArchivoPDF();
                case "TXT":
                    return new ArchivoTXT();
                case "XML":
                    return new ArchivoXML();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
