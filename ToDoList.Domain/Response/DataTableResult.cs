namespace ToDoList.Domain.Response
{
    public class DataTableResult : IDataTableResult
    {
        public object Data { get; set; }

        public int Total { get; set; }
    }

    public interface IDataTableResult
    {
        object Data { get; }

        int Total { get; }
    }
}