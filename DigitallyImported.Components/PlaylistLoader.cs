#region using declarations

using System;

#endregion

namespace DigitallyImported.Components
{
    public class PlaylistLoader<T> : ContentLoader<T>
        where T : IPlaylist, new()
    {
        private T _playlist;
        private T[] _playlistArray;
        private PlaylistCollection<T> _playlists;

        /// <summary>
        /// </summary>
        /// <param name="bypassCache"> </param>
        /// <returns> </returns>
        public virtual PlaylistCollection<T> LoadSites(bool bypassCache)
        {
            var playlists = new PlaylistCollection<T>();

            if (_playlists != null)
                _playlists.ForEach(playlists.Add);

            if ((bypassCache) || (playlists.Count == 0))
            {
                _playlists = new PlaylistCollection<T>();
            }

            _playlistArray = new T[Enum.GetNames(typeof (StationType)).Length];
            int i = 0;

            foreach (string playlist in Enum.GetNames(typeof (StationType)))
            {
                _playlist = playlists.Contains(playlists[playlist]) ? playlists[playlist] : new T();

                _playlist.Name = playlist;
                // _playlist.PlaylistIcon

                _playlistArray[i] = _playlist;
                i++;
            }

            playlists.Clear();
            playlists.AddRange(_playlistArray);

            if (_playlists != null)
            {
                _playlists.Clear();
                playlists.Clone(_playlists);

                return _playlists;
            }

            // create SiteDictionary loaded w/ channels and events per site, create tabbed control in main form
            // foreach site, i.e. DI, Sky, WFAE, etc...bind per tab. pass in PlaylistType to ctor.
            return null;
        }
    }
}