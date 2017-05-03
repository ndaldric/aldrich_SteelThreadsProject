using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Configuration;
using Newtonsoft.Json;
using Android.Util;
using System.Net.Http;
using System.Text;

namespace SteelThreadsProject_aldrich
{
    [Activity(Label = "SteelThreadsProject_aldrich", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        TextView textView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            textView = FindViewById<TextView>(Resource.Id.txtInput);
            Button button = FindViewById<Button>(Resource.Id.btnPost);

            button.Click += btn_Click;
        }

        private void btn_Click(object sender, System.EventArgs e)
        {

            string MyText = textView.Text.ToString();
            string popUp = "Your message has been posted.";
            Toast.MakeText(this, popUp, ToastLength.Short).Show();
            if (MyText == "")
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var url = string.Format("https://nickproject.azurewebsites.net/api/HttpTriggerCSharp1?code=m83CfuegOW5FAHrxzWeAvHiHp3a4guFdbTdeluzXkvPSuBWrbERL/w==" + "&");
                    var content = new StringContent("{myText:'" + MyText + "'}", Encoding.UTF8, "application/json");
                    var result = client.PostAsync(url, content).Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
                    //var content = new stringContent({ });
                    //var intent = new Intent(Intent.ActionView, url);
                    //StartActivity(intent);
                }
            }
            else
            {
                string error = "You haven't entered any text";
                Toast.MakeText(this, error, ToastLength.Short).Show();
            }
        }
    }
}
