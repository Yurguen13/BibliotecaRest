using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.Constants
{
    public class Messages
    {

        public static class Success
        {
            //Classification
            public const string ClassificationCreated = "Clasificacion agregada exitosamente";
        }

        public static class Error
        {
            //Classification
            public const string ClassificationNotFoundWithId = "Clasificacion con ID {0} no encontrado";
            public const string ClassificationNotFound = "Clasificacion no encontrado";
        }
    }
}
