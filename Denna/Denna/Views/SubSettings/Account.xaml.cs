﻿using Core.Data;
using Core.Service.Users;
using Denna.Classes;
using Realms.Sync;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Denna.Views.SubSettings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            // reconnect, sync session
            // Get and Set user data
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Username.Text = UserService.GetUsername();
            var userInfo = UserService.GetUserInfo();
            FullName.Text = userInfo.FullName;
            Email.Text = userInfo.Email;
            Ses.Text = RealmContext.Instance.GetSession().State.ToString();
            base.OnNavigatedTo(e);
        }

        void LogOut(object sender, RoutedEventArgs e)
        {
            UserService.Logout();
            Frame.Navigate(typeof(Welcome));
            Frame.BackStack.Clear();
        }

        void Reconnect_Click(object sender, RoutedEventArgs e) => Session.Reconnect();

        async void CoPAss_Click(object sender, RoutedEventArgs e)
        {
            if (Pass.Text != Rpass.Text)
            {
                "Retype password".ShowMessage("Passwords not maching");
                return;
            }

            await UserService.ChangePass(Pass.Text);
        }

        void UsrInfo_Click(object sender, RoutedEventArgs e)
        {
            var user = UserService.GetUserInfo();
            user.Email = Email.Text;
            user.FullName = FullName.Text;
            UserService.UpdateUserInfo(UserService.GetUserInfo(), user);
        }
    }
}