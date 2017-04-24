CREATE FUNCTION [dbo].[fnProdutoDuracao]
(
	@produto	int,
	@quantidade	numeric(12,4)
)
RETURNS INT
AS
BEGIN
	DECLARE @duracao numeric(12,4);

	SELECT
		@duracao = CASE u.grandeza when 'T' THEN p.quantidade / u.fator * @quantidade ELSE 0 END

	FROM
		dbo.produto AS p
			INNER JOIN unidades_medida AS u ON u.codigo = p.unidade_medida

	WHERE
		p.codigo = @produto;

	RETURN @duracao;
END
