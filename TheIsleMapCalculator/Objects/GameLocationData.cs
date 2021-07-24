using System;
using System.Globalization;

namespace TheIsleMapCalculator.Objects
{
    /// <summary>
    /// Class containing position data from the game.
    /// </summary>
    public class GameLocationData
    {
        /// <summary>
        /// The raw X value retrieved from the game input.
        /// </summary>
        public float RawX { get; private set; }
        /// <summary>
        /// The raw Y value retrieved from the game input.
        /// </summary>
        public float RawY { get; private set; }
        /// <summary>
        /// The raw Z value retrieved from the game input.
        /// </summary>
        public float RawZ { get; private set; }

        /// <summary>
        /// Returns the raw X value divided by 1000; used for calculations.
        /// </summary>
        public float X
        {
            get
            {
                return RawX / 1000;
            }
        }
        /// <summary>
        /// Returns the raw Y value divided by 1000; used for calculations.
        /// </summary>
        public float Y
        {
            get
            {
                return RawY / 1000;
            }
        }
        /// <summary>
        /// Returns the raw Z value divided by 1000; used for calculations.
        /// </summary>
        public float Z
        {
            get
            {
                return RawZ / 1000;
            }
        }

        private CultureInfo _ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="input">Raw location data from the game.</param>
        public GameLocationData(string input)
        {
            string[] positions = input.Split(' ');
            if (positions.Length != 3)
                throw new ArgumentException("The input string is not valid.");

            _ci.NumberFormat.CurrencyDecimalSeparator = ".";

            foreach (var p in positions)
            {
                string[] coords = p.Split('=');
                if (coords.Length != 2)
                    throw new ArgumentException("One or more of the coordinates strings were not valid.");
                float coord = float.Parse(coords[1], NumberStyles.Any, _ci);
                switch (coords[0].Trim().ToUpper())
                {
                    case "X":
                        RawX = coord;
                        break;
                    case "Y":
                        RawY = coord;
                        break;
                    case "Z":
                        RawZ = coord;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"X={RawX.ToString(_ci)} Y={RawY.ToString(_ci)} Z={RawZ.ToString(_ci)}";
        }
    }
}
