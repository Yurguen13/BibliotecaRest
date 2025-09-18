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

            //Specimen
            public const string SpecimenCreated = "Especimen agregado exitosamente";


            //-----Update-----
            //Classification
            public const string ClassificationUpdated = "Clasificacion actualizada exitosamente";

            //Specimen 
            public const string SpecimenUpdated = "Especimen actualizado exitosamente";

            //-----Delete-----
            //Classification
            public const string ClassificationDeleted = "Clasificacion eliminada exitosamente";
            
            //Specimen
            public const string SpecimenDeleted = "Especimen eliminado exitosamente";

        }

        public static class Error
        {
            //-----Search-----

                //Classification
            public const string ClassificationNotFoundWithId = "Clasificacion con ID {0} no encontrado";
            public const string ClassificationNotFound = "Clasificacion no encontrado";

            //Specimen
            public const string SpecimenNotFoundWithId = "Especimen con ID {0} no encontrado";
            public const string SpecimenNotFound = "Especimen no encontrado";

            //Publisher
            public const string PublisherNotFoundWithId = "Publisher con ID {0} no encontrado";
            public const string PublisherNotFound = "Publisher no encontrado";

            //-----Create-----
                //Classification
            public const string ClassificationCreateError = "Hubo un error al crear la clasificacion";
            //Specimen
            public const string SpecimenCreateError = "Hubo un error al crear el especimen";


            //-----Update-----
            //Classification
            public const string ClassificationUpdateError = "Hubo un error al actualizar la clasificacion";

            //Specimen
            public const string SpecimenUpdateError = "Hubo un error al actualizar el especimen";

            //-----Delete-----
            //Classification
            public const string ClassificationDeleteError = "Hubo un eror al eliminar la clasificacion";

            //Specimen
            public const string SpecimentDeleteError = "Hubo un error al eliminar el especimen";

            // messages
            public const string CategoryNotFound = "No se encontro la categoría";
            public const string CategoryBadRequest = "Hubo un error al mandar los datos";
            public const string AuthorNotFound = "No se encontro el author";
            public const string AuthorBadRequest = "Hubo un error al mandar los datos";

            public const string BooksNotFound = "No se encontro el libro";
            public const string BooksBadRequest = "Hubo un error al mandar los datos";
            //public const string CategoryNotFound = "No se encontro la categoría";
            //public const string CategoryBadRequest = "Hubo un error al mandar los datos";
        }
    }
}
