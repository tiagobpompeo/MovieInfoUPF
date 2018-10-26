using System;
using System.Collections.Generic;

namespace MoviesInfo.Services
{
    public class Response
    {
        public bool IsSuccess
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string Mensagem
        {
            get;
            set;
        }
        

        public object Result
        {
            get;
            set;
        }

        public object Resultado
        {
            get;
            set;
        }




        public string Count
        {
            get;
            set;
        }

        public string Total
        {
            get;
            set;
        }

        public string Retorno
        {
            get;
            set;
        }

        public string Codigo
        {
            get;
            set;
        }

        public object Banner
        {
            get;
            set;
        }

        public static explicit operator List<object>(Response v)
        {
            throw new NotImplementedException();
        }
    }
}
