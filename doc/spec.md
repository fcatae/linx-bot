Esse é um problema de classificação.

# V0. O Problema

Algoritmo de search com base no conteúdo nem sempre retorna o resultado desejado.

    Busca textual.


# V1. Preparação do Conteúdo

A geração de conteúdo é espontânea, enquanto que as perguntas podem ser criadas 
de acordo com sua frequência.

    O processo é fazer uma busca sobre as perguntas. Caso não encontre, então faz 
    o fallback para o processo de busca textual.

As informações são organizadas no formato de pergunta:

```
    link: http://linxb2chelp.azurewebsites.net/knowledgebase/hotsite/
    pergunta: Como criar um template html?
```


# V2. Organização em diretório

As perguntas (e os artigos?) podem ser agrupadas por assunto, criando uma
estrutura de diretório.

    O processo é fazer uma busca sobre as perguntas. Caso não encontre, então faz 
    perguntas sobre qual o diretório e depois realiza o processo de busca textual.

O diretório é organiazado por tópicos:

* Website 
    * Hotsite
    * Header | Footer
    * Vitrine
    * Avançado
* Pagamento
* Newsletter

Cadastramos categorias:

```
    link: category://website
    pergunta: como mudar a tela?
```

Bot responde:

```
    Você está buscando sobre Website. O que deseja saber?
```

Fazemos um tratamento específico para quando não há resposta.

```
    Você está buscando sobre Website, Pagamento ou Newsletter?
```

Resposta:

```
    busca em: Newsletter
```

Bot responde:

```
    Você está buscando sobre Newsletter. O que deseja saber?
```

A conversa segue... "como criar template"?


# V3. Identificação de domínio

A triage inicial busca identificar qual o domínio da pergunta. 

    O processo inicia com uma busca sobre as perguntas. Caso encontre muitos 
    resultados, então é iniciada a triage da pergunta.

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