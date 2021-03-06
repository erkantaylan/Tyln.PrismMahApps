﻿using System.ComponentModel.DataAnnotations;
using System.Windows;
using JetBrains.Annotations;
using Kiwi.Wpf.Mvvm;

namespace Kiwi.Wpf.Demos.ViewModels
{
    [UsedImplicitly]
    public class ValidationsViewModel : ValidatableViewModel
    {
        private string name;

        public ValidationsViewModel()
        {
            Name = "";
        }


        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 1)]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private bool CanSubmit()
        {
            return !HasErrors;
        }

        private void OnSubmit()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Submit");
        }
    }
}