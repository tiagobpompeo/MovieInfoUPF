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
            conn.CreateTableAsync<Person>().Wait();
        }      

        public async Task AddNewPersonAsync(string nome,string data_nasc,string celular,string genero,string nacionalidade,string estado,string cidade,string bairro)
        {

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
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Ja foi deletado{0}. : {1}", id.ToString(), ex.Message);
            }
        }
    }
}