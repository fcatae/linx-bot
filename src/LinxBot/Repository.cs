using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace LinxBot
{
    public class Repository
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
            string insertCommand = "insert tbArticles(Title,Link,Content,PostType) values (@Title,@Link,@Content,@PostType); select scope_identity()";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ret = connection.ExecuteScalar<int>(insertCommand, new { article.Title, article.Link, article.Content, article.PostType });

                return ret;
            }
        }
    }
}
