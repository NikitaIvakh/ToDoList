using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Response
{
    public class BaseResponse<Type> : IBaseResponse<Type>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public Type Data { get; set; }
    }

    public interface IBaseResponse<Type>
    {
        string Description { get; }

        StatusCode StatusCode { get; }

        Type Data { get; }
    }
}