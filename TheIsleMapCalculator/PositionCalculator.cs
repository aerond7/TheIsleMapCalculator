using System;
using System.Drawing;
using TheIsleMapCalculator.Enums;
using TheIsleMapCalculator.Objects;

namespace TheIsleMapCalculator
{
    /// <summary>
    /// Class to calculate game map position.
    /// </summary>
    public class PositionCalculator
    {
        /// <summary>
        /// The map data this instance is using.
        /// </summary>
        public MapData MapData { get; private set; }
        /// <summary>
        /// The conversion size this instance is using. If null, no conversion was specified.
        /// </summary>
        public Point? ConversionSize { get; private set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="map">The map, which this calculator is supposed to work with.</param>
        /// <param name="conversionSize">The size of the map that the results should work with, all input or output will be converted to match this size. If null, no conversion will happen.</param>
        public PositionCalculator(Map map, Point? conversionSize = null)
        {
            MapData = new MapData(map);
            ConversionSize = conversionSize;
        }

        /// <summary>
        /// Parses game location string to a GameLocationData object.
        /// </summary>
        /// <param name="gameLocation">The raw location string from the game.</param>
        /// <returns>Parsed game location object.</returns>
        public GameLocationData ParseGameLocation(string gameLocation)
        {
            var data = new GameLocationData(gameLocation);
            return data;
        }

        /// <summary>
        /// Calculates game position from game location data.
        /// </summary>
        /// <param name="gameData">The data the calculator should use.</param>
        /// <returns>Calculated (and converted, if defined) result of the position.</returns>
        public Point CalculateGameLocation(GameLocationData gameData)
        {
            // Calculate game position to location.
            float x = MapData.Center.X + gameData.X * (gameData.X < 0 ? MapData.LongtitudeLessThanZeroMultiplier : MapData.LongtitudeMoreThanZeroMultiplier);
            float y = MapData.Center.Y + gameData.Y * MapData.Multiplier;

            if (ConversionSize != null)
            {
                // If conversion is defined, convert values to desired size.
                float convertedX = ConversionSize.Value.X * x / MapData.Size.X;
                float convertedY = ConversionSize.Value.Y * y / MapData.Size.Y;

                x = convertedX;
                y = convertedY;
            }

            return new Point((int)Math.Floor(x), (int)Math.Floor(y));
        }
    }
}
