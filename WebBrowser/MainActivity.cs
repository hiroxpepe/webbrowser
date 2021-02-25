
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Xamarin.Essentials;

namespace WebBrowser {
    /// <summary>
    /// simple WebBrowser
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        WebView webView;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e) {
            if (keyCode == Keycode.Back && webView.CanGoBack()) {
                webView.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // protected Methods [verb]

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            webView = FindViewById<WebView>(Resource.Id.webview);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new DefaultWebViewClient());
            webView.LoadUrl("https://www.google.com/");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // inner Classes

        public class DefaultWebViewClient : WebViewClient {

            ///////////////////////////////////////////////////////////////////////////////////////////
            // public Methods [verb]

            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request) {
                view.LoadUrl(request.Url.ToString());
                return false;
            }
        }
    }
}
