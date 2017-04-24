CREATE TABLE [dbo].[itens_pedido]
(
	[codigo] INT NOT NULL PRIMARY KEY, 
    [pedido] INT NOT NULL, 
    [produto] INT NOT NULL, 
    [quantidade] NUMERIC(12, 4) NOT NULL, 
    [preco] MONEY NOT NULL, 
    [valor] MONEY NOT NULL, 
    [comissao] DECIMAL(5, 2) NOT NULL DEFAULT (0), 
    [situacao] CHAR(1) NOT NULL DEFAULT ('0'), 
    CONSTRAINT [fk_itens_pedido_pedidos] FOREIGN KEY ([pedido]) REFERENCES [pedidos]([codigo]), 
    CONSTRAINT [fk_itens_pedido_produtos] FOREIGN KEY ([produto]) REFERENCES [produtos]([codigo])
)

GO


CREATE UNIQUE INDEX [ux_itens_pedido] ON [dbo].[itens_pedido] ([pedido], [produto], [situacao])

GO
