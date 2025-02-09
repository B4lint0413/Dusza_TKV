using DuszaTKVGameLib;
using DuszaTKVGameLib.APIHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaWpfApp.ViewModels
{
    public class AdminGameWindowViewModel : ViewModelBase
    {
        private readonly GameAPIHandler _gameHandler;
        public AdminGameWindowViewModel() 
        {
            _gameHandler = new();
            games = _gameHandler.GetGames();
        }
        private IEnumerable<Game> games;
        public IEnumerable<Game> Games
        {
            get => games;
            set
            {
                games = value;
                Notify();
            }
        }
    }
}
