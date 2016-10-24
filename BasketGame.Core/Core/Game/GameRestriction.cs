using System;

namespace BasketGame.Core.Game
{
    /// <summary>
    /// Contains all game restrictions
    /// </summary>
    public class GameRestriction
    {
        public readonly int MinPlayers;

        public readonly int MaxPlayers;

        public readonly int MinWeight;

        public readonly int MaxWeight;

        public readonly int MaxAttempts;

        public readonly int MaxMilliseconds;

        public GameRestriction(uint minPlayers, uint maxPlayers, uint minWeight, uint maxWeight, uint maxAttempts, uint maxMilliseconds)
        {
            if (minPlayers > maxPlayers)
            {
                throw new ArgumentException("Minimum players number must be equal or less than maximum", "minWeight");
            }
            MinPlayers = (int)minPlayers;
            MaxPlayers = (int)maxPlayers;

            if (minWeight >= maxWeight)
            {
                throw new ArgumentException("Minimum weight must be less than maximum", "minPlayers");
            }
            MinWeight = (int)minWeight;
            MaxWeight = (int)maxWeight;

            MaxAttempts = (int)maxAttempts;
            MaxMilliseconds = (int)maxMilliseconds;
        }
    }
}