# V2. Estruturação em diretório

Perguntas genéricas nem sempre podem ser respondidas. Por exemplo:

```
    Como mudar a tela?
```

O retorno podem ser várias respostas ou nenhuma. Ambos os casos, não conseguimos 
ser assertivos em relação à questão do usuário.

O objetivo do bot é realizar a triage inicial e determinar qual o produto/feature
que a pessoa está procurando. O mesmo se aplica em caso de problema, quando
precisamos isolar a causa do erro.

# v2.1

As perguntas (e os artigos?) podem ser agrupadas por assunto, criando uma
estrutura de diretório.

* Website 
    * Hotsite
    * Header | Footer
    * Vitrine
    * Avançado
* Pagamento
* Newsletter

Podemos ser mais assertivos cadastrando perguntas, reduzindo o número de respostas. 

```
    link: category://website
    pergunta: como mudar a tela?
```

O diálogo se torna:

```
    Como mudar a tela?
```

```
    Você está buscando sobre Website. O que deseja saber?
```


# v2.2

Quando não há uma resposta única, então o melhor caminho é voltar ao início com
uma pergunta genérica.

```
    Você está buscando sobre Website, Pagamento ou Newsletter?
```

Usuário responde com a sintaxe:

```
    busca em: Newsletter
```

Assim, a busca retoma o rumo.

```
    Você está buscando sobre Newsletter. O que deseja saber?
```
