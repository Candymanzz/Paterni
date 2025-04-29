namespace ArticleBuilder
{
    public interface IArticleBuilder
    {
        void SetTitle(string title);
        void AddAuthor(string author);
        void SetContent(string content);
        void SetHashCode(string hashCode);
        Article GetArticle();
    }
}
