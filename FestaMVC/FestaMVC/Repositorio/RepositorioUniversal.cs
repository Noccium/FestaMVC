using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace FestaMVC.Repositorio
{
    public static class RepositorioUniversal<T> where T:class
    {
        public static void GravaObjeto(T obj){
            var lista = RecuperaLista();
            lista.Add(obj);
            GravaListaDeObjetos(lista);
        }
        public static void GravaListaDeObjetos(List<T> listaDeObjetos)
        {
            var listaConvertidaJson = JsonConvert.SerializeObject(listaDeObjetos);
            CriaArquivoDoTipo(listaConvertidaJson);
        }

        public static List<T> RecuperaLista()
        {
            var pathCompleto = ObtenhaPathCompleto();
            var listaDeObjetos = Activator.CreateInstance<List<T>>();
            if (ExisteArquivo(pathCompleto))
            {
                using (var strReader = new StreamReader(pathCompleto))
                {
                    var conteudo = strReader.ReadLine();
                    var listaDoArquivo = JsonConvert.DeserializeObject<List<T>>(conteudo);

                    listaDeObjetos.AddRange(listaDoArquivo);
                }
            }
            
            //CriaArquivoDoTipo(listaConvertidaJson);
            return listaDeObjetos;
        }

        public static void CriaArquivoDoTipo(string conteudo)
        {
            ExcluaArquivoSeExistir();

            using (var strWriter = new StreamWriter(ObtenhaPathCompleto()))
            {
                strWriter.WriteLine(conteudo);
            }
        }

        public static string ObtenhaPathCompleto()
        {
            var nomeArquivo = typeof(T).Name;
            var nomePathCompleto = string.Format("{0}{1}", "C:\\Users\\lucas.sousa\\Desktop\\", nomeArquivo);
            return nomePathCompleto;
        }

        public static bool ExisteArquivo(string nomePathCompleto)
        {
            return File.Exists(nomePathCompleto);
        }

        public static void ExcluaArquivoSeExistir()
        {
            var nomePathCompleto = ObtenhaPathCompleto();
            if (ExisteArquivo(nomePathCompleto))
            {
                File.Delete(nomePathCompleto);
            }
        }
    }
}