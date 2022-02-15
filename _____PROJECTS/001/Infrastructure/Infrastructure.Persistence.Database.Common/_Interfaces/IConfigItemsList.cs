
namespace Infrastructure.Persistence.Database.Common.Interfaces
{
    public interface IConfigItemsList<T>
    {
        T getById(int piId);
        T getDefault();
    }
}
