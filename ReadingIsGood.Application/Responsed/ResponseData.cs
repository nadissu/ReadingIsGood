using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Responsed
{
    public interface IResponse { }
    public class ResponseData<T> : IResponse
    {
        public T Data { get; set; }



        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ResponseData()
        {

        }
        public ResponseData(T data)
        {
            Data = data;
        }

        public ResponseData(T data, bool ısSuccess) : this(data)
        {
            IsSuccess = ısSuccess;
        }

        public ResponseData(T data, bool ısSuccess, string message) : this(data, ısSuccess)
        {
            Message = message;
        }

        public ResponseData(bool ısSuccess, string message)
        {
            IsSuccess = ısSuccess;
            Message = message;
        }
    }
}
