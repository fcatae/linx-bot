# V0 - O Problema

Algoritmo de search com base no conteúdo

Exemplo: busca por configuração de template do site.

```
    Como mudar o template da página? 
```

Nesse caso, 

```
    (Nenhuma resposta)
```

Poderia fazer perguntas semelhantes:
 * Como customizar a página inicial?
 * Como usar templates HTML?
 * Como mudar a página do hotsite?

```
    (Nenhuma resposta)
```

## v0.1

Nenhuma delas retorna uma resposta. Por isso, somos obrigados a usar 
o site como um buscador.  Isso força o usuário a fazer pesquisa de 
palavra ao invés de perguntas. 

Imagine o atendimento nível 1 - ele deve traduzir a pergunta do usuário em palavras.
Isso força a perda do contexto original da pergunta.

```
    template
```

O retorno é:

```
    E-mails automáticos
    http://linxb2chelp.azurewebsites.net/knowledgebase/e-mails-automaticos/
```

## v0.2

Podemos refinar a busca usando múltiplas palavras:

```
    template página
```

As palavras não retornam resultados:

```
    (Nenhuma resposta)
```

Posso usar palavras semelhantes:

```
    template html
```

Voltamos à resposta inicial.

```
    E-mails automáticos
    http://linxb2chelp.azurewebsites.net/knowledgebase/e-mails-automaticos/
```

Enquanto que a resposta correta seria:

    http://linxb2chelp.azurewebsites.net/knowledgebase/hotsite/


SQL
====

```
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

select * from FREETEXTTABLE(tbArticles, content, 'template and html') ORDER BY RANK DESC
```