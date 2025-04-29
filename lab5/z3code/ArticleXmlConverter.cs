using System;
using System.IO;
using System.Text;
using System.Xml;

namespace ArticleBuilder
{
    public class ArticleXmlConverter
    {
        public string ConvertToXml(Article article)
        {
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Article");

                writer.WriteElementString("Title", article.Title);

                writer.WriteStartElement("Authors");
                foreach (var author in article.Authors)
                {
                    writer.WriteElementString("Author", author);
                }
                writer.WriteEndElement();

                writer.WriteElementString("Content", article.Content);
                writer.WriteElementString("HashCode", article.HashCode);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            return sb.ToString();
        }

        public bool ValidateHashCode(Article article)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(article.Content);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                string computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return computedHash == article.HashCode.ToLower();
            }
        }
    }
}
