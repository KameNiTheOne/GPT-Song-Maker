namespace GPTSMShared
{
    public class Song : IRetrievable
    {
        public Song(string title, string lyrics, string styles)
        {
            Title = title;
            Lyrics = lyrics;
            Styles = styles;
        }
        public DBType Type { get { return DBType.Song; } }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Lyrics { get; set; }
        public string? Styles { get; set; }
        public void Change(Song song)
        {
            Title = song.Title;
            Lyrics = song.Lyrics;
            Styles = song.Styles;
        }
        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(Lyrics))
            {
                errorMessage = "Invalid Lyrics";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Styles))
            {
                errorMessage = "Invalid Styles";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Title))
            {
                errorMessage = "Invalid Title";
                return false;
            }
            errorMessage = "";
            return true;
        }
    }
}
