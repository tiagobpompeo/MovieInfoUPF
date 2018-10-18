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

        //var nome = txtNome.Text;
        //var data_nasc = txtDataNasc.Text;
        //var celular = txtCelular.Text;
        //var genero = generoPicker.SelectedIndex;
        //var nacionalidade = nacionalidadePicker.SelectedIndex;
        //var estados = Estados.SelectedIndex;
        //var cidade = Cidades.SelectedIndex;
        //var bairrro = Bairro.Text;


        public async Task AddNewPersonAsync(string nome, 
                                            string data_nasc, 
                                            string celular, 
                                            string genero, 
                                            string nacionalidade, 
                                            string estado, 
                                            string cidade,
                                            string bairro)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    throw new Exception("Digite um nome valido");
                var result = await conn.InsertAsync(new Lista
                { 
                    Name = nome,
                    DataBirth = data_nasc,
                    Telephone = celular,
                    Genre = genero,
                    Nationality = nacionalidade,
                    States = estado,
                    City = cidade,
                    Neighborhood = bairro
                });
                StatusMessage = string.Format("{0} Adicionado o  [Name: {1}]", result, nome);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Ja foi adicionado{0}. : {1}", nome, ex.Message);
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