using Bolo.Entities.Models.Abilities;
using Bolo.Entities.Models.Cards;
using Bolo.Entities.Models.Collections;
using Bolo.Entities.Models.Enums;
using Bolo.Entities.Models.Players;
using Bolo.Logic.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bolo.Logic.Managers
{
    public class GameManager
    {
        protected internal GameManager()
        {
            _players = new List<IPlayer>();
            _playerScore = new Dictionary<IPlayer, long>();
            _playerMoves = new Dictionary<IPlayer, IList<IPlayerMove>>();
            CreateDeck();
        }
        public static GameManager Instance { get; protected set; } = new GameManager();

        private long _turnNumber { get; set; }

        private readonly IList<IPlayer> _players;

        private readonly IDictionary<IPlayer, long> _playerScore;
        private readonly IDictionary<IPlayer, IList<IPlayerMove>> _playerMoves;

        private Deck _deck;

        protected bool _isGameInProgress = false;


        public void StartGame(IList<IPlayer> players)
        {
            _isGameInProgress = true;
            foreach (var playa in players)
            {
                var hand = _deck.GetCards(10);
                playa.Hand.AddCards(hand);
            }
            players.ToList().ForEach(p => AddPlayer(p));
 
            _turnNumber++;
        }

        public void PlayGame()
        {
            while (_isGameInProgress)
            {
                foreach (var player in _players)
                {
                    var move = MakeMove(player);
                    if (!IsValidMove(move))
                    {
                        EndGame();
                        break;
                    }
                    else
                    {
                        UpdatePlayeMove(move);
                        UpdatePlayerScore(player, move.NewScore);
                        Console.WriteLine($"{player.PlayerDisplayName} your current score is {GetPlayerScore(player)}!");
                        
                    }
                }
            }

            //Hand out cards to each player
            //While win conditions are not met
                //Check to see if an ability can be actvated?
                
        }

        public void EndGame()
        {
            _isGameInProgress = false;
            _players.Clear();
            _playerScore.Clear();
        }

        public virtual void AddPlayer(IPlayer player)
        {
            if (player?.PlayerId != null && player?.PlayerId != Guid.Empty)
            {
                var tempPlayer = _players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
                if (tempPlayer == null)
                {
                    _players.Add(player);
                    _playerScore.Add(player, 0);
                }

            }
        }

        public virtual void RemovePlayer(IPlayer player)
        {
            var playerToRemove = _players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
            if (playerToRemove != null)
            {
                _players.Remove(playerToRemove);
                _playerScore.Remove(player);
            }
        }

        public long? GetPlayerScore(IPlayer player)
        {
            long? playerScore = null;
            if (_playerScore.ContainsKey(player))
            {
                playerScore = _playerScore[player];
            }

            return playerScore;
        }

        public void UpdatePlayerScore(IPlayer player, long newScore)
        {
            if (_playerScore.ContainsKey(player))
            {
                _playerScore[player] = newScore;
            }
        }

        public IList<IPlayerMove> GetPlayerMoves(IPlayer player)
        {
            IList<IPlayerMove> playersMoves = null;
            if (_playerMoves.ContainsKey(player))
            {
                playersMoves = _playerMoves[player];
            }
            return playersMoves;
        }

        public IList<IPlayer> GetPlayers()
        {
            return _players;
        }

        public void SwapMoves(IPlayer player, IPlayer otherPlayer)
        {
            if(_playerMoves.ContainsKey(player) && _playerMoves.ContainsKey(otherPlayer) && _playerScore.ContainsKey(player) && _playerScore.ContainsKey(otherPlayer)){
                var swapPlayerMoves = _playerMoves[player];
                var swapPlayerValues = _playerScore[player];
                var swapOtherPlayerMoves = _playerMoves[otherPlayer];
                var swapOtherPlayerValues = _playerScore[otherPlayer];
                _playerMoves[otherPlayer] = swapPlayerMoves;
                _playerScore[otherPlayer] = swapPlayerValues;
                _playerMoves[player] = swapOtherPlayerMoves;
                _playerScore[player] = swapOtherPlayerValues;
            }
        }

        private void UpdatePlayeMove(PlayerMove playerMove)
        {
            if (!_playerMoves.ContainsKey(playerMove.Player))
            {
                _playerMoves.Add(playerMove.Player, new List<IPlayerMove>() { playerMove });
            }
            else
            {
                _playerMoves[playerMove.Player].Add(playerMove);
            }
        }


        private void CreateDeck()
        {
            _deck = new Deck();
            var cards = new List<Card>();
            var cardNames = Enum.GetValues(typeof(CardName)).Cast<CardName>();
            foreach (var cardName in cardNames)
            {
                var cardAbility = cardName.GetCardAbility2();
                var cardValue = cardName.GetInitalCardValue();
                var cardSet = GetSetOfCards(new Card(cardName, cardAbility, cardValue), 4).ToCards();
                cards.AddRange(cardSet);
            }
            cards.Shuffle();
            _deck.AddCards(cards);
            
        }



        private IEnumerable<ICard> GetSetOfCards(ICard CardType, int numberOfSets)
        {
            var set = new List<ICard>();
            for (int i = 0; i < numberOfSets; i++)
            {
                set.Add(CardType);
            }

            return set;
        }


        private PlayerMove MakeMove(IPlayer player)
        {
            Console.WriteLine($"{player.PlayerDisplayName} Your Current Card Score is {_playerScore[player]}");
            Console.WriteLine($"The current Cards in your hand are:");
            var index = 0;
            player.Hand.Cards.ToList().ForEach(c => {  Console.WriteLine($"{c.Name}, Enter [{index}] to use"); index++; });
            var key = Console.ReadKey(true);
            var card = player.Hand.Cards[int.Parse(key.KeyChar.ToString())];
            player.Hand.RemoveCard(card);
            Console.WriteLine($"You played {card.Name}");
            var move =  new PlayerMove
            {
                Player = player,
                CardPlayed = card,
                NewScore = _playerScore[player] + card.Value
            };

            card.Ability.Execute(move);

            return move;
        }

        private bool IsValidMove(PlayerMove move)
        {
            var isValidMove = true;
            if(move.Player.Hand.Cards.Count == 0 && (move.CardPlayed.Name == CardName.Blast || move.CardPlayed.Name == CardName.Bolt || move.CardPlayed.Name == CardName.Mirror ||  move.CardPlayed.Name == CardName.Force))
            {
                isValidMove = false;
                return isValidMove;
            }

            if (!move.Player.Hand.Cards.Any())
            {
                isValidMove = false;
                return isValidMove;
            }

            if (_playerMoves.Any() && _playerMoves.ContainsKey(move.Player))
            {
                var currentPlayerScore = GetPlayerScore(move.Player) + move.NewScore;
                var lastPlayerScore = _playerScore.FirstOrDefault(p => p.Key != move.Player).Value;
                if (currentPlayerScore < lastPlayerScore)
                {
                    isValidMove = false;
                    return isValidMove;
                }
                else if(currentPlayerScore == lastPlayerScore)
                {
                    ReplaceHands();
                    _players.ToList().ForEach(p => UpdatePlayerScore(p, 0));
                }
            }

            return isValidMove;
        }

        private void ReplaceHands()
        {
            _players.ToList().ForEach(p => p.Hand.ClearHand());
            _players.ToList().ForEach(p => p.Hand.AddCards(_deck.GetCards(10)));
        }

        private class PlayerMove : IPlayerMove
        {
            public IPlayer Player { get; set; }
            public ICard CardPlayed { get; set; }
            public long NewScore { get; set; }
        }
    }
}
