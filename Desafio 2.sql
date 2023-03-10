select p.nome, 'Contas Pagas' as Origem, cPagas.*, cPagas.valor + cPagas.acrescimo - cPagas.desconto as Vlr_Liquido
from Pessoas p
INNER JOIN ContasPagas cPagas ON cPagas.codigoFornecedor = p.codigo

UNION

select p.nome, 'Contas a Pagar' as Origem, cPagar.*, cPagar.valor + cPagar.acrescimo - cPagar.desconto as Vlr_Liquido
from Pessoas p
INNER JOIN ContasAPagar cPagar ON cPagar.codigoFornecedor = p.codigo
