namespace ArticleBuilder
{
    public class ArticleBuilder : IArticleBuilder
    {
        private Article _article;

        public ArticleBuilder()
        {
            _article = new Article();
        }

        public void SetTitle(string title)
        {
            _article.Title = title;
        }

        public void AddAuthor(string author)
        {
            _article.Authors.Add(author);
        }

        public void SetContent(string content)
        {
            _article.Content = content;
        }

        public void SetHashCode(string hashCode)
        {
            _article.HashCode = hashCode;
        }

        public Article GetArticle()
        {
            return _article;
        }
    }
}
