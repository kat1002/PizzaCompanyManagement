using System.Windows;

namespace WPFApp.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindow<T>() where T : Window, new()
        {
            var window = new T();

            window.Show();
        }
    }
}
