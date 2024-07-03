using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using App.Back.Domain;
using App.Front.ViewModels.DTO;
using App.Front.ViewModels.ViewControllers;

namespace App.Front.Views
{
    
    public partial class Registration : Window
    {
        public PersonDTO SelectedPerson { get; set; }
        public UserAccountDTO SelectedUserAccount { get; set; }
        private RegistrationViewModel _personViewModel { get; set; }

        public Registration()
        {
            InitializeComponent();
            _personViewModel = new RegistrationViewModel();
            SelectedPerson = new PersonDTO();
            SelectedPerson.Role = Role.User;
            SelectedUserAccount = new UserAccountDTO();
            SelectedUserAccount.AccountType = AccountType.User;
            SelectedUserAccount.Active = true;


            SetOptionsComboBox();
            BirthDateTimePicker.SelectedDate = new DateTime(2000,1,1);
            DataContext = this;
        }

        private void SetOptionsComboBox()
        {
            foreach (var level in Enum.GetValues(typeof(Genders)))
            {
                GendersComboBox.Items.Add(level);
            }
        }
        private void SetBirthDateTime()
        {
            string? date = BirthDateTimePicker.SelectedDate.ToString();
            try
            {
                DateTime dateTime = DateTime.Parse(date.Split(" ")[0]);
                SelectedPerson.BirthDate = dateTime;
            }
            catch (Exception)
            {
                SelectedPerson.BirthDate = DateTime.MinValue;
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            SetBirthDateTime();
            if(GendersComboBox.SelectedIndex < 0) { MessageBox.Show("You have to choose a gender"); return; }
            else { SelectedPerson.Gender = (Genders)GendersComboBox.SelectedIndex; }
            if (!_personViewModel.CanUserRegistrate(SelectedUserAccount)) { MessageBox.Show("Username already exist"); return; }
            if (!_personViewModel.CheckJMBG(SelectedPerson)) { MessageBox.Show("You do not have valid JMBG"); return; }

            if(SelectedPerson.IsValid && SelectedUserAccount.IsValid)
            {
                PersonDTO? personDTO = _personViewModel.Create(SelectedPerson);
                if(personDTO == null) { MessageBox.Show("FAIL"); return; }
                SelectedUserAccount.PersonId = personDTO.Id;
                UserAccountDTO? userAccountDTO = _personViewModel.Create(SelectedUserAccount);
                if(userAccountDTO == null) { MessageBox.Show("FAIL"); return; }
                personDTO.AccountId = userAccountDTO.Id;
                _personViewModel.Update(personDTO); 
                MessageBox.Show("You have successfully registrate");
                Close();
            }
            else
            {
                MessageBox.Show("You have some invalid information");
            }
        }
    }
}
