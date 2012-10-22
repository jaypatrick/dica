using System;
using System.Collections.Concurrent;
using DigitallyImported.Data;
using P = DigitallyImported.Resources.Properties;

namespace DigitallyImported.Components
{
    public class TrackLoader<TTrack> : ContentLoader<TTrack>
        where TTrack : class, ITrack, new()
    {
        private TTrack _track;
        private ConcurrentQueue<TTrack> _tracksQueue;

        /// <summary>
        /// 
        /// </summary>
        public TrackLoader()
        {
            _track = default(TTrack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tracks"></param>
        public TrackLoader(TrackCollection<TTrack> tracks)
        {
            _track = default(TTrack);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tracksRow"></param>
        /// <param name="bypassCache"></param>
        /// <param name="siteName"> </param>
        /// <param name="channel"> </param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public virtual TrackCollection<ITrack> LoadTracks(ChannelData.TRACKSRow tracksRow, bool bypassCache,
                                                          ref string siteName, IChannel channel)
        {
            // check if channel already has a tracks collection, if not create a blank one
            var tracks = new TrackCollection<ITrack>();

            if (channel.Tracks != null)
                tracks.AddRange(channel.Tracks.ToArray()); // add the existing array of tracks

            _tracksQueue = new ConcurrentQueue<TTrack>();

            // foreach (ChannelData.TRACKRow tr in tracksRow.GetTRACKRows()) _tracksQueue.Enqueue(tr as TTrack);


            // _tracksQueue = new ConcurrentQueue<TTrack>();


            foreach (ChannelData.TRACKRow trackRow in tracksRow.GetTRACKRows())
            {
                _track =
                    tracks.Find(
                        t =>
                        t.Name.Equals(trackRow.TRACKTITLE.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase))
                    as TTrack;

                // extract the site name from the forum url. the playlist doesn't have the site url in the schema
                if (!trackRow.IsTRACKURLNull())
                {
                    if (trackRow.TRACKURL.Contains(P.Resources.SkyHomePage))
                    {
                        siteName = string.Format(siteName, P.Resources.SkyHomePage);
                    }
                    if (trackRow.TRACKURL.Contains(P.Resources.DIHomePage))
                    {
                        siteName = string.Format(siteName, P.Resources.DIHomePage);
                    }
                }

                // track exists, update track info which is updateable...comment count is
                if (tracks.Contains(_track))
                {
                    if (_track != null) _track.CommentCount = int.Parse(trackRow.BOARDCOUNT);
                }
                else
                {
                    _track = new TTrack {ParentChannel = channel};

                    // load up the tracks collection for the channel
                    if (!trackRow.IsSTARTTIMENull())
                    {
                        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        _track.StartTime = epoch.AddSeconds(double.Parse(trackRow.STARTTIME)).ToLocalTime();
                    }
                    if (!trackRow.IsTRACKTITLENull())
                    {
                        _track.TrackTitle = trackRow.TRACKTITLE;
                    }

                    if (!trackRow.IsBOARDCOUNTNull())
                    {
                        _track.CommentCount = int.Parse(trackRow.BOARDCOUNT);
                    }

                    if (!trackRow.IsTRACKURLNull())
                    {
                        if (Uri.IsWellFormedUriString(trackRow.TRACKURL, UriKind.Absolute))
                        {
                            _track.ForumUrl = new Uri(trackRow.TRACKURL);
                        }
                    }

                    if (!trackRow.IsLABELNull())
                    {
                        _track.RecordLabel = trackRow.LABEL;
                    }

                    foreach (ChannelData.EXTRAURLRow extraUrlRow in trackRow.GetEXTRAURLRows())
                    {
                        if (!extraUrlRow.IsEXTRAURL_TextNull())
                        {
                            if (Uri.IsWellFormedUriString(extraUrlRow.EXTRAURL_Text, UriKind.Absolute))
                            {
                                _track.ArtistUri = new Uri(extraUrlRow.EXTRAURL_Text);
                            }
                        }
                    }

                    _tracksQueue.Enqueue(_track);
                }
            }

            if (_tracksQueue.Count > 0)
            {
                tracks.InsertRange(0, _tracksQueue.ToArray()); // insert the new tracks
                // tracks.HasNewTracks = true;
            }

            if (tracks.Count > tracksRow.GetTRACKRows().Length)
            {
                tracks.RemoveRange(tracksRow.GetTRACKRows().Length, tracks.Count - tracksRow.GetTRACKRows().Length);
            }

            return tracks;
        }
    }
}