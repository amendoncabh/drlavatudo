CREATE TABLE [dbo].[pedidos]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [cliente] INT NOT NULL, 
    [vendedor] INT NOT NULL, 
    [lista_preco] INT NOT NULL, 
    [registrado_em] SMALLDATETIME NOT NULL DEFAULT (GETDATE()), 
    [valido_ate] SMALLDATETIME NOT NULL DEFAULT (GETDATE()), 
    [comissao] DECIMAL(5, 2) NOT NULL DEFAULT (0), 
    [situacao] CHAR(1) NOT NULL DEFAULT ('0'), 
    CONSTRAINT [fk_pedidos_clientes] FOREIGN KEY ([cliente]) REFERENCES [clientes]([codigo]), 
    CONSTRAINT [fk_pedidos_vendedores] FOREIGN KEY ([vendedor]) REFERENCES [colaboradores]([codigo]), 
    CONSTRAINT [fk_pedidos_listas_preco] FOREIGN KEY ([lista_preco]) REFERENCES [listas_preco]([codigo])
)
