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
        public ObservableCollection<Lista> people = new ObservableCollection<Lista>();
        readonly IList<Lista> perfilDados = new ObservableCollection<Lista>();
        public int _genero;
        public int _cidade;
        public int _nacionalidade;
        public int _estado;


        public Cadastro()
        {
            InitializeComponent();
            ListPopular();
            txtNome.TextChanged += TxtNome_TextChanged;
            txtNome.Completed += Entry_Completed;
        }

        //Evento que é gerado quando o texto neste elemento de entrada é alterado.
        void TxtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            var oldText = e.OldTextValue;
            var newText = e.NewTextValue;
        }

        //Ocorre quando o usuário finaliza o texto em uma entrada com a chave de retorno.
        void Entry_Completed(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text; //cast sender to access the properties of the Entry
        }


        private async void ListPopular()
        {
            people = new ObservableCollection<Lista>(await App.PersonRepository.GetAllPeopleAsync());

            //var perfil = await App.PersonRepository.GetAllPeopleAsync();
            foreach (var saida in people)
            {
                txtNome.Text = saida.Name;
                txtDataNasc.Text = saida.DataBirth;
                txtCelular.Text = saida.Telephone;

                //ajustar saida
                generoPicker.SelectedIndex = saida.Genre == "1" ? 1 : 2;
                nacionalidadePicker.SelectedIndex = saida.Nationality == "1" ? 1 : 2;
                Estados.SelectedIndex = saida.States == "1" ? 1 : 2;
                Cidades.SelectedIndex = saida.City == "1" ? 1 : 2;

                //
                Bairro.Text = saida.Neighborhood;
            }

            //peopleList.ItemsSource = people;
            //var name = App.PersonRepository.GetAllPeopleAsync();

        }

        public async void OnDelete(object sender, EventArgs e)
        {
            //Button item = (Button)sender;             
            Button button1 = (Button)sender;
            Button _ofertaButton1 = button1.Parent.FindByName<Button>("btnDelete");
            //Lista person = (Lista)item.BindingContext;
            var a = _ofertaButton1.CommandParameter;
            //await DeletePersonAsync(person);
            if (await this.DisplayAlert("Confirmar", "Excluir da Lista? " + a, "Sim", "Não") == true) { }
        }

        public async Task<bool> DeletePersonAsync(Lista person)
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

        public async void NewList(object sender, EventArgs args)
        {
            if (await this.DisplayAlert("", "Deseja criar uma nova lista e excluir sua lista atual?", "Sim", "Não") == true)
            {
                await App.PersonRepository.NewPersonAsync();//Name,Sublinhado
                ListPopular();
            }
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            //statusMessage.Text = "";
            //await App.PersonRepository.AddNewPersonAsync(newAdd.Text);//Name,Sublinhado
            //statusMessage.Text = App.PersonRepository.StatusMessage;
            //people = new ObservableCollection<Lista>(await App.PersonRepository.GetAllPeopleAsync());//        //ascendente ou descendente???
            //peopleList.ItemsSource = people;
            //newAdd.Text = "";
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
            var bairrro = Bairro.Text;

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


            //Button button1 = (Button)sender;
            //Button _ofertaButton1 = button1.Parent.FindByName<Button>("btnCadastro");
            //var a = _ofertaButton1.CommandParameter;

            if (await this.DisplayAlert("Confirmar", "Cadastrar ?", "Sim", "Não") == true)
            {
                await App.PersonRepository.AddNewPersonAsync
                         (nome, data_nasc,
                          celular, _genero.ToString(),
                          _nacionalidade.ToString(),
                          _estado.ToString(),
                          _cidade.ToString(),
                          bairrro
                         );//Name,Sublinhado

                Button button = (Button)sender;
                //Button _ofertaButton = button.Parent.FindByName<Button>("btnCadastro");
                //_ofertaButton.IsEnabled = false;
            }
            else
            {
                //Button button = (Button)sender;
                //Button _ofertaButton = button.Parent.FindByName<Button>("btnCadastro");               
            }
        }
    }
}