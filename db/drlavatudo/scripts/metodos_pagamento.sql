CREATE TABLE [dbo].[metodos_pagamento]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(30) NOT NULL, 
    [tipo] CHAR NOT NULL DEFAULT ('D'), 
    [prefixo] VARCHAR(3) NULL, 
    [sufixo] VARCHAR(3) NULL, 
    [termo] INT NULL, 
    [situacao] CHAR NOT NULL DEFAULT ('A')
)

GO

CREATE INDEX [ix_metodos_pagamento] ON [dbo].[metodos_pagamento] ([nome], [tipo])
