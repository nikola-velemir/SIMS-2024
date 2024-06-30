using App.Back.Domain;
using App.Back.Service;
using App.Front.ViewModels.Presentation;
using System.Windows;

namespace App.Front.ViewModels.ViewControllers
{
    public class PerformerCreationViewModel
    {
        public PerformerViewModel Performer { get; set; }

        public PerformerCreationViewModel()
        {
            Performer = new();
            Performer.BirthDate = DateTime.Now;
        }
        public bool Submit()
        {
            if (Performer.IsValid)
            {
                var izvodjacService = new PerformerService();
                if (izvodjacService.Create(Performer.ToPerformer()) == null)
                {
                    throw new Exception();
                }
                MessageBox.Show("Performer created!");
                return true;
            }
            return false;
        }
    }
}
