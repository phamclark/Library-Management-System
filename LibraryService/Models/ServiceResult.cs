using Library.Models;

namespace LibraryService.Models
{
    public class ServiceResult<T>  where T:class
    {
        public ServiceResult(ServiceError error)
        {
            Error = error;
        }

        public T Data { get; set; }
        public ServiceError Error { get; set; }
    }
    /// <summary>
    /// Serializer data for all service-level responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedServiceResult<T> where T : class
    {
        public PaginationResult<T> Data { get; set; }
        public ServiceError Error { get; set; }
    }

    public class ServiceError
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }          
    }
}