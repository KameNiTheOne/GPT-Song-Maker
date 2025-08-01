namespace GPTSMShared
{
    public class Prompt : IRetrievable
    {
        public Prompt(string promptTitle, string lyrics, string styles, string title)
        {
            PromptTitle = string.IsNullOrEmpty(promptTitle) ? Id.ToString() : promptTitle;
            Lyrics = lyrics;
            Styles = styles;
            Title = title;
        }
        public int Id { get; set; }
        public string? PromptTitle { get; set; }
        public string? Lyrics { get; set; }
        public string? Styles { get; set; }
        public string? Title { get; set; }
        public DBType Type { get { return DBType.Prompt; } }
        public string EmbedQueryIntoStyles(string query)
        {
            return Styles.Replace("<<QUERY>>", query);
        }
        public string EmbedQueryAndStylesIntoLyrics(string query, string styles)
        {
            return Lyrics.Replace("<<QUERY>>", query).Replace("<<STYLES>>", styles);
        }
        public string EmbedQueryIntoTitle(string query)
        {
            return Title.Replace("<<QUERY>>", query);
        }
        public void Change(Prompt prompt)
        {
            PromptTitle = prompt.PromptTitle;
            Lyrics = prompt.Lyrics;
            Styles = prompt.Styles;
            Title = prompt.Title;
        }

        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(Lyrics))
            {
                errorMessage = "Invalid Lyrics prompt";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Styles))
            {
                errorMessage = "Invalid Styles prompt";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Title))
            {
                errorMessage = "Invalid Title prompt";
                return false;
            }
            errorMessage = "";
            return true;
        }
    }
}
