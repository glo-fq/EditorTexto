﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    interface IFactory
    {
        Archivo CrearArchivo(String formato);
    }
}
