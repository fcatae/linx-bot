using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace LinxBot
{
    public interface IQuestionRepository
    {

    }

    public class QuestionRepository : IQuestionRepository
    {
        private string _connectionString;
        private SqlConnection _connection;

        public QuestionRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this._connection = new SqlConnection(connectionString);
        }        

        public int Save(Question question)
        {
            string insertCommand = "insert tbQuestions(ArticleId,[Text], [Tags]) values (@ArticleId,@Text, @Tags); select scope_identity()";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ret = connection.ExecuteScalar<int>(insertCommand, new { question.ArticleId, question.Text, question.Tags });

                return ret;
            }
        }

        public void Truncate()
        {
            _connection.ExecuteScalar("truncate table tbQuestions");
        }

        public IEnumerable<Article> FindQuestion(string[] keywords)
        {
            string query = "declare @s nvarchar(100) = @search; select * from tbArticles where Id in (select ArticleId from fnFindQuestions(@s))";
            string search = String.Join(" AND ", keywords);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var ret = connection.Query<Article>(query, new { search });

                return ret;
            }
        }

    }
}
