using System.Collections.Generic;

namespace PlanningInfoSystemAPI.Models
{
    public class CustomResult
    {
        public CustomResult()
        {
            Messages = new List<string>();
        }

        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }

        public CustomResult Error(string msg = null)
        {
            Succeeded = false;
            if (!string.IsNullOrEmpty(msg))
            {
                Messages.Add(msg);
            }

            return this;
        }

        public CustomResult Ok()
        {
            Succeeded = true;
            return this;
        }
    }

    public class CustomResult<T>
    {
        public CustomResult()
        {
            Messages = new List<string>();
        }

        public CustomResult(T data)
        {
            Data = data;
            Succeeded = true;
        }

        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public List<string> Messages { get; set; }

        public CustomResult<T> Error(string msg = null)
        {
            Succeeded = false;
            if (!string.IsNullOrEmpty(msg))
            {
                Messages.Add(msg);
            }

            return this;
        }

        public CustomResult<T> Ok(T data)
        {
            Succeeded = true;
            Data = data;
            return this;
        }
    }
}
