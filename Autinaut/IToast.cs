namespace Autinaut
{
    public interface IToast
    {
        void ShortToast(string message);

        void LongToast(string message);
    }
}