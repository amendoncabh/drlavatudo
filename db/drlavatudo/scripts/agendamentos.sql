CREATE TABLE [dbo].[agendamentos]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [quando] SMALLDATETIME NOT NULL DEFAULT (GETDATE()), 
    [duracao] NUMERIC(12, 4) NOT NULL DEFAULT (0), 
    [pedido] INT NOT NULL, 
    [complemento] TEXT NULL, 
    [atendente] INT NOT NULL, 
    [responsavel] INT NOT NULL, 
    [situacao] CHAR(1) NOT NULL DEFAULT ('0'), 
    CONSTRAINT [fk_agendamentos_pedidos] FOREIGN KEY ([pedido]) REFERENCES [pedidos]([codigo]), 
    CONSTRAINT [fk_agendamentos_atendentes] FOREIGN KEY ([atendente]) REFERENCES [colaboradores]([codigo]), 
    CONSTRAINT [fk_agendamentos_responsaveis] FOREIGN KEY ([responsavel]) REFERENCES [colaboradores]([codigo]), 
    CONSTRAINT [ck_agendamentos_duracao] CHECK ([duracao] >= 3600)
)

GO

CREATE INDEX [ix_agendamentos_1] ON [dbo].[agendamentos] ([quando], [atendente], [pedido])
