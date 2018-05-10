using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using MyApp.MyService;
namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        dbServiceSoapClient db = new dbServiceSoapClient();
        public MainPage()
        {
            this.InitializeComponent();
            List<string> titles = new List<string>()
            {
            "Mr.",
            "Miss",
            "Md.",
            "Ms"
            };
            this.cmbTitle.ItemsSource = titles;

            List<string> gender = new List<string>()
            {
                "Male",
                "Female"
            };
            this.cmbGender.ItemsSource = gender;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var a =await db.SaveDataAsync(int.Parse(txtID.Text), cmbTitle.SelectedItem.ToString(), txtFname.Text, txtLname.Text, txtEmail.Text, txtPhoneNo.Text, cmbGender.SelectedItem.ToString());
            if (a.Body.SaveDataResult > 0)
            {
                Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Data saved successfully!!!!");
                msgShow.ShowAsync();
            }
            txtID.Text = "";
            txtFname.Text="";
            txtLname.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            cmbTitle.SelectedValue = -1;
            cmbGender.SelectedValue = -1;
            //Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("ID : " + txtID.Text + "\nTitle : " + cmbTitle.SelectedItem.ToString() + "\nFirst Name : " + txtFname.Text + "\nLast Name : " + txtLname.Text + "\nEmail : " + txtEmail.Text + "\nPhone No : " + txtPhoneNo.Text + "\nGender : " + cmbGender.SelectedItem.ToString());
            //msgShow.ShowAsync();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var a = await db.UpdateDataAsync(int.Parse(txtID.Text), cmbTitle.SelectedItem.ToString(), txtFname.Text, txtLname.Text, txtEmail.Text, txtPhoneNo.Text, cmbGender.SelectedItem.ToString());
            if (a.Body.UpdateDataResult > 0)
            {
                Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Data updated successfully!!!!");
                msgShow.ShowAsync();
            }

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var a = await db.DeleteDataAsync(int.Parse(txtID.Text));
            if (a > 0)
            {
                Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Data deleted successfully!!!!");
                msgShow.ShowAsync();
            }

        }

        
    }
}