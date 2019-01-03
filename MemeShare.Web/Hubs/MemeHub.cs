using System;
using System.Threading.Tasks;
using MemeShare.WebContracts.Memes;
using Microsoft.AspNetCore.SignalR;

namespace MemeShare.Web.Hubs
{
    public class MemeHub : Hub
    {
        public async Task NewMeme(MemeCreateRequest request)
        {
            await Clients.All.SendAsync("memeReceived", new Meme { User = request.User, Url = request.Url });
        }
    }
}
