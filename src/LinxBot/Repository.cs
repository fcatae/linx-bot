using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace LinxBot
{
    public interface IRepository
    {
    }

    public class Repository : IRepository
    {
        private string _connectionString;
        private SqlConnection _connection;

        public Repository(string connectionString)
        {
            this._connectionString = connectionString;
            this._connection = new SqlConnection(connectionString);
        }

        public void Truncate()
        {
            _connection.ExecuteScalar("truncate table tbArticles");
        }

        public int Save(Article article)
        {
            string insertCommand = "insert tbArticles(Title,Link,Content,PostType,Tags) values (@Title,@Link,@Content,@PostType,@Tags); select scope_identity()";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ret = connection.ExecuteScalar<int>(insertCommand, new { article.Title, article.Link, article.Content, article.PostType, Tags = String.Join(",", article.Categories) });

                return ret;
            }
        }

        public IEnumerable<Article> FindArticle(string[] keywords)
        {
            string query = "select * from tbArticles where posttype='st_kb' and freetext(content, @search)";
            string search = String.Join(" AND ", keywords);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ret = connection.Query<Article>(query, new { search });

                return ret;
            }
        }

        public Article FindArticleByUrl(string url)
        {
            string query = "select * from tbArticles where link=@url";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ret = connection.Query<Article>(query, new { url }).FirstOrDefault();

                return ret;
            }
        }
    }
}
