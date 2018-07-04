// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace GoogleClientSample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnLogin { get; set; }

		[Outlet]
		UIKit.UIButton BtnLogout { get; set; }

		[Outlet]
		UIKit.UIImageView FullImageView { get; set; }

		[Outlet]
		UIKit.UILabel LblEmailAddress { get; set; }

		[Outlet]
		UIKit.UILabel LblUsername { get; set; }

		[Outlet]
		UIKit.UITextField TxtPassword { get; set; }

		[Outlet]
		UIKit.UITextField TxtUserName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnLogin != null) {
				BtnLogin.Dispose ();
				BtnLogin = null;
			}

			if (FullImageView != null) {
				FullImageView.Dispose ();
				FullImageView = null;
			}

			if (LblEmailAddress != null) {
				LblEmailAddress.Dispose ();
				LblEmailAddress = null;
			}

			if (LblUsername != null) {
				LblUsername.Dispose ();
				LblUsername = null;
			}

			if (TxtPassword != null) {
				TxtPassword.Dispose ();
				TxtPassword = null;
			}

			if (TxtUserName != null) {
				TxtUserName.Dispose ();
				TxtUserName = null;
			}

			if (BtnLogout != null) {
				BtnLogout.Dispose ();
				BtnLogout = null;
			}
		}
	}
}
