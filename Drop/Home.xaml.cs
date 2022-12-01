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
using Firebase.Auth;
using Google.Cloud.Firestore;
using Firebase.Storage;
using System.IO;

namespace Drop
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {

        string firebaseToken;
        User user;
        FirestoreDb db = FirestoreDb.Create(projectId: "");


        public Home(User u, string f)
        {
            InitializeComponent();
            user = u;
            firebaseToken = f;
        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                drag1.Visibility = Visibility.Hidden;
                drag2.Visibility = Visibility.Visible;
                txtFile.Text = files[0];
            }
        }

        private void BtnMinimize(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
       
        private async void BtnSend(object sender, RoutedEventArgs e)
        {
            char[] delimiterChars = { '\\' };

            var stream = File.Open(txtFile.Text, FileMode.Open);

            var fileName = txtFile.Text.Split(delimiterChars).Last();


            var task = new FirebaseStorage("", options:new FirebaseStorageOptions{
                AuthTokenAsyncFactory = () => Task.FromResult(firebaseToken),
            })
             .Child("values")
             .Child(user.LocalId)
             .Child(fileName)
             .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, proges) => Console.WriteLine($"Progress: {proges.Percentage} %");

            // Await the task to wait until upload is completed and get the download url
            var downloadUrl = await task;

            Dictionary<string, object> valueToWrite = new Dictionary<string, object>
                {
                    { "fileName", fileName },
                    { "fileDownloadUrl", downloadUrl },
                };

            await WriteAValue(valueToWrite);

            drag1.Visibility = Visibility.Visible;
            drag2.Visibility = Visibility.Hidden;

            MessageBox.Show("Done!");
        }

        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            drag1.Visibility = Visibility.Visible;
            drag2.Visibility = Visibility.Hidden;
        }
        
        private async void BtnSendText(object sender, RoutedEventArgs e)
        {
            await WriteDataFromTextBlock();
        }
        
        private void BtnChangePage(object sender, RoutedEventArgs e)
        {
            var nextPage = new WValues(user,firebaseToken);

            PageChanger.MainWindowNavigation.ChangePage(nextPage);
        }

        private async Task WriteDataFromTextBlock()
        {
            Dictionary<string, object> valueToWrite = new Dictionary<string, object>
                {
                    { "text", txtText.Text },
                };
            await WriteAValue(valueToWrite);

            MessageBox.Show("Done!");
        }

        private async Task WriteAValue(Dictionary<string, object> valueToWrite)
        {
            try
            {
                await db.Collection("values").Document(user.LocalId).UpdateAsync(valueToWrite);
            }
            catch
            {
                await db.Collection("values").Document(user.LocalId).SetAsync(valueToWrite);
            }
        }
    }
}
