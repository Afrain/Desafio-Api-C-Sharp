# Desafio-Api-C-Sharp CRUD 💻

Criação de uma aplicação web (API)

* EntityFrameworkCore
* EntityFrameworkCore.Design
* EntityFrameworkCore.SqlServer
* EntityFrameworkCore.Tools
* AspNetCore.Authentication
* AspNetCore.JwtBearer
* Swashbuckle.AspNetCore

![Swagger](https://user-images.githubusercontent.com/9250787/224204678-e1e0fc98-9bcf-4c7d-b21f-f037494e7ae1.jpeg)

# Segundo desafio 🖥️

Uma consulta que traga as informações de contas a pagar e contas pagas, sendo que ele precisa do número do processo
de pagamento, nome do fornecedor, data de vencimento, data de pagamento, valor líquido e
o um identificador se é conta a pagar ou paga.

![image](https://user-images.githubusercontent.com/9250787/224207909-4187597f-c448-4324-9f1a-2f181713369b.png)

### Query

SELECT p.nome, 'Contas Pagas' as Origem, cPagas.*, cPagas.valor + cPagas.acrescimo - cPagas.desconto as Vlr_Liquido  
FROM Pessoas p  
INNER JOIN ContasPagas cPagas ON cPagas.codigoFornecedor = p.codigo  
UNION  
SELECT p.nome, 'Contas a Pagar' as Origem, cPagar.*, cPagar.valor + cPagar.acrescimo - cPagar.desconto as Vlr_Liquido  
FROM Pessoas p  
INNER JOIN ContasAPagar cPagar ON cPagar.codigoFornecedor = p.codigo  

![image](https://user-images.githubusercontent.com/9250787/224207296-bcdd1794-d5fd-4dc2-abf3-847e9687a69e.png)
