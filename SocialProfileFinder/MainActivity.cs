using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Org.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Json;
using RestSharp;
using System.Net.Http;
using ModernHttpClient;
using Android.Webkit;
using Android.Graphics;
using Java.IO;
using Newtonsoft.Json;
using Android.Text.Method;
using Android.Text;
using Android.Text.Util;
using System.Collections.Generic;


namespace CompanyFinder
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/FindCompany")]
    public class MainActivity : Activity
    {
        
        LinearLayout linearLayout;

        Toolbar toolBar;

        TextView noResults;
        Button findBtn;
        TextView email;
        ProgressBar progressBar;
        TextView result;
        static string APIkey = "8169165e74d2929e"; //"@string/APIkey";
        static string APIurl = "https://api.fullcontact.com/v2/company/lookup.json?domain="; //"@APIurl";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);
           
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout);

            toolBar = FindViewById<Toolbar>(Resource.Id.toolBar);
            noResults = FindViewById<TextView>(Resource.Id.noResultsText);
            findBtn = FindViewById<Button>(Resource.Id.findButton);
            email = FindViewById<TextView>(Resource.Id.emailText);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            result = FindViewById<TextView>(Resource.Id.resultView);

            Color toolBarTitleColor = new Color(0,0,0);
            toolBar.SetTitleTextColor(toolBarTitleColor);

            findBtn.Click += async (sender, e) =>
            {
                // Get the domain entered by the user and create a query
                Uri uri = new Uri(APIurl + email.Text + "&apiKey=" + APIkey);

                // Fetch the company information asynchronously, parse the results and update the screen
                JsonValue json = await FetchInfoAsync(uri);
                if (json != null)
                {
                    ParseAndDisplay(json);
                }
                else
                {
                    linearLayout.Visibility = ViewStates.Gone;
                    noResults.Visibility = ViewStates.Visible;
                }
            };
        }

        public void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position.ToString(), ToastLength.Long).Show();
        }


        private async Task<JsonValue> FetchInfoAsync(Uri uri)
        {
            try
            {
                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    using (var response = await client.GetAsync(uri))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (Stream stream = await response.Content.ReadAsStreamAsync())
                            {
                                // Use this stream to build a JSON document object
                                JsonValue json = await Task.Run(() => System.Json.JsonObject.Load(stream));
                                //result.Text = json.ToString().Replace("\"", string.Empty);
                                return json;
                            }
                        }
                        return null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        private void ParseAndDisplay(JsonValue json)
        {
            var notFound = "not found";
            
            //TextView logo = FindViewById<TextView>(Resource.Id.logoText);
            //ImageView logo = FindViewById<ImageView>(Resource.Id.logoImageView);
            WebView logo = FindViewById<WebView>(Resource.Id.logoWebView);
            TextView website = FindViewById<TextView>(Resource.Id.websiteText);
            TextView organizationName = FindViewById<TextView>(Resource.Id.nameText);
            TextView onLine = FindViewById<TextView>(Resource.Id.onLineText);
            TextView numEmploy = FindViewById<TextView>(Resource.Id.numEmpText);
            TextView founded = FindViewById<TextView>(Resource.Id.foundedText);
            TextView overview = FindViewById<TextView>(Resource.Id.overviewText);
            TextView email1Label = FindViewById<TextView>(Resource.Id.email1Label);
            TextView email2Label = FindViewById<TextView>(Resource.Id.email2Label);
            TextView email1 = FindViewById<TextView>(Resource.Id.email1Text);
            TextView email2 = FindViewById<TextView>(Resource.Id.email2Text);
            TextView phone1 = FindViewById<TextView>(Resource.Id.phone1Text);
            TextView phone2 = FindViewById<TextView>(Resource.Id.phone2Text);
            TextView phone1Label = FindViewById<TextView>(Resource.Id.phone1Label);
            TextView phone2Label = FindViewById<TextView>(Resource.Id.phone2Label);
            TextView organazation = FindViewById<TextView>(Resource.Id.nameText);
           // TextView address1Line1 = FindViewById<TextView>(Resource.Id.addressText);
            TextView link1 = FindViewById<TextView>(Resource.Id.link1Text);
            TextView link2 = FindViewById<TextView>(Resource.Id.link2Text);
            TextView social1 = FindViewById<TextView>(Resource.Id.social1Text);
            TextView social2 = FindViewById<TextView>(Resource.Id.social2Text);
            
            JsonValue company =  json;
            

            if (company.ContainsKey("logo"))
            { 
                //loadImage(logo, company["logo"]);
                //web.LoadDataWithBaseURL(null, "<html><head></head><body><table style=\"width:100%; height:100%;\"><tr><td style=\"vertical-align:middle;\"><img src=\"" + company["logo"] + "\"></td></tr></table></body></html>", "html/css", "utf-8", null);
                logo.LoadUrl(company["logo"]);
                Color transparent = new Color(0x00000000);
                logo.SetBackgroundColor(transparent);
                logo.Visibility = ViewStates.Visible;

            }

            if (company.ContainsKey("website"))
            {
                website.Text = company["website"].ToString().Replace("\"", string.Empty);
                Linkify.AddLinks(website, MatchOptions.WebUrls);
            
            }
            else
            {
                website.Text = notFound;
            }

            onLine.Text = company.ContainsKey("onlineSince") ? company["onlineSince"].ToString().Replace("\"", string.Empty) : notFound;

            JsonValue organization = company.ContainsKey("organization") ? company["organization"] : null;

            if (organazation != null)
            {
                organizationName.Text = organization.ContainsKey("name") ? organization["name"].ToString().Replace("\"", string.Empty).Replace("\"", string.Empty) : notFound;
                numEmploy.Text = organization.ContainsKey("approxEmployees") ? organization["approxEmployees"].ToString().Replace("\"", string.Empty) : notFound;
                founded.Text = organization.ContainsKey("founded") ? organization["founded"].ToString().Replace("\"", string.Empty) : notFound;
                overview.Text = organization.ContainsKey("overview") ? organization["overview"].ToString().Replace("\"", string.Empty) : notFound;
                
                JsonValue contactInfo = organization["contactInfo"];

                if (contactInfo.ContainsKey("emailAddresses"))
                {
                    JsonValue emailAddress = contactInfo["emailAddresses"];
                    
                    email1.Text = emailAddress[0].ContainsKey("value") ? emailAddress[0]["value"].ToString().Replace("\"", string.Empty) : notFound;
                    email2.Text = emailAddress.Count >1 && emailAddress[1].ContainsKey("value") ? emailAddress[0]["value"].ToString().Replace("\"", string.Empty): notFound;
                    
                }
              
                if (contactInfo.ContainsKey("phoneNumbers"))
                {
                    JsonValue phone = contactInfo["phoneNumbers"];
                    
                    phone1.Text = phone[0].ContainsKey("number") ? phone[0]["number"].ToString().Replace("\"", string.Empty) : notFound;
                    phone2.Text = phone.Count > 1 && phone[1].ContainsKey("number") ? phone[1]["number"].ToString().Replace("\"", string.Empty) : notFound;
                   
                }

                if (organization.ContainsKey("links"))
                {
                    JsonValue link = organization["links"];
                    
                        if (link[0].ContainsKey("url"))
                        {
                            link1.Text = link[0]["url"].ToString().Replace("\"", string.Empty);
                            Linkify.AddLinks(link1, MatchOptions.WebUrls);
                            
                        }
                        else
                        {
                            link1.Text = notFound;
                        }

                        if (link.Count > 1 && link[1].ContainsKey("url"))
                        {
                            link2.Text = link[1]["url"].ToString().Replace("\"", string.Empty);
                            Linkify.AddLinks(link2, MatchOptions.WebUrls);
                        }
                        else
                        {
                            link2.Text = notFound;
                        }
                    
                    }

                if (company.ContainsKey("socialProfiles"))
                {
                    JsonValue socialProfile = company["socialProfiles"];
                    {
                        if (socialProfile[0].ContainsKey("url"))
                        {
                            social1.Text = socialProfile[0]["typeName"].ToString().Replace("\"", string.Empty) + ":   " + socialProfile[0]["url"].ToString().Replace("\"", string.Empty);
                            Linkify.AddLinks(social1, MatchOptions.WebUrls);
                        }
                        else
                        {
                            social1.Text = notFound;
                        }

                        if (socialProfile.Count > 1 && socialProfile[1].ContainsKey("url"))
                        {
                            social2.Text = socialProfile[1]["typeName"].ToString().Replace("\"", string.Empty) + ":   " + socialProfile[1]["url"].ToString().Replace("\"", string.Empty);
                            Linkify.AddLinks(social2, MatchOptions.WebUrls);
                        }
                        else
                        {
                            social2.Text = notFound;
                        }
                    }
                }
                //TODO: addresses
                if (contactInfo.ContainsKey("addresses"))
                {
                                  
                }
            }
            else
            {
                linearLayout.Visibility = ViewStates.Gone;
                noResults.Visibility = ViewStates.Visible;
            }
        }

        private void LoadImage(ImageView logo, string logoUrl)
        {
            Bitmap bitImage = null;
           
            try 
            {
                Stream  inputStream = new Java.Net.URL(logoUrl).OpenStream();
                bitImage = BitmapFactory.DecodeStream(inputStream);

                logo.SetImageBitmap(bitImage);
            } 
            catch (System.Exception ex) 
            {
                var err = ex.Message;
            }
                
        }
        
    }
}