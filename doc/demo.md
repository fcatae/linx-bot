Esse é um problema de classificação.

# Definindo o Problema

## Primeiras dúvidas

No site de busca, começamos procurando por como personalizar o site inicial:

    Como mudar o template da página? 

Essa pergunta não retorna registro. Podemos fazer perguntas semelhantes:

    Como customizar a página inicial?
    Como usar templates HTML?
    Como mudar a página do hotsite?

## Usando busca por palavras

Vamos reduzir a busca a apenas palavras.

    Template

O retorno é um artigo sobre emails automáticos, que não é o objetivo. Podemos 
refinar a busca usando:

    template página
    template html

As respostas não atendem ao desejo inicial.


# Normalização do Conteúdo

## Apresentação do Bot

Vamos começar fazendo as perguntas ao bot:

    Ola!
    Como criar um template html?

O retorno é igual ao anterior.

## Normalização de Dados

Uma equipe de suporte deve normalizar as informações cadastradas no banco de dados.

    link: http://linxb2chelp.azurewebsites.net/knowledgebase/hotsite/
    pergunta: Como criar um template html?

A partir de agora, iniciamos o teste no bot:

    Como criar um template html?

O retorno está correto.    


# Organização em Categoria

Apenas adicionar perguntas não resolve o problema geral.
Existem perguntas que são genéricas/específicas e não podem ser respondidas.

    Como mudar a tela?
    Como adicionar bibliotecas javascript?

Como resolver esse problema?

As perguntas (e os artigos?) podem ser agrupadas por assunto, criando uma
estrutura de diretório. O diretório é organiazado por tópicos:

* Website 
    * Hotsite
    * Header | Footer
    * Vitrine
    * Avançado
* Pagamento
* Newsletter

Portanto, perguntas genéricas podem ser respondidas com uma outra pergunta.

    Oi?

``` 
    Você está buscando sobre Website, Pagamento ou Newsletter? 
```

    busca em: Website

Da mesma forma, podemos responder perguntas genéricas com mais perguntas: 

    link: category://website
    pergunta: como mudar a tela?


Bot responde:

```
    Você está buscando sobre Website. O que deseja saber?
```



# Identificação de Categoria

A triage inicial busca identificar qual o domínio da pergunta. 

Assim, temos um código customizado para tratamento de domínios:

```
    if( texto.Contains("javascript") ) {
            category = "avançado";
        }
```

Logo o bot retorna:

```
    Você está buscando sobre Website avançado (programação). O que deseja saber?
```

Em seguida, podemos refinar o código usando o LUIS.

O treinamento é feito usando o LUIS, usando intenção = tag e identificadores de
entidades.