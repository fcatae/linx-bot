Esse é um problema de classificação.

# V0. O Problema

Algoritmo de search com base no conteúdo nem sempre retorna o resultado desejado.

    Busca textual.

# V1. Preparação do Conteúdo

A geração de conteúdo é espontânea, enquanto que as perguntas podem ser criadas 
de acordo com sua frequência.

    O processo é fazer uma busca sobre as perguntas. Caso não encontre, então faz 
    o fallback para o processo de busca textual.

# V2. Organização em diretório

As perguntas (e os artigos?) podem ser agrupadas por assunto, criando uma
estrutura de diretório.

    O processo é fazer uma busca sobre as perguntas. Caso não encontre, então faz 
    perguntas sobre qual o diretório e depois realiza o processo de busca textual.

# V3. Identificação de domínio

A triage inicial busca identificar qual o domínio da pergunta. Com base nas
informações obtidas, iniciamos o filtro sobre um diretório e procuramos as 
perguntas associadas. 

* Website 
    * Hotsite
    * Header | Footer
    * Vitrine
    * Avançado
* Pagamento
* Newsletter

O treinamento é feito usando o LUIS, usando intenção = tag e identificadores de
entidades.