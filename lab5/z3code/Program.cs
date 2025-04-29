using System;
using System.IO;

namespace ArticleBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Чтение текстового файла
                string[] lines = File.ReadAllLines("article.txt");

                // Создание строителя
                IArticleBuilder builder = new ArticleBuilder();

                // Парсинг файла и построение статьи
                builder.SetTitle(lines[0]);

                // Авторы находятся на второй строке, разделены запятыми
                string[] authors = lines[1].Split(',');
                foreach (var author in authors)
                {
                    builder.AddAuthor(author.Trim());
                }

                // Содержимое статьи
                string content = string.Join(Environment.NewLine, lines, 2, lines.Length - 3);
                builder.SetContent(content);

                // Хеш-код находится в последней строке
                builder.SetHashCode(lines[lines.Length - 1]);

                // Получение готовой статьи
                Article article = builder.GetArticle();

                // Конвертация в XML и проверка хеш-кода
                ArticleXmlConverter converter = new ArticleXmlConverter();

                if (converter.ValidateHashCode(article))
                {
                    string xml = converter.ConvertToXml(article);
                    File.WriteAllText("article.xml", xml);
                    Console.WriteLine("Статья успешно конвертирована в XML. Хеш-код верный.");
                }
                else
                {
                    Console.WriteLine("Ошибка: Хеш-код статьи не соответствует содержимому.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
