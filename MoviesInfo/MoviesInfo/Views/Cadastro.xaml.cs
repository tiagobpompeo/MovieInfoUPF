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
        ObservableCollection<Lista> people = new ObservableCollection<Lista>();

        public Cadastro()
        {
            InitializeComponent();
            ListPopular();
            txtNome.TextChanged+=TxtNome_TextChanged;
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
           //peopleList.ItemsSource = people;
			var name = App.PersonRepository.GetAllPeopleAsync();
            
        }

        public async void OnDelete(object sender, EventArgs e)
        {
             //Button item = (Button)sender;             
             Button button1 = (Button)sender;
             Button _ofertaButton1 = button1.Parent.FindByName<Button>("btnDelete");
             //Lista person = (Lista)item.BindingContext;
             var a = _ofertaButton1.CommandParameter;
             //await DeletePersonAsync(person);
             if (await this.DisplayAlert("Confirmar", "Excluir da Lista? " + a, "Sim", "Não") == true) {}          
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

            if(genero==0)
            {

            }
            else
            {

            }


            Button button1 = (Button)sender;
            Button _ofertaButton1 = button1.Parent.FindByName<Button>("btnCadastro");
            var a = _ofertaButton1.CommandParameter;

            if (await this.DisplayAlert("Confirmar", "Cadastrar  " + a + "?", "Sim", "Não") == true)
            {
                await App.PersonRepository.AddNewPersonAsync(a.ToString());//Name,Sublinhado
                Button button = (Button)sender;
                Button _ofertaButton = button.Parent.FindByName<Button>("btnCadastro");
                _ofertaButton.IsEnabled = false;
            }
            else
            {
                Button button = (Button)sender;
                Button _ofertaButton = button.Parent.FindByName<Button>("btnCadastro");               
            }
        }
    }
}