using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using Java.IO;
using System.Net;
using System.IO;
using System.Json;
using System.Threading.Tasks;

namespace CompanyFinder
{
    //public class GetCompanyInfoTask: AsyncTask {
        
    //    MainActivity mainActivity;
    //    ProgressBar progressBar;
    //    TextView result;
    //    TextView email;

    //    static string APIkey = "8169165e74d2929e"; //"@string/APIkey";
    //    static string APIurl = "https://api.fullcontact.com/v2/company/lookup.json?domain="; //"@APIurl";

    //    protected void onPreExecute(MainActivity activity) {
        
    //        if (activity != null)
    //        {  
    //            mainActivity = activity;
    //            progressBar = mainActivity.FindViewById<ProgressBar>(Resource.Id.progressBar);
    //            progressBar.Visibility = ViewStates.Visible;
    //            result.Text = "";
    //        }      
    //     }

    //     protected void onPostExecute() {
    //         //
    //     }
 
    //    protected override Object DoInBackground(MainActivity activity)
    //    {
    //        if(activity != null)
    //        {
    //            mainActivity = activity;
    //            mainActivity.FindViewById<TextView>(Resource.Id.emailText);
    //        }
                                 
    //        Uri uri = new Uri(APIurl + email.Text + "&apiKey=" + APIkey);

    //        // Create an HTTP web request using the URL:
    //        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
    //        request.ContentType = "application/json";
    //        request.Method = "GET";

    //        try
    //        {
    //            // Send the request to the server and wait for the response:
    //            using (WebResponse response =  request.GetResponse())
    //            {
    //                // Get a stream representation of the HTTP web response:
    //                using (Stream stream = response.GetResponseStream())
    //                {
    //                    // Use this stream to build a JSON document object:
    //                    JsonValue jsonDoc =  JsonObject.Load(stream);
    //                    result.Text = jsonDoc.ToString();

    //                    // Return the JSON document:
    //                    return jsonDoc;
    //                }
    //            }
    //        }
          
    //        catch (System.Exception ex)
    //        {
    //            var err = ex.Message;
    //            return null;
    //        }
    //    }


    //    protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}