﻿using MoviesInfo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesInfo.Sqlite;
using MoviesInfo.Models;
using MoviesInfo.LottieAnimation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviesInfo
{
    public partial class App : Application
    {

        public static PersonRepository PersonRepository { get; private set; }


        public App(string dbPath)
        {
            InitializeComponent();
            PersonRepository = new PersonRepository(dbPath);
            MainPage = new SplashScreen();
            //MainPage = new AnimacaoLottie();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
           // Handle when your app sleeps
            Application.Current.Properties["appName"] = "MoviesInfo";//gravar persistencia de dados
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
