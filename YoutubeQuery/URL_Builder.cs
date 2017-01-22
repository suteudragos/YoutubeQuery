namespace YoutubeQuery {
    class URL_Builder {
        private const string API_KEY = ApiKey.KEY;
        public const string baseURL = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=";
        public string URL;

        public URL_Builder ( string query, int maxResults ) {
            URL = baseURL + query + "&type=video&maxResults=" + maxResults + "&locationRadius=10km&videoCaption=any&key=" + API_KEY;
        }

        public URL_Builder ( string query ) {
            URL = baseURL + query + "&type=video&maxResults=5&regionCode=RO&videoCaption=any&key=" + API_KEY;
        }


    }
}
