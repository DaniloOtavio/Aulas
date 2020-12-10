# DOCUMENTAÇÃO DAS REGRAS DE PREÇO

## Preço de Custo

* Ao ser informado um preço de custo maior que o preço de venda, a margem de lucro será zerada.
---

## Preço de Venda
* Ao ser informado um preço de venda menor que o preço de custo a margem de lucro será zerada.
* Ao ser informado um preço de venda zero serão retornados markup e margens de lucro zeradas.
* Cálculo do Preço de venda poderá ser feito aplicando a margem de lucro, markup ou inserindo manualmente.

---

## Lucro

* Não será permitido para um produto/ serviço possuir um lucro negativo. Será retornado zero caso o preço de venda seja zero ou inferior ao preço de custo.
* Cálculo de Lucro: Preço de Custo - Preço de Venda

---

## Margem de Lucro

* Ao ser informado um preço de custo zero e preço de venda maior que zero, a margem de lucro automaticamente será de 100%.
* Cálculo de Margem de Lucro: Lucro / Receita

---

## Markup
* Ao ser informado um preço de custo ou venda zerado, o markup será igualmente zero.
* Cálculo de Markup: 100/[100 - Preço de Custo]