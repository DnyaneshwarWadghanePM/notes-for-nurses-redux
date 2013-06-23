namespace Edward.Wilde.Note.For.Nurses.iOS.UI.iPhone {
    using System;
    using System.Drawing;

    using MonoTouch.UIKit;

    using Edward.Wilde.Note.For.Nurses.Core.BL;

    using MonoTouch.Dialog.Utilities;

    using Edward.Wilde.Note.For.Nurses.Core.BL.Managers;

    /// <summary>
	/// Displays personal information about the speaker
	/// </summary>
	public class PatientDetailViewController : UIViewController, IImageUpdated {
		UILabel nameLabel, titleLabel, companyLabel;
		UITextView bioTextView;
		UIImageView image;
		UIToolbar toolbar;
		UIScrollView scrollView;	
		int y = 0;
		int speakerId;
		Speaker speaker;
		const int ImageSpace = 80;
		
		public bool ShouldShowSessions { get; set; }

		public PatientDetailViewController (int speakerID) : base()
		{
			this.ShouldShowSessions = true;

			this.speakerId = speakerID;

			this.View.BackgroundColor = UIColor.White;
			
			if (AppDelegate.IsPad) {
				this.toolbar = new UIToolbar (new RectangleF(0,0,UIScreen.MainScreen.Bounds.Width, 40));
				
				this.View.AddSubview (this.toolbar);
				this.y = 40;
			}

			this.nameLabel = new UILabel () {
				TextAlignment = UITextAlignment.Left,
				Font = UIFont.FromName ("Helvetica-Light", AppDelegate.Font16pt),
				BackgroundColor = UIColor.FromWhiteAlpha (0f, 0f)
			};
			this.titleLabel = new UILabel () {
				TextAlignment = UITextAlignment.Left,
				Font = UIFont.FromName ("Helvetica-LightOblique", AppDelegate.Font10pt),
				TextColor = UIColor.DarkGray,
				BackgroundColor = UIColor.FromWhiteAlpha (0f, 0f)
			};
			this.companyLabel = new UILabel () {
				TextAlignment = UITextAlignment.Left,
				Font = UIFont.FromName ("Helvetica-Light", AppDelegate.Font10pt),
				TextColor = UIColor.DarkGray,
				BackgroundColor = UIColor.FromWhiteAlpha (0f, 0f)
			};
			 this.bioTextView = new UITextView () {
				TextAlignment = UITextAlignment.Left,
				Font = UIFont.FromName ("Helvetica-Light", AppDelegate.Font10_5pt),
				BackgroundColor = UIColor.FromWhiteAlpha (0f, 0f),
				ScrollEnabled = true,
				Editable = false
			};
			this.image = new UIImageView();

			
			this.scrollView = new UIScrollView();

			this.scrollView.AddSubview (this.nameLabel);
			this.scrollView.AddSubview (this.titleLabel);
			this.scrollView.AddSubview (this.companyLabel);
			this.scrollView.AddSubview (this.bioTextView);
			this.scrollView.AddSubview (this.image);	

			this.Add (this.scrollView);	
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			this.speaker = SpeakerManager.GetSpeaker (this.speakerId);
			// this shouldn't be null, but it gets that way when the data
			// "shifts" underneath it. need to reload the screen or prevent
			// selection via loading overlay - neither great UIs :-(
			if (this.speaker != null)  {	
				this.LayoutSubviews ();
				this.Update ();
			}
		}

		void LayoutSubviews ()
		{
			var full = this.View.Bounds;
			var bigFrame = full;
			
			this.scrollView.Frame = full;

			bigFrame.X = ImageSpace+13+17;
			bigFrame.Y = this.y + 27; // 15 -> 13
			bigFrame.Height = 26;
			bigFrame.Width -= (ImageSpace+13+17);
			this.nameLabel.Frame = bigFrame;
			
			var smallFrame = full;
			smallFrame.X = ImageSpace+13+17;
			smallFrame.Y = this.y + 27+26;
			smallFrame.Height = 15; // 12 -> 15
			smallFrame.Width -= (ImageSpace+13+17);
			this.titleLabel.Frame = smallFrame;
			
			smallFrame.Y += this.y + 17;
			this.companyLabel.Frame = smallFrame;

			this.image.Frame = new RectangleF(13, this.y + 15, 80, 80);
			
			this.bioTextView.Font = UIFont.FromName ("Helvetica-Light", AppDelegate.Font10_5pt);
			
			if (!String.IsNullOrEmpty(this.speaker.Bio)) {
				var f = new SizeF (full.Width - 13 * 2, 4000);
				SizeF size = this.bioTextView.StringSize (this.speaker.Bio
									, this.bioTextView.Font
									, f);
				this.bioTextView.Frame = new RectangleF(5
									, this.y + 115
									, f.Width
									, size.Height + 120); // doesn't seem to measure properly... CR/LF issues?
			
				this.bioTextView.ScrollEnabled = true;
				
				this.scrollView.ContentSize = new SizeF(320, this.bioTextView.Frame.Y + this.bioTextView.Frame.Height + 20);
			} else {
				this.bioTextView.ScrollEnabled = false;
				this.bioTextView.Frame = new RectangleF(5, this.y + 115, 310, 30);;
			}					
		}

		void Update()
		{
			this.nameLabel.Text = this.speaker.Name;
			this.titleLabel.Text = this.speaker.Title;
			this.companyLabel.Text = this.speaker.Company;
			
			if (!String.IsNullOrEmpty(this.speaker.Bio)) {
				this.bioTextView.Text = this.speaker.Bio;
				this.bioTextView.TextColor = UIColor.Black;
			} else {
				this.bioTextView.TextColor = UIColor.Gray;
				this.bioTextView.Text = "No background information available.";
			}
			if (this.speaker.ImageUrl != "http://www.mobileworldcongress.com") {
				var u = new Uri(this.speaker.ImageUrl);
				this.image.Image = ImageLoader.DefaultRequestImage (u, this);
			}
		}

		public void UpdatedImage (Uri uri)
		{
			this.image.Image = ImageLoader.DefaultRequestImage (uri, this);
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
        {
            return AppDelegate.IsPad;
        }

	}
}