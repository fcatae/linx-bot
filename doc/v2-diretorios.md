# V2. Estruturação em diretório

Perguntas genéricas nem sempre podem ser respondidas. Por exemplo:

```
    Como mudar a tela?
```

As perguntas (não os artigos?) podem ser agrupadas por assunto, criando uma
estrutura de diretório.


* Portal Administrativo
  * GA
  * Executivo 
  * Desconto

* Website
  * Comentários | Facebook | Google
  * Gateway | Pagamento | Desconto | Clear Sales
  * Sitemap

* Customização
    * Novidades: Site V3.5
    * Customização UI
        * Hotsite
        * Busca
        * Header
            * Carrinho topo (js)
        * Footer 
            * Rodapes
        * Vitrine
            * CloudZoom (css) | Carrosel Fotos
            * razor
    * Site manutenção
    * Msgs de erro

    * Newsletter
        * Emails
        * Formulário de Newsletter
        * Newsletter (js)

    * Programação (Avançado)
        * Meta (html) - facebook
        * Chamada dinamica javascript
        * CSS Font
    
# v2.1

Com base na estrutura, podemos montar perguntas para o usuário.

- Você está buscando sobre... o Portal Administrativo?
- Você está buscando sobre... programação HTML, CSS, JS? 

A estrutura poderia ser simplificada:

* Website
    * Intro: Novidades | UI | Manutenção | Erro
    * Tela 
        * Hotsite 
        * Header | Footer
        * Vitrine
    * Avançado
* Pagamento
    * Gateway | Analytics | Desconto
* Newsletter

Ao responder a pergunta, podemos adicionar tags indiretas às perguntas.

Perguntas guiadas podem ajudar alguns cenários:

```
    Como adicionar bibliotecas javascript?
```

```
    arquivos dinamicos
```


# v2.2

O objetivo do bot é realizar a triage inicial e determinar qual o produto/feature
que a pessoa está procurando. O mesmo se aplica em caso de problema, quando
precisamos isolar a causa do erro.

* Website 
    * Hotsite
    * Header | Footer
    * Vitrine
    * Avançado
* Pagamento
* Newsletter

Usando um comando automatico para configurar as Tags relacionadas.