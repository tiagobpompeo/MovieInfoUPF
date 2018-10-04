using System;
using System.Collections.Generic;
using System.Linq;
using MoviesInfo.Models;
using SQLite;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MoviesInfo.Sqlite
{
    public class PersonRepository
    {
        private readonly SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Lista>().Wait();
        }

        public async Task AddNewPersonAsync(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Digite um nome valido");                
                var result = await conn.InsertAsync(new Lista { Name = name });
                //StatusMessage = string.Format("{0} Adicionado o  [Name: {1}]", result, name);
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Ja foi adicionado{0}. : {1}", name, ex.Message);
            }
        }

        public Task<List<Lista>> GetAllPeopleAsync()
        {   //return a list of people saved to the Person table in the database
            return conn.Table<Lista>().ToListAsync();
        }

        public async Task NewPersonAsync()
        {
            try
            {   //await conn.QueryAsync<Lista>("DROP TABLE lista");
                await conn.QueryAsync<Lista>("DELETE FROM lista");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Conteudo da Lista nao Deletada:", "", ex.Message);
            }
        }
         
        public async Task RemovePersonAsync(int id)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(id.ToString()) && string.IsNullOrEmpty(id.ToString()))
                    throw new Exception("Nome Invalido para deletar");

                await conn.QueryAsync<Lista>("DELETE FROM [lista] WHERE [Id] = " + id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Ja foi deletado{0}. : {1}", id.ToString(), ex.Message);
            }
        }
    }
}