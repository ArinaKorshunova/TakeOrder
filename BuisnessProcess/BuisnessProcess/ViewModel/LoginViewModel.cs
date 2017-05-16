using BuisnessProcess.NavigationHelper;
using BuisnessProcess.View;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;

namespace BuisnessProcess.ViewModel
{
    public class LoginViewModel : Window
    {
        #region Свойства зависимости
        
        public string Administrator
        {
            get { return (string)GetValue(AdministratorProperty); }
            set { SetValue(AdministratorProperty, value); }
        }
        
        public static readonly DependencyProperty AdministratorProperty =
            DependencyProperty.Register("Administrator", typeof(string), typeof(LoginViewModel), new PropertyMetadata(null));
        

        public DelegateCommand StartWorkDayCommand  
        {
            get { return (DelegateCommand)GetValue(StartWorkDayCommandProperty); }
            set { SetValue(StartWorkDayCommandProperty, value); }
        }
        
        public static readonly DependencyProperty StartWorkDayCommandProperty =
            DependencyProperty.Register("StartWorkDayCommand", typeof(DelegateCommand), typeof(LoginViewModel), new PropertyMetadata(null));

        #endregion

        #region Конструкторы

        public LoginViewModel()
        {
            StartWorkDayCommand = new DelegateCommand(StartWorkDay);
        }

        #endregion

        #region Методы 

        private void StartWorkDay()
        {
            FillData.Administrator = Administrator;

            Application.Current.MainWindow.Close();
            MainWindow ww = new MainWindow();
            ww.Show();
        }

        #endregion
    }
}
