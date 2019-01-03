using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace MemeShare.WebContracts.Memes
{
    public class MemeService
    {
        public event Action<Meme> MemeReceived;

        HubConnection _connection;

        public MemeService()
        {
            // Setup connection to hub
            // Note that for android you have to use your IP addressn and the --urls parameter for .Web
            _connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/meme")
                                                    .Build();
            _connection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");

                    _connection.On<Meme>("memeReceived", (meme) =>
                    {
                        MemeReceived?.Invoke(meme);
                    });
                }
            });
        }

        public async Task SendMeme(MemeCreateRequest request)
        {
            await _connection.SendAsync("NewMeme", new Meme { Url = request.Url, User = request.User });
        }
    }
}
