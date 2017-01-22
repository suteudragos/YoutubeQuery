using Newtonsoft.Json;
using System.Collections.Generic;
using Wox.Plugin;

namespace YoutubeQuery {
    public class Main : IPlugin {
        private string videoId;
        PluginInitContext _context;

        public void Init ( PluginInitContext context ) {
            _context = context;
        }

        public List<Result> Query ( Query query ) {

            URL_Builder urlBuilder = new URL_Builder( query.Search );

            using (var webClient = new System.Net.WebClient()) {
                var json = webClient.DownloadString( urlBuilder.URL );
                YoutubeApiResponse YTApiRes = JsonConvert.DeserializeObject<YoutubeApiResponse>( json );

                List<Result> result = new List<Result>();
                foreach (Item item in YTApiRes.items) {
                    result.Add( new Result() {
                        Title = item.snippet.title,
                        SubTitle = item.snippet.channelTitle,
                        IcoPath = "icon.png",
                        Action = e => {
                            item.id.TryGetValue( "videoId", out videoId );
                            System.Diagnostics.Process.Start( "https://www.youtube.com/watch?v=" + videoId );
                            return true;
                        }
                    } );
                }
                return result;
            }
        }
    }
}
