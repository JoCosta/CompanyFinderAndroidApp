using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyFinder
{
//    public class RetrieveDataTask: Android.OS.AsyncTask
//    {
//        protected void onPreExecute() {
//            progressBar.setVisibility(View.VISIBLE);
//            responseView.setText("");
//        }

//        protected String doInBackground(Void... urls) {
//            String email = emailText.getText().toString();
//            // Do some validation here

//            try {
//                URL url = new URL(API_URL + "email=" + email + "&apiKey=" + API_KEY);
//                HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
//                try {
//                    BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
//                    StringBuilder stringBuilder = new StringBuilder();
//                    String line;
//                    while ((line = bufferedReader.readLine()) != null) {
//                        stringBuilder.append(line).append("\n");
//                    }
//                    bufferedReader.close();
//                    return stringBuilder.toString();
//                }
//                finally{
//                    urlConnection.disconnect();
//                }
//            }
//            catch(Exception e) {
//                Log.e("ERROR", e.getMessage(), e);
//                return null;
//            }
//        }

//        protected void onPostExecute(String response) {
//            if(response == null) {
//                response = "THERE WAS AN ERROR";
//            }
//            progressBar.setVisibility(View.GONE);
//            Log.i("INFO", response);
//            responseView.setText(response);
//            // TODO: check this.exception
//            // TODO: do something with the feed

////            try {
////                JSONObject object = (JSONObject) new JSONTokener(response).nextValue();
////                String requestID = object.getString("requestId");
////                int likelihood = object.getInt("likelihood");
////                JSONArray photos = object.getJSONArray("photos");
////                .
////                .
////                .
////                .
////            } catch (JSONException e) {
////                e.printStackTrace();
////            }

//    }
//}
}