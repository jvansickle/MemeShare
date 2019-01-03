using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MemeShare.WebContracts.Memes;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace MemeShare.ViewModels
{
    public class PublicMemesViewModel : ViewModel
    {
        ObservableCollection<Meme> _memes;
        public ObservableCollection<Meme> Memes
        {
            get => _memes;
            set
            {
                _memes = value;
                NotifyPropertyChanged();
            }
        }

        string _memeUrl;
        public string MemeUrl
        {
            get => _memeUrl;
            set
            {
                _memeUrl = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SendMeme => new Command(async () => await HandleSendMeme());

        static readonly string _userId = Guid.NewGuid().ToString();

        MemeService _memeService;

        public PublicMemesViewModel()
        {
            Memes = new ObservableCollection<Meme>();
            _memeService = new MemeService();
            _memeService.MemeReceived += OnMemeReceived;
        }

        void OnMemeReceived(Meme meme)
        {
            Memes.Add(meme);
        }

        async Task HandleSendMeme()
        {
            if (string.IsNullOrWhiteSpace(MemeUrl))
            {
                return;
            }

            await _memeService.SendMeme(new MemeCreateRequest(_userId, MemeUrl))
                              .ContinueWith((t) =>
                              {
                                  if(!t.IsFaulted)
                                  {
                                      MemeUrl = string.Empty;
                                  }
                              });
        }
    }
}
