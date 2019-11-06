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
                case ".csv":
                    return new ArchivoCSV();
                case ".json":
                    return new ArchivoJSON();
                case ".pdf":
                    return new ArchivoPDF();
                case ".txtc":
                    return new ArchivoTXTConTabuladores();
                case ".txts":
                    return new ArchivoTXTSinTabuladores();
                case ".xml":
                    return new ArchivoXML();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
