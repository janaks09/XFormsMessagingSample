using Lotz.Xam.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CallSMSSample
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new Controller();
        }

        public class Controller: ContentPage
        {
            public Controller()
            {
                Label Title = new Label()
                {
                    Text = "Call-SMS-Email Sample",
                    FontSize = 30, HorizontalOptions = LayoutOptions.Center
                };
                Entry MsgTo = new Entry()
                {
                    Keyboard = Keyboard.Telephone,
                    Placeholder = "Message To:"
                };
                Entry Message = new Entry()
                {
                    Placeholder = "Enter Message"
                };
                Button SendSms = new Button()
                {
                    Text = "Send"
                };

                Entry PhoneNumber = new Entry()
                {
                    Keyboard = Keyboard.Telephone,
                    Placeholder = "Enter phone number"
                };
                Button CallNo = new Button()
                {
                    Text = "Call"
                };

                Entry EmailTo = new Entry()
                {
                    Placeholder = "Eamil To:",
                    Keyboard = Keyboard.Email
                };
                Entry EmailSubject = new Entry()
                {
                    Placeholder = "Subject"
                };
                Entry EmailBody = new Entry()
                {
                    Placeholder = "Message"
                };
                Button SendEmail = new Button()
                {
                    Text = "Send email"
                };

                var stack = new StackLayout() { Spacing = 0, Children = { Title, MsgTo, Message, SendSms, PhoneNumber, CallNo,
                                                                 EmailTo, EmailSubject, EmailBody, SendEmail
                                                             } };
                Content = stack;

                //You have to add Nuget Packages on each platform
                SendSms.Clicked += (sender, e) => 
                {
                    var SmsTask = MessagingPlugin.SmsMessenger;

                    if (SmsTask.CanSendSms)
                        SmsTask.SendSms(MsgTo.Text, Message.Text);
 
                };
                CallNo.Clicked += (sender, e) =>
                {
                    //Don't forgot to enable ID_CAP_PHONEDAILER on manifest file
                     var PhoneCallTask = MessagingPlugin.PhoneDialer;

                     if (PhoneCallTask.CanMakePhoneCall)
                         PhoneCallTask.MakePhoneCall(PhoneNumber.Text);
                };

                SendEmail.Clicked += (sender, e) => 
                {
                    var EmailTask = MessagingPlugin.EmailMessenger;

                    if (EmailTask.CanSendEmail)
                        EmailTask.SendEmail(EmailTo.Text, EmailSubject.Text, EmailBody.Text);
                };
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
