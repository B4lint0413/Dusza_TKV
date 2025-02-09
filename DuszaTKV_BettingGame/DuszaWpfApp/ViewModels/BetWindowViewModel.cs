using DuszaTKVGameLib;
using DuszaTKVGameLib.APIHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaWpfApp.ViewModels
{
    public class BetWindowViewModel : ViewModelBase
    {
        private readonly GameAPIHandler _gameHandler;
        public BetWindowViewModel()
        {
            _gameHandler = new GameAPIHandler();
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
