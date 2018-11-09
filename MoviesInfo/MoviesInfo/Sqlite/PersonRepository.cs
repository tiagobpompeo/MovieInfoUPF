using System;
using System.Collections.Generic;
using System.Linq;
using MoviesInfo.Models;
using SQLite;
using System.Threading.Tasks;
using System.Diagnostics;
using Acr.UserDialogs;

namespace MoviesInfo.Sqlite
{
    public class PersonRepository
    {
        private readonly SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            /* Conexão tem dois construtores e alguns parâmetros opcionais
                 ▪ Banco especificado pelo databasePath
                 ▪ true para storeDateTimeAsTicks(armazenar data e hora)
                 ▪ usar os openFlags para controlar os sinalizadores Read | Write | Sharing(sinalizadores para aberturas de arquivos).
            */
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Person>().Wait();
        }

        public async Task AddNewPersonAsync(string nome, string data_nasc, string celular, string genero, string nacionalidade, string estado, string cidade, string bairro)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    if (string.IsNullOrEmpty(nome))
                        throw new Exception("Digite um nome valido");
               
                var result = await conn.InsertAsync(new Person
                {
                    Name = nome,
                    DataBirth = data_nasc,
                    Telephone = celular,
                    Genre = genero,
                    Nationality = nacionalidade,
                    States = estado,
                    City = cidade,
                    Neighborhood = bairro
                }).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = string.Format("{0} Adicionado o [Name: {1}]", result, nome);
               
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Ja foi adicionado{0}. : {1}", name, ex.Message);
                StatusMessage = string.Format("Ja foi adicionado {0}. : {1}", nome, ex.Message);
            }
        }

        public Task<List<Person>> GetAllDataAsync()
        {   //return a list of people saved to the Person table in the database
            return conn.Table<Person>().ToListAsync();
        }


        public async Task RemovePersonAsync(int id)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(id.ToString()) && string.IsNullOrEmpty(id.ToString()))
                    throw new Exception("Nome Invalido para deletar");
                await conn.QueryAsync<Person>("DELETE FROM [lista] WHERE [Id] = " + id);
                StatusMessage = string.Format("Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Ja foi deletado{0}. : {1}", id.ToString(), ex.Message);
            }
        }
    }
}