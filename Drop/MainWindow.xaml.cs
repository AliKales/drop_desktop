using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Apis.Auth.OAuth2;
using Firebase.Auth;
using Google.Protobuf;
using Newtonsoft.Json.Linq;

namespace Drop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(""));


        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login();   
            }
        }

        private void  Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void BtnMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void  BtnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            Login();

        }

        private async void Login()
        {
            try
            {
                var result = await authProvider.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Password.ToString());
                ChangePage(result);

            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show(ex.Reason.ToString());
            }
            catch
            {

            }
        }

        private void ChangePage(FirebaseAuthLink result)
        {
            Home home = new Home(result.User,result.FirebaseToken);
            this.Content = home;
        }

        private async void BtnRegister(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await authProvider.CreateUserWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Password.ToString());

            }
            catch (Firebase.Auth.FirebaseAuthException ex)
            {
                MessageBox.Show(ex.Reason.ToString());
            }
            catch
            {

            }
        }

    }


}
