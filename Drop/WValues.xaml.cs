using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Firebase.Auth;
using Google.Cloud.Firestore;


namespace Drop
{
    /// <summary>
    /// Interaction logic for WValues.xaml
    /// </summary>
    public partial class WValues : Page
    {

        User user;
        FirestoreDb db = FirestoreDb.Create(projectId: "");
        string firebaseToken;

        string fileName = "";
        string fileDownloadUrl = "";
        string text = "";


        public WValues(User u,string token)
        {
            InitializeComponent();

            user = u;
            firebaseToken = token;

            OnPageLoad();

        }

        private void OnPageLoad()
        {
            db.Collection("values").Document("WzdC5UusCnorWZa2").Listen(snapshot =>
            {
                ListenValueChanges(snapshot);
            });
        }


        private void BtnChangePage(object sender, RoutedEventArgs e)
        {
            var home = new Home(user,firebaseToken);

            PageChanger.MainWindowNavigation.ChangePage(home);
        }


        private void ListenValueChanges(DocumentSnapshot snapshot)
        {
            fileName = snapshot.GetValue<string>("fileName");
            fileDownloadUrl = snapshot.GetValue<string>("fileDownloadUrl");
            text = snapshot.GetValue<string>("text");

            this.Dispatcher.Invoke(() =>
            {
                txtToCopy.Text = text;

                txtFile.Text = fileName;
            });
            
        }


        private void BtnMinimize(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void BtnDownload(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path = path + "\\" + fileName;
                Console.WriteLine(path);
                client.DownloadFile(fileDownloadUrl, path);
                MessageBox.Show($"File is downloading to Desktop\n{fileName}");
            }
        }
        private void BtnCopy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(text);
        }
    }
}
