using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RegisterPersonApplication.Commands;
using RegisterPersonApplication.Models;
using RegisterPersonApplication.Rules;
using RegisterPersonApplication.Utils;

namespace RegisterPersonApplication.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private int _personCounter;
        private string _personCount;
        private bool _isEmailValid;
        private bool _isPhoneNumberValid;
        public bool _isSaveButtonEnabled;

        private Dictionary<string, Person> _cachePerson = new Dictionary<string, Person>();

        public event PropertyChangedEventHandler PropertyChanged;
        internal MainWindowViewModel()
        {
            IsSaveButtonEnabled = true;
            SubmitButtonCommand = new RelayCommand(CanExecute, Execute);
        }

        public ICommand SubmitButtonCommand
        {
            get; set;

        }

        //public int PersonCounter
        //{
        //    get { return _personCounter; }
        //    set
        //    {
        //        _personCounter = value;
        //        OnPropertyChanged(nameof(PersonCounter));
        //    }
        //}

        public string PersonCount
        {
            get { return _personCount; }
            set
            {
                _personCount = value;
                OnPropertyChanged(nameof(PersonCount));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                _isEmailValid = _email.EmailValidation();
                OnPropertyChanged(nameof(Email));
                CheckEnabled();
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                _isPhoneNumberValid = _phoneNumber.PhoneNumberValidation();
                OnPropertyChanged(nameof(PhoneNumber));
                CheckEnabled();
            }
        }

        public bool IsSaveButtonEnabled
        {
            get { return _isSaveButtonEnabled; }
            set
            {
                _isSaveButtonEnabled = value;
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CanExecute(object parameter)
        {
            return IsSaveButtonEnabled;
        }

        public void Execute(object parameter)
        {
            var result = string.Empty;
            if (_cachePerson.ContainsKey(Email))
            {
                result = string.Format("User already exists\n{0}\n{1}\n{2}\n{3}\n",
                   _cachePerson[Email].FirstName,
                   _cachePerson[Email].LastName,
                   _cachePerson[Email].Email,
                   _cachePerson[Email].PhoneNumber);
            }
            else
            {
                _cachePerson.Add(Email, new Person(FirstName, LastName, Email, PhoneNumber));
                _personCounter++;
                PersonCount = _personCounter.ToString();
                result = string.Format("Number of users {0}\nUser added\n{1}\n{2}\n{3}\n{4}\n",
                    _personCounter.ToString(), FirstName, LastName, Email, PhoneNumber);
                
                // ++ personCounter => personCounter.ToString
            }

            MessageBox.Show(result);
        }

        private void CheckEnabled()
        {
            IsSaveButtonEnabled = _isPhoneNumberValid && _isEmailValid;
        }
    }
}
