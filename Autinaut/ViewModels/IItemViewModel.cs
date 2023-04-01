namespace Autinaut.ViewModels
{
    public interface IItemViewModel
    {
        int ID { get; set; }

        string Note { get; set; }
        string Date { get; set; }
    }
}