using App.Front.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.ViewModels.Presentation
{
    public class EditorViewModel
    {
        public PersonDTO Person { get; set; }
        public UserAccountDTO UserAccount { get; set; }

        public string AccountStatus {  get; set; }
        public EditorViewModel() { }

        public EditorViewModel(PersonDTO person, UserAccountDTO userAccount)
        {
            Person = person;
            UserAccount = userAccount;
            AccountStatus = UserAccount.Active ? "Active" : "Deactive";
        }
    }
}
