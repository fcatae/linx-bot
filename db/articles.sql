create database linx_bot

use linx_bot

create table tbArticles(
	Id INT CONSTRAINT PK_Articles PRIMARY KEY IDENTITY,
	Title VARCHAR(200),
	Link VARCHAR(200),
	Content VARCHAR(max),
	PostType VARCHAR(20),
	Tags VARCHAR(1000)
)

CREATE FULLTEXT CATALOG ft_search AS DEFAULT
CREATE FULLTEXT INDEX ON tbArticles(Content) KEY INDEX PK_Articles;

select * from tbArticles where posttype='st_kb' and freetext(content, 'template and html')
select * from tbArticles where posttype='st_kb' and contains(content, 'javascript')

declare @s varchar(100) = 'template and html'
select * from tbArticles where posttype='st_kb' and freetext(content, @s)
select * from FREETEXTTABLE(tbArticles, content, @s) ORDER BY RANK DESC

--------------

create table tbQuestions(
	Id INT CONSTRAINT PK_Questions PRIMARY KEY IDENTITY,
	ArticleId INT,
	Text VARCHAR(200),
	Tags VARCHAR(1000)
)

CREATE FULLTEXT INDEX ON tbQuestions(Text) KEY INDEX PK_Questions;

