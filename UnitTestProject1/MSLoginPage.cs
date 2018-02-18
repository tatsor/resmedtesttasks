using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UIOperationsTestTask
{
    public class MSLoginPage : UITestBase
    {
        class IDs
        {
            public static string UseAnotherAccount = "otherTile";
            public static string UserName = "i0116";
            public static string NextSignIn = "idSIButton9";
            public static string Back = "idBtn_Back";
            public static string Password = "i0118";
            public static string KeepMeSignedInText = "KmsiDescription";
        }


        public void DisplayLogin()
        {
            if (!DoesElementExist(Selectors.Id, IDs.UserName))
            {
                // If the "Use another account" button is available, click it
                if (DoesElementExist(Selectors.Id, IDs.UseAnotherAccount))
                {
                    Click(IDs.UseAnotherAccount);
                    WaitUntilElementExists(Selectors.Id, IDs.UserName);
                }
            }
        }

        public void AzureADLogin(string userName, string password)
        {
            SetTextBoxValue(IDs.UserName, userName);

            WaitUntilElementExists(Selectors.Id, IDs.NextSignIn);
            // Click the "Next" button
            Click(IDs.NextSignIn);

            WaitUntilElementExists(Selectors.Id, IDs.Password);
            SetTextBoxValue(IDs.Password, password);

            // Click the "Sign in" button
            //Loop until the Url changes - sometimes the click is lost.
            var urlBeforeSignInClick = GetCurrentUrl();
            var signInClickSuccessful = false;
            while (!signInClickSuccessful)
            {
                try
                {
                    Click(IDs.NextSignIn);

                    signInClickSuccessful = (GetCurrentUrl() != urlBeforeSignInClick ||
                        DoesElementExist(Selectors.Id, IDs.KeepMeSignedInText));
                }
                catch (InvalidOperationException)
                {
                    // InvalidOperationException is thrown by the Click in Chrome
                    // because there is another element blocking the button for some period of time.
                }
                catch (StaleElementReferenceException)
                {
                    // this is thrown occasionally as well - it appears it can be retried successfully
                }
            }

            // Check if the Keep me signed in prompt appears
            if (DoesElementExist(Selectors.Id, IDs.KeepMeSignedInText))
            {
                // Click "no"
                Click(IDs.Back);
            }
        }

        public bool IsValid
        {
            get
            {
                WaitUntilElementExists(Selectors.Id, "loginHeader");
                return true;
            }
        }

        string Url
        {
            get
            {
                return "https://login.microsoftonline.com/";

            }
        }

        public void NavigateTo()
        {
            NavigateToFullUrl(Url);
        }

        public bool IsPasswordError
        {
            get
            {
                DoesElementExist(Selectors.Id, "passwordError");
                return true;
            }
        }
    }
}
