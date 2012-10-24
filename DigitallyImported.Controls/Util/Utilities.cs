#region using declarations

using System;
using System.Collections.Specialized;
using System.Text;

#endregion

namespace DigitallyImported.Controls
{
    /// <summary>
    ///   Static utility methods
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="playlistTypes"> </param>
        /// <returns> </returns>
        public static T GetPlaylistTypes<T>(StringCollection playlistTypes)
            where T : struct
        {
            var sb = new StringBuilder();
            var sc = playlistTypes;

            foreach (var s in sc)
            {
                sb.AppendFormat("{0}{1}", s, ",");
            }

            return ParseEnum<T>(sb.ToString().TrimEnd(','));

            // return (T)Enum.Parse(typeof(T), sb.ToString().TrimEnd(','), true);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="value"> </param>
        /// <returns> </returns>
        public static T ParseEnum<T>(string value)
            where T : struct
        {
            return (T) Enum.Parse(typeof (T), value, true);
        }
    }
}