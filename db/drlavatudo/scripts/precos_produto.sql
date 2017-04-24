CREATE TABLE [dbo].[precos_produto]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [lista_preco] INT NOT NULL, 
    [produto] INT NOT NULL, 
    [fator] CHAR(1) NOT NULL DEFAULT ('P'), 
    [valor] NUMERIC(12, 4) NOT NULL DEFAULT (0), 
    [situacao] CHAR(1) NOT NULL DEFAULT ('A'), 
    CONSTRAINT [fk_precos_produto_produtos] FOREIGN KEY ([produto]) REFERENCES [produtos]([codigo]), 
    CONSTRAINT [fk_precos_produto_listas_preco] FOREIGN KEY ([lista_preco]) REFERENCES [listas_preco]([codigo])
)

GO

CREATE UNIQUE INDEX [ix_precos_produto_1] ON [dbo].[precos_produto] ([lista_preco],[produto],[situacao])
