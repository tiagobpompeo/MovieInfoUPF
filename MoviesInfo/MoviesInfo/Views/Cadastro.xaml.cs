using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesInfo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesInfo.Sqlite;
using System.Collections.ObjectModel;
using MoviesInfo.Models;

namespace MoviesInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public static PersonRepository PersonRepo { get; private set; }
        public ObservableCollection<Person> pessoa = new ObservableCollection<Person>();
        readonly IList<Person> perfilDados = new ObservableCollection<Person>();
        public int _genero;
        public int _cidade;
        public int _nacionalidade;
        public int _estado;


        public Cadastro()
        {
            InitializeComponent();
            ListPopular();
        }

        public async void Cadastrar(object sender, EventArgs args)
        {
            var nome = txtNome.Text;
            var data_nasc = txtDataNasc.Text;
            var celular = txtCelular.Text;
            var genero = generoPicker.SelectedIndex;
            var nacionalidade = nacionalidadePicker.SelectedIndex;
            var estados = Estados.SelectedIndex;
            var cidade = Cidades.SelectedIndex;
            var bairro = Bairro.Text;

            //genero
            if (genero == 1)
            {
                _genero = 1;
            }
            if (genero == 2)
            {
                _genero = 2;
            }

            //nacionalidade
            if (nacionalidade == 1)
            {
                _nacionalidade = 1;
            }

            //estados
            if (estados == 1)
            {
                _estado = 1;
            }
            if (estados == 2)
            {
                _estado = 2;
            }

            //cidade
            if (cidade == 1)
            {
                _cidade = 1;
            }
            if (cidade == 2)
            {
                _cidade = 2;
            }

            if (await this.DisplayAlert("Confirmar", "Cadastrar ?", "Sim", "Não") == true)
            {
                await App.PersonRepository.AddNewPersonAsync(nome,
                                                             data_nasc,
                                                             celular, 
                                                             _genero.ToString(),
                                                             _nacionalidade.ToString(),
                                                             _estado.ToString(),
                                                             _cidade.ToString(),
                                                             bairro);
            }

        }

        private async void ListPopular()
        {
            pessoa = new ObservableCollection<Person>(await App.PersonRepository.GetAllDataAsync());
            //var perfil = await App.PersonRepository.GetAllPeopleAsync();

            if (pessoa != null)
            {
                foreach (var saida in pessoa)
                {
                    txtNome.Text = saida.Name;
                    txtDataNasc.Text = saida.DataBirth;
                    txtCelular.Text = saida.Telephone;
                    generoPicker.SelectedIndex = saida.Genre == "1" ? 1 : 2;//if else
                    nacionalidadePicker.SelectedIndex = saida.Nationality == "1" ? 1 : 2;
                    Estados.SelectedIndex = saida.States == "1" ? 1 : 2;
                    Cidades.SelectedIndex = saida.City == "1" ? 1 : 2;
                    Bairro.Text = saida.Neighborhood;
                }
                //peopleList.ItemsSource = people;
                //var name = App.PersonRepository.GetAllPeopleAsync();
            }
        }


        public async void OnDelete(object sender, EventArgs e)
        {
                        
            Button button1 = (Button)sender;
            Button _ofertaButton1 = button1.Parent.FindByName<Button>("btnDelete");
            //Person person = (Person)item.BindingContext;
            var a = _ofertaButton1.CommandParameter;
           
            if (await this.DisplayAlert("Confirmar", "Excluir da Lista? " + a, "Sim", "Não") == true) 
            {
                //await DeletePersonAsync(a);
            }
        }

        public async Task<bool> DeletePersonAsync(Person person)
        {
            if (person != null)
            {
                if (await this.DisplayAlert("Confirmar", "Excluir da Lista? " + person.Name, "Sim", "Não") == true)
                {
                    await App.PersonRepository.RemovePersonAsync(person.Id);//Name,Sublinhado
                    ListPopular();
                    return true;
                }
            }
            return false;
        }
    }
}