
namespace YekanPedia.ManagementSystem.Console
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// لیست تمام پیام های ارسالی به کاربر در یک درخواست
    /// </summary>
    public class NotificationController
    {
        private const string DictionaryName = "NOTIFICATIONS";
        private IList<Notification> Notifications;
        public NotificationController(TempDataDictionary tempDataDictionary)
        {
            if (!tempDataDictionary.ContainsKey(DictionaryName))
            {
                tempDataDictionary[DictionaryName] = new List<Notification>();
            }
            Notifications = tempDataDictionary[DictionaryName] as IList<Notification>;
        }

        /// <summary>
        /// دریافت پیام های ثبت شده
        /// </summary>
        public IEnumerable<Notification> Current
        {
            get
            {
                return Notifications;
            }
        }

        /// <summary>
        /// اضافه نمودن یک پیام جدید در دیکشنری
        /// </summary>
        /// <param name="message">پیام</param>  
        /// <param name="status">نوع پیام</param>
        public void Notify(string message, NotificationStatus status = NotificationStatus.Information)
        {
            Notifications.Add(new Notification { NotificationStatus = status, Message = message });
        }
    }
}
