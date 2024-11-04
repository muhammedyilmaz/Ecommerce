using System;

namespace Ecommerce.Base.Client.Models
{
    public sealed class EcommerceClientResponse<T> : EcommerceClientResponseProperty<T>
    {
        #region Ctors

        public EcommerceClientResponse()
        {
            IsSuccess = true;
        }

        public EcommerceClientResponse(T data)
        {
            Data = data;
            IsSuccess = true;
        }

        public EcommerceClientResponse(T data, bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
        }

        public EcommerceClientResponse(Exception exception)
        {
            Message = exception.Message;
            Exception = exception;
            IsSuccess = false;
        }

        public EcommerceClientResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public EcommerceClientResponse(string message, Exception exception)
        {
            Message = message;
            IsSuccess = false;
            Exception = exception;
        }

        public EcommerceClientResponse(string message, bool isSuccess, Exception exception)
        {
            Message = message;
            IsSuccess = isSuccess;
            Exception = exception;
        }

        public EcommerceClientResponse(T data, string message, bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

        public EcommerceClientResponse(T data, string message, bool isSuccess, Exception exception)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
            Exception = exception;
        }

        #endregion
    }

    public sealed class EcommerceClientResponse : EcommerceClientResponseProperty<object>
    {
        #region Ctors

        public EcommerceClientResponse()
        {
            IsSuccess = true;
        }

        public EcommerceClientResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public EcommerceClientResponse(Exception exception)
        {
            Message = exception.Message;
            Exception = exception;
            IsSuccess = false;
        }

        public EcommerceClientResponse(bool isSuccess, string message)
        {
            Message = message;
            IsSuccess = isSuccess;
        }

        public EcommerceClientResponse(string message, Exception exception)
        {
            Message = message;
            IsSuccess = false;
            Exception = exception;
        }

        public EcommerceClientResponse(bool isSuccess, string message, Exception exception)
        {
            IsSuccess = isSuccess;
            Message = message;
            Exception = exception;
        }

        #endregion
    }
}
