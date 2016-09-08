
# V3. Identificação de domínio

A triage inicial busca identificar qual o domínio da pergunta. 

    O processo inicia com uma busca sobre as perguntas. Caso encontre muitos 
    resultados, então é iniciada a triage da pergunta.

* Website 
    * Hotsite
    * Header | Footer
    * Vitrine
    * Avançado
* Pagamento
* Newsletter

Portanto, se perguntarmos algo muito específico:

```
    Como adicionar bibliotecas javascript?
```

Podemos não ter uma resposta muito precisa sobre a dúvida.


# v3.1

Ao invés de retornar uma pergunta genérica, podemos inferir a categoria em
alguns casos. Detectamos a palavra javascript e rotulamos como avançada. O mesmo poderia
valer para C# ou Meta-tags. Nesse caso, arriscamos uma categoria:

```
    if( texto.Contains("javascript") ) {
        category = "avançado";
    }
```

Assim, temos uma resposta do bot para definir o domínio de busca automaticamente.

```
    Você está buscando sobre Website avançado (programação)?
```

# v3.2

Esse é um problema de classificação de documento.

O treinamento é feito usando o LUIS, usando identificadores de entidades para
ajudar a identificar a categoria correspondente. Ao invés de cadastrarmos
manualmente em código, usamos a interface do LUIS para determinar qual a 
categoria.


