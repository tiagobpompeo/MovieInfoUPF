using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesInfo.iOS.Helpers
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");//Acesso a Nossa Pasta do nosso aplicativo

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);//tratamento caso nao exista entao sera criado
            }
            //Armazena o banco de dados em um arquivo local, que deve ser colocado em um caminho de pasta gravavel que seja especifico da plataforma
            return System.IO.Path.Combine(libFolder, filename);// Pasta , o Nome absoluto do nosso banco de dados
            //System.IO , permite trabalhar diretamente com arquivos e pastas
        }
    }
}