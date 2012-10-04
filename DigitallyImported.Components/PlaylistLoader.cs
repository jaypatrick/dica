using System;

namespace DigitallyImported.Components
{
    public class PlaylistLoader<T> : ContentLoader<T> 
        where T: IPlaylist, new()
    {
        private PlaylistTypes _playlistType;
        private T _playlist = default(T);
        private T[] _playlistArray = null;
        private PlaylistCollection<T> _playlists = null;

        /// <summary>
        /// 
        /// </summary>
        public PlaylistLoader() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bypassCache"></param>
        /// <returns></returns>
        public virtual PlaylistCollection<T> LoadSites(bool bypassCache)
        {
            var playlists = new PlaylistCollection<T>();

            if (_playlists != null)
                _playlists.ForEach(t =>
            {
                playlists.Add(t);
            });

            if ((bypassCache) || (playlists.Count == 0))
            {
                _playlists = new PlaylistCollection<T>();
            }

            _playlistArray = new T[Enum.GetNames(typeof(PlaylistTypes)).Length];
            int i = 0;

            foreach (var playlist in Enum.GetNames(typeof(PlaylistTypes)))
            {
                if (playlists.Contains(playlists[playlist]))
                {
                    _playlist = playlists[playlist];
                }
                else
                {
                    _playlist = new T();
                }

                _playlist.Name = playlist;
                // _playlist.PlaylistIcon

                _playlistArray[i] = _playlist;
                i++;
            }

            playlists.Clear();
            playlists.AddRange(_playlistArray);

            _playlists.Clear();
            playlists.Clone(_playlists);

            return _playlists;

            // create SiteDictionary loaded w/ channels and events per site, create tabbed control in main form
            // foreach site, i.e. DI, Sky, WFAE, etc...bind per tab. pass in PlaylistType to ctor.
        }
    }
}
