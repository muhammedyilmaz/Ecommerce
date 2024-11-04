using System;

namespace Ecommerce.Base.Client.Models
{
    public abstract class EcommerceClientResponseProperty<T>
    {
        #region Properties

        public T Data { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }

        #endregion
    }
}
