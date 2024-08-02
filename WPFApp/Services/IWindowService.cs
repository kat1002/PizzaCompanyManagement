using System.Windows;

namespace WPFApp.Services
{
    public interface IWindowService
    {
        void ShowWindow<T>() where T : Window, new();
    }
}
