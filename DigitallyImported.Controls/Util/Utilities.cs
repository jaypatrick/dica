using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// Static utility methods
    /// </summary>
    public static class Utilities
    {
        //public static string SplitName(string name)
        //{
        //    char[] buffer = name.ToCharArray();
        //    foreach (char c in buffer)
        //    {
        //        if (char.IsUpper(c))
        //        {
        //            name = name.Replace(c.ToString(), " " + c.ToString());
        //        }
        //    }
        //    return name.Trim();
        //}
        /// <summary>
        /// Splits a string up based on capital letters, i.e. ThisString becomes This String
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="items"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static string Join<T>(string delimiter
                                     , IEnumerable<T> items
                                     , Converter<T, string> converter)
        {
            var builder = new StringBuilder();
            foreach (T site in items)
            {
                builder.Append(site);
                builder.Append(delimiter);
            }
            if (builder.Length > 0)
                builder.Length = builder.Length - delimiter.Length;

            return builder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediaType"></param>
        /// <param name="siteName"></param>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static Uri GetChannelUri(StreamType mediaType, string siteName, string channelName)
        {
            Uri channelUri = null;

            switch (mediaType)
            {
                case StreamType.AacPlus:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", siteName, Resources.MediaTypeAacPlus, 
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName, Resources.Properties.Resources.MediaTypeAacPlus);

                        break;
                    }
                case StreamType.Mp3:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", siteName, Resources.MediaTypeMp3,
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName, Resources.Properties.Resources.MediaTypeMp3);

                        break;
                    }
                case StreamType.Wma:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", siteName, Resources.MediaTypeWma,
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName, Resources.Properties.Resources.MediaTypeWma);

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
        /// 
        /// </summary>
        /// <param name="mediaType"></param>
        /// <param name="siteName"></param>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static Uri GetPremiumChannelUri(StreamType mediaType, string siteName, string channelName)
        {
            Uri channelUri = null;

            switch (mediaType)
            {
                case StreamType.Aac:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", siteName, Resources.MediaTypePremiumAac,
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName, Resources.Properties.Resources.MediaTypePremiumAac);

                        break;
                    }
                case StreamType.AacPlus:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", siteName, Resources.MediaTypePremiumAacPlus,
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName,
                                                       Resources.Properties.Resources.MediaTypePremiumAacPlus);

                        break;
                    }
                case StreamType.Mp3:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", siteName, Resources.MediaTypePremiumMp3,
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName, Resources.Properties.Resources.MediaTypePremiumMp3);

                        break;
                    }
                case StreamType.Wma:
                    {
                        //channelUri = new Uri(string.Format("{0}{1}{2}", Resources.MediaTypePremiumWma,
                        //    channelName.Replace(" ", "").Trim().ToLower()));

                        channelUri = FormatChannelInfo(channelName, Resources.Properties.Resources.MediaTypePremiumWma);

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return channelUri;
        }

        internal static Uri FormatChannelInfo(string channelName, string mediaType)
        {
            return new Uri(string.Format("{0}{1}", mediaType, channelName.Replace(" ", "").Trim().ToLower()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="playlistTypes"></param>
        /// <returns></returns>
        public static T GetPlaylistTypes<T>(StringCollection playlistTypes)
            where T : struct
        {
            var sb = new StringBuilder();
            StringCollection sc = playlistTypes;

            foreach (string s in sc)
            {
                sb.AppendFormat("{0}{1}", s, ",");
            }

            return ParseEnum<T>(sb.ToString().TrimEnd(','));

            // return (T)Enum.Parse(typeof(T), sb.ToString().TrimEnd(','), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
            where T : struct
        {
            return (T) Enum.Parse(typeof (T), value, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playlistTypes"></param>
        /// <returns></returns>
        public static StringCollection GetSiteStrings(StationType playlistTypes)
        {
            //StringCollection col = new StringCollection();
            //foreach (string site in Enum.GetName(typeof(PlaylistType), site)
            //{
            //    col.Add(site);
            //}
            //return col;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toEncode"></param>
        /// <returns></returns>
        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Splits a string up based on capital letters, i.e. ThisString becomes This String
        /// </summary>
        /// <param name="name">The string to split</param>
        /// <returns></returns>
        public static string SplitName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name", Resources.Properties.Resources.StringNull);
            int spaces = 0;

            char[] buffer = name.ToCharArray();

            //foreach (char c in buffer)
            //{
            //    if (char.IsUpper(c) && !char.IsUpper(buffer[i+1]))
            //    {
            //        name = name.Replace(c.ToString(), " " + c.ToString());
            //    }
            //    i++;
            //}

            //return name.Trim().Replace("  ", " ");

            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                char d = ' ';

                if (buffer.Length > i + 1)
                {
                    d = buffer[i + 1];
                }

                if (char.IsUpper(c) && char.IsUpper(d)) continue;


                if (char.IsUpper(d))
                {
                    if (i == 0) continue;

                    name = name.Insert(i + 1 + spaces, " ");
                    spaces++;
                }

                if (char.IsUpper(c) && char.IsLower(d))
                {
                    if (i == 0) continue;

                    if (name[i] == ' ') continue;

                    name = name.Insert(i + spaces, " ");
                    spaces++;
                }
            }

            return name.Trim(); //.Replace("  ", " ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CapitalizeFirstLetters(string name)
        {
            if (name == null) throw new ArgumentNullException("name", Resources.Properties.Resources.StringNull);

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower().Trim());
        }

        /// <summary>
        /// Starts a process based on the file extension of the string passed in
        /// </summary>
        /// <param name="processToStart">The name of the process to start</param>
        public static void StartProcess(string processToStart)
        {
            //if (processToStart == null) throw new ArgumentNullException("processToStart", DigitallyImported.Resources.Properties.Resources.ProcessToStartNull);

            if (!string.IsNullOrEmpty(processToStart))
            {
                var info = new ProcessStartInfo(processToStart.Trim());
                StartProcess(info);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processToStart"></param>
        public static void StartProcess(ProcessStartInfo processToStart)
        {
            if (processToStart == null)
                throw new ArgumentNullException("processToStart", Resources.Properties.Resources.ProcessToStartNull);

            var thread = new Thread(() => Process.Start(processToStart));

            thread.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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