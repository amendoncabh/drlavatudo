CREATE TABLE [dbo].[itens_agendamento]
(
	[codigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [agenda] INT NOT NULL, 
    [procedimento] INT NOT NULL, 
    [complemento] TEXT NULL, 
    [situacao] CHAR(1) NOT NULL DEFAULT ('0'), 
    CONSTRAINT [fk_itens_agendamento_agendas] FOREIGN KEY ([agenda]) REFERENCES [agendamentos]([codigo]), 
    CONSTRAINT [fk_itens_agendamento_procedimentos] FOREIGN KEY ([procedimento]) REFERENCES [itens_pedido]([codigo])
)

GO

CREATE INDEX [ix_itens_agendamento_1] ON [dbo].[itens_agendamento] ([agenda], [situacao])
