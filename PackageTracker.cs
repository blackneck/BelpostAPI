using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace BelpostTrackingAPI
{
    public enum PackageType
    {
        regional = 1, international = 2
    }

    public class PackageTracker
    {
        public static string TrackByNumber(string trackNumber, PackageType type)
        {
            string responseString;

            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["item"] = trackNumber;
                values["internal"] = ((int)type).ToString();

                var response = client.UploadValues("http://search.belpost.by/ajax/search", values);
                responseString = Encoding.UTF8.GetString(response, 0, response.Length);                
            }

            return responseString;
        }        
    }
}
