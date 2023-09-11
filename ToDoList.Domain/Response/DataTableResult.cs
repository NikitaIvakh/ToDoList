namespace ToDoList.Domain.Response
{
    public class DataTableResult : IDataTableResult
    {
        public int Total { get; set; }

        public object Data { get; set; }
    }

    public interface IDataTableResult
    {
        int Total { get; }

        object Data { get; }
    }
}