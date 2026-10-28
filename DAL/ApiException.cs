using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{   
    //Subclase de Exceptiob (superclase)
    public class ApiException : Exception
    {
        //Constructor (método inicializados)
        //Anulando el constructor predeterminado  vacío => public Clase() {}
        //base(message)
        public ApiException(string message) : base(message) { }
    }
}
