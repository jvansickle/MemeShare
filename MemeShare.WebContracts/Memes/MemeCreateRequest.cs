namespace MemeShare.WebContracts.Memes
{
    public class MemeCreateRequest
    {
        public string User { get; private set; }
        public string Url { get; private set; }

        public MemeCreateRequest(string user, string url)
        {
            User = user;
            Url = url;
        }
    }
}
