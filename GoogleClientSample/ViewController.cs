using System;
using System.Threading.Tasks;
using Foundation;
using Google.SignIn;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using UIKit;

namespace GoogleClientSample
{
    public partial class ViewController : UIViewController
    {
        private readonly IGoogleClientManager _googleClientManager;

        public UserProfile User { get; set; } = new UserProfile();

        protected ViewController(IntPtr handle) : base(handle)
        {
            _googleClientManager = CrossGoogleClient.Current;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BtnLogout.Hidden = true;
            BtnLogout.TouchUpInside += (object sender, EventArgs e) =>
            {
                _googleClientManager.Logout();
                BtnLogin.Hidden = false;
                BtnLogout.Hidden = true;
                _googleClientManager.OnLogout += (object s, EventArgs ee) =>
                {
                    LblUsername.Text = string.Empty;
                    LblEmailAddress.Text = string.Empty;
                    FullImageView.Image = new UIImage();
                };
            };

            BtnLogin.TouchUpInside += async delegate
            {
                _googleClientManager.OnLogin += _googleClientManager_OnLogin;
                try
                {
                    await _googleClientManager.LoginAsync();
                }
                catch (GoogleClientSignInNetworkErrorException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (GoogleClientSignInCanceledErrorException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (GoogleClientSignInInvalidAccountErrorException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (GoogleClientSignInInternalErrorException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (GoogleClientBaseException e)
                {
                    Console.WriteLine(e.Message);
                }
            };
        }
        void _googleClientManager_OnLogin(object sender, GoogleClientResultEventArgs<Plugin.GoogleClient.Shared.GoogleUser> e)
        {
            if (e.Data != null)
            {
                Plugin.GoogleClient.Shared.GoogleUser googleUser = e.Data;

                User.Name = googleUser.Name;
                User.Email = googleUser.Email;
                User.Picture = googleUser.Picture;

                LblUsername.Text = User.Name;
                LblEmailAddress.Text = User.Email;
                var data = NSData.FromUrl(NSUrl.FromString(User.Picture.AbsoluteUri));
                FullImageView.Image = new UIImage(data);
            }
            BtnLogin.Hidden = true;
            BtnLogout.Hidden = false;
            _googleClientManager.OnLogin -= _googleClientManager_OnLogin;
        }
    }

    public class UserProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
    }
}
