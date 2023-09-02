namespace ToDoList.DAL.Interfaces
{
    public interface IBaseRepository<Type>
    {
        Task CreateAsync(Type entity);

        IQueryable<Type> GetAllElements();

        Task<Type> UpdateAsync(Type entity);

        Task DeleteAsync(Type entity);
    }
}