using System.Collections.Generic;

namespace RushToWin.Domain.Notifications
{
    public class Notification
    {
        public bool Success { get; set; }
        public object Meta { get; set; }
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<Message> Messages { get; set; }

        public static Notification CreateError
            (object data = null, 
            object meta = null,
            int statusCode = 0,
            IEnumerable<Message> errors = null) 
        {
            return new Notification
            {
                Success = false,
                Messages = errors,
                Data = data,
                StatusCode = statusCode,
                Meta = meta
            };
        }

        public static Notification CreateError
            (object data = null,
            object meta = null,
            int statusCode = 0,
            string message = null)
        {
            return new Notification
            {
                Success = false,
                Messages = new List<Message> { new Message(message) },
                Data = data,
                StatusCode = statusCode,
                Meta = meta
            };
        }

        public static Notification CreateSuccess
            (object data,
            object meta,
            int statusCode,
            string message)
        {
            return new Notification
            {
                Success = true,
                Messages = new List<Message> { new Message(message) },
                Data = data,
                StatusCode = statusCode,
                Meta = meta
            };
        }


    }
}
