using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuszaTKVGameLib
{
	public class Odds
	{
		private Games gameList;
		private Events events;

		public Odds(Games gameList, Events events)
		{
			this.gameList = gameList;
			this.events = events;
		}

		public Games UpdateOdds()
		{
			return new Games(gameList.GetOwnGames(""));
		}
	}
}
