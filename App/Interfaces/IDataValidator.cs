namespace App.Interfaces
{
    public interface IDataValidator<in T>
    {
        bool Validate(T data);
    }
}