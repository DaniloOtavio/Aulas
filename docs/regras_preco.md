# DOCUMENTAÇÃO DAS REGRAS DE PREÇO


* Não será permitido para um produto/ serviço possuir um lucro negativo. Será retornado zero caso o preço de venda seja zero ou inferior ao preço de custo.
    
    * Função: CalculaLucro

```c#
    public static decimal CalculaLucro(decimal pc, decimal pv)
        {
            if (pv == 0) { return 0; }
            if (pv < pc) { return 0; }

            decimal LC = pv - pc;

            return LC;
        }
