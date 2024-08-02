using BusinessObjects;

namespace WPFApp.Services
{
    public class CurrentSession
    {
        private static readonly Lazy<CurrentSession> lazy =
            new Lazy<CurrentSession>(() => new CurrentSession());

        public static CurrentSession Instance => lazy.Value;

        private CurrentSession()
        {
        }

        public Customer LoggedInCustomer { get; set; }
    }
}
