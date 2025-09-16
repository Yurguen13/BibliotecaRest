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
            //-----Create-----

                //Classification 
            public const string ClassificationCreated = "Clasificacion agregada exitosamente";


            //-----Update-----
                //Classification
            public const string ClassificationUpdated = "Clasificacion actualizada exitosamente";

            //-----Delete-----
                //Classification
            public const string ClassificationDeleted = "Clasificacion eliminada exitosamente";

        }

        public static class Error
        {
            //-----Search-----

                //Classification
            public const string ClassificationNotFoundWithId = "Clasificacion con ID {0} no encontrado";
            public const string ClassificationNotFound = "Clasificacion no encontrado";

            //-----Create-----
                //Classification
            public const string ClassificationCreateError = "Hubo un error al crear la clasificacion";


            //-----Update-----
                //Classification
            public const string ClassificationUpdateError = "Hubo un error al actualizar la clasificacion";

            //-----Delete-----
                //Classification
            public const string ClassificationDeleteError = "Hubo un eror al eliminar la clasificacion";
        }
    }
}
