using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Response
{
    public class DataTableResult : IDataTableResult
    {
        public object Data { get; set; }

        public StatusCode StatusCode { get; set; }

        public int Total { get; set; }
    }

    public interface IDataTableResult
    {
        object Data { get; }

        StatusCode StatusCode { get; }

        int Total { get; }
    }
}