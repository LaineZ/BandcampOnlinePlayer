namespace onlineplayer
{

    public class Track
    {

        /// <summary>
        /// The track album.
        /// </summary>
        public Album Album { get; set; }

        /// <summary>
        /// The track length (in seconds).
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// The track lyrics.
        /// </summary>
        public string Lyrics { get; set; }

        /// <summary>
        /// The URL where the track should be downloaded from.
        /// </summary>
        public string Mp3Url { get; set; }

        /// <summary>
        /// The track number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The local path (full path with file name) where the track file should be saved.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// The track title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new Track.
        /// </summary>
        public Track(Album album, double duration, string lyrics, string mp3Url, int number, string title)
        {
            Album = album;
            Duration = duration;
            Lyrics = lyrics;
            Mp3Url = mp3Url;
            Number = number;
            Title = title;
        }
    }
}