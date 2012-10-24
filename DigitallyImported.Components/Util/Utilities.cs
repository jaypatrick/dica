#region using declarations

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DigitallyImported.Components
{
    /// <summary>
    ///   Static utility methods
    /// </summary>
    public static class Utilities
    {
        public static string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="value"> </param>
        /// <returns> </returns>
        public static T ParseEnum<T>(string value) where T : struct
        {
            return (T) Enum.Parse(typeof (T), value, true);
        }

        /// <summary>
        ///   Splits a string up based on capital letters, i.e. ThisString becomes This String
        /// </summary>
        /// <param name="name"> The string to split </param>
        /// <returns> </returns>
        public static string SplitName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name", Resources.Properties.Resources.StringNull);
            int numberOfSpaces = 0;
            const string space = " ";

            char[] buffer = name.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                char d = Char.MinValue;

                if (buffer.Length > i + 1)
                {
                    d = buffer[i + 1];
                }

                if (char.IsUpper(c) && char.IsUpper(d)) continue;


                if (char.IsUpper(d))
                {
                    if (i == 0) continue;

                    name = name.Insert(i + 1 + numberOfSpaces, space);
                    numberOfSpaces++;
                }

                if (char.IsUpper(c) && char.IsLower(d))
                {
                    if (i == 0) continue;

                    if (name[i] == ' ') continue;

                    name = name.Insert(i + numberOfSpaces, space);
                    numberOfSpaces++;
                }
            }

            return name.Trim(); //.Replace("  ", " ");
        }

        /// <summary>
        /// </summary>
        /// <param name="name"> </param>
        /// <returns> </returns>
        public static string CapitalizeFirstLetters(string name)
        {
            if (name == null) throw new ArgumentNullException("name", Resources.Properties.Resources.StringNull);

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower().Trim());
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="delimiter"> </param>
        /// <param name="items"> </param>
        /// <returns> </returns>
        public static string Join<T>(string delimiter
                                     , IEnumerable<T> items)
        {
            var builder = new StringBuilder();
            if (items != null)
                foreach (var site in items)
                {
                    builder.Append(site);
                    builder.Append(delimiter);
                }
            if (builder.Length > 0)
                builder.Length = builder.Length - delimiter.Length;

            return builder.ToString();
        }

        /// <summary>
        ///   Starts a process based on the file extension of the string passed in
        /// </summary>
        /// <param name="processToStart"> The name of the process to start </param>
        public static void StartProcess(string processToStart)
        {
            if (string.IsNullOrEmpty(processToStart)) return;
            var info = new ProcessStartInfo(processToStart.Trim());
            StartProcess(info);
        }

        /// <summary>
        /// </summary>
        /// <param name="processToStart"> </param>
        public static void StartProcess(ProcessStartInfo processToStart)
        {
            if (processToStart == null)
                throw new ArgumentNullException("processToStart", Resources.Properties.Resources.ProcessToStartNull);

            Parallel.Invoke(
                () => Process.Start(processToStart)
                );
        }

        /// <summary>
        /// </summary>
        /// <param name="mediaType"> </param>
        /// <param name="siteName"> </param>
        /// <param name="channelName"> </param>
        /// <returns> </returns>
        public static Uri GetChannelUri(StreamType mediaType, string siteName, string channelName)
        {
            if (string.IsNullOrEmpty(siteName))
                throw new ArgumentNullException("siteName", Resources.Properties.Resources.SitenameNull);
            if (string.IsNullOrEmpty(channelName))
                throw new ArgumentNullException("channelName", Resources.Properties.Resources.ChannelNameNull);

            Uri channelUri = null;

            switch (mediaType)
            {
                case StreamType.AacPlus:
                    {
                        channelUri = new Uri(string.Format(Resources.Properties.Resources.MediaTypeAacPlus, siteName,
                                                           channelName.Replace(" ", "").Trim().ToLower()));

                        break;
                    }
                case StreamType.Mp3:
                    {
                        channelUri = new Uri(string.Format(Resources.Properties.Resources.MediaTypeMp3, siteName,
                                                           channelName.Replace(" ", "").Trim().ToLower()));

                        break;
                    }
                case StreamType.Wma:
                    {
                        channelUri = new Uri(string.Format(Resources.Properties.Resources.MediaTypeWma, siteName,
                                                           channelName.Replace(" ", "").Trim().ToLower()));

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return channelUri;
        }

        /// <summary>
        /// </summary>
        /// <param name="mediaType"> </param>
        /// <param name="siteName"> </param>
        /// <param name="channelName"> </param>
        /// <param name="listenKey"> </param>
        /// <returns> </returns>
        public static Uri GetPremiumChannelUri(StreamType mediaType, string siteName, string channelName,
                                               string listenKey)
        {
            Uri channelUri = null;

            switch (mediaType)
            {
                case StreamType.Aac:
                    {
                        channelUri = new Uri(string.Format(Resources.Properties.Resources.MediaTypePremiumAac, siteName,
                                                           channelName.Replace(" ", "").Trim().ToLower(), listenKey));
                        break;
                    }
                case StreamType.AacPlus:
                    {
                        channelUri =
                            new Uri(string.Format(Resources.Properties.Resources.MediaTypePremiumAacPlus, siteName,
                                                  channelName.Replace(" ", "").Trim().ToLower(), listenKey));
                        break;
                    }
                case StreamType.Mp3:
                    {
                        channelUri = new Uri(string.Format(Resources.Properties.Resources.MediaTypePremiumMp3, siteName,
                                                           channelName.Replace(" ", "").Trim().ToLower(), listenKey));
                        break;
                    }
                case StreamType.Wma:
                    {
                        channelUri = new Uri(string.Format(Resources.Properties.Resources.MediaTypePremiumWma, siteName,
                                                           channelName.Replace(" ", "").Trim().ToLower(), listenKey));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return channelUri;
        }


        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static bool IsConnectedToInternet()
        {
            HttpWebResponse response;

            var request = (HttpWebRequest) WebRequest.Create(new Uri("http://www.google.com"));
            using (response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                throw new WebException(Resources.Properties.Resources.NetworkConnectionError
                                       , WebExceptionStatus.ConnectFailure);
            }
        }
    }
}