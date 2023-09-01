using System.Collections.Generic;
using System.Threading.Tasks;
using Autinaut.ViewModels;

namespace Autinaut.Models
{
    public interface ISuccessItemDatabase
    {
        Task<List<SuccessItemViewModel>> GetItemsAsync();
        Task<SuccessItemViewModel> GetItemAsync(int id);
        Task<int> SaveItemAsync(SuccessItemViewModel item);
        Task<int> DeleteItemAsync(SuccessItemViewModel item);
    }
}