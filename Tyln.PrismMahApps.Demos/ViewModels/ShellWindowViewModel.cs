﻿using System.Windows;
using DryIoc;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Mvvm;
using Tyln.PrismMahApps.Demos.Dialogs;

namespace Tyln.PrismMahApps.Demos.ViewModels
{
    [UsedImplicitly]
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IResolver resolver;
        private string title;

        public ShellWindowViewModel(IResolver resolver)
        {
            this.resolver = resolver;
            title = "Prism MahApps Demo";
        }

        public DelegateCommand ShowSimleDialogCommand => new DelegateCommand(async () =>
        {
            SimpleMetroDialog dialog = resolver.Resolve<SimpleMetroDialog>();
            string dialogResult = await dialog.ShowDialogAsync<string, string>("Coolest parameter ever!");
            if (string.IsNullOrWhiteSpace(dialogResult))
            {
                MessageBox.Show("Sir you canceled the god damn simplest dialog ever dialog!");
            }
            else
            {
                MessageBox.Show(dialogResult);
            }
        });

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}