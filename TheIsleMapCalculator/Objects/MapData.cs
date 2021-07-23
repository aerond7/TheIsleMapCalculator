using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using TheIsleMapCalculator.Enums;

namespace TheIsleMapCalculator.Objects
{
    /// <summary>
    /// Class containing map data.
    /// </summary>
    public class MapData
    {
        /// <summary>
        /// The map that this instance is representing.
        /// </summary>
        public Map Map { get; private set; }
        /// <summary>
        /// The center of the map.
        /// </summary>
        public Point Center { get; private set; }
        /// <summary>
        /// The size of the map.
        /// </summary>
        public Point Size { get; private set; }
        /// <summary>
        /// The base multiplier for calculations.
        /// </summary>
        public float Multiplier { get; private set; }
        /// <summary>
        /// Multiplier that's intended to be used if the position X value is more than 0.
        /// </summary>
        public float LongtitudeMoreThanZeroMultiplier { get; private set; }
        /// <summary>
        /// Multiplier that's intended to be used if the position X value is less than 0.
        /// </summary>
        public float LongtitudeLessThanZeroMultiplier { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="map">The map that this constructor should apply to the instance.</param>
        public MapData(Map map)
        {
            switch (map)
            {
                case Map.IsleV3:
                    Center = new Point(1013, 857);
                    Size = new Point(1920, 1920);
                    Multiplier = 1.2f;
                    LongtitudeMoreThanZeroMultiplier = Multiplier;
                    LongtitudeLessThanZeroMultiplier = Multiplier;
                    break;

                case Map.ThenyawIsland:
                    Center = new Point(543, 492);
                    Size = new Point(1000, 1000);
                    Multiplier = 1.28f;
                    LongtitudeMoreThanZeroMultiplier = Multiplier;
                    LongtitudeLessThanZeroMultiplier = 1.26f;
                    break;

                default:
                    throw new ArgumentException("The provided map is not implemented.");
            }
        }
    }
}
