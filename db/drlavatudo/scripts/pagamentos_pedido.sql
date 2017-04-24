CREATE TABLE [dbo].[pagamentos_pedido]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [pedido] INT NOT NULL,
    [metodo] INT NOT NULL, 
    [situacao] CHAR NOT NULL DEFAULT ('A'), 
    CONSTRAINT [fk_pagamentos_pedido_pedidos] FOREIGN KEY ([pedido]) REFERENCES [pedidos]([codigo]), 
    CONSTRAINT [fk_pagamentos_pedido_metodos] FOREIGN KEY ([metodo]) REFERENCES [metodos_pagamento]([codigo])
)

GO

CREATE INDEX [ix_pagamentos_pedido] ON [dbo].[pagamentos_pedido] ([pedido], [metodo], [situacao])
