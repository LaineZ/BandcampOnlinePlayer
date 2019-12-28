using System;
using System.Collections.Generic;

namespace onlineplayer
{

    public class Album
    {

        /// <summary>
        /// The album artist.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// The local path (full path with file name) where the artwork file should be saved.
        /// </summary>
        public string ArtworkPath { get; private set; }

        /// <summary>
        /// The local path (full path with file name) to the %TEMP% folder where the artwork file should be saved.
        /// </summary>
        public string ArtworkTempPath { get; private set; }

        /// <summary>
        /// The URL where the artwork should be downloaded from.
        /// </summary>
        public string ArtworkUrl { get; set; }

        public string ArtworkId { get; set; }

        /// <summary>
        /// True if the album has an artwork; false otherwise.
        /// </summary>
        public bool HasArtwork
        {
            get
            {
                return ArtworkUrl != null;
            }
        }

        /// <summary>
        /// The local path (full path) to the folder where the album should be saved.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// The local path (full path with file name) where the playlist file should be saved.
        /// </summary>
        public string PlaylistPath { get; private set; }

        /// <summary>
        /// The release date of the album.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// The album title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The list of tracks contained in the album.
        /// </summary>
        public List<Track> Tracks { get; set; }

        /// <summary>
        /// Initializes a new Album.
        /// </summary>
        public Album(string artist, string artworkUrl, DateTime releaseDate, string title, string artid)
        {
            Artist = artist;
            ArtworkUrl = artworkUrl;
            ArtworkId = artid;
            ReleaseDate = releaseDate;
            Title = title;
        }
    }
}