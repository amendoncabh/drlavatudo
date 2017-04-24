namespace app.drlavatudo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class drlavatudo_db : DbContext
    {
        public drlavatudo_db()
            : base("name=drlavatudo_db")
        {
        }

        public virtual DbSet<agendamentos> agendamentos { get; set; }
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<colaboradores> colaboradores { get; set; }
        public virtual DbSet<colaboradoresXregioes> colaboradoresXregioes { get; set; }
        public virtual DbSet<itens_agendamento> itens_agendamento { get; set; }
        public virtual DbSet<itens_pedido> itens_pedido { get; set; }
        public virtual DbSet<listas_preco> listas_preco { get; set; }
        public virtual DbSet<metodos_pagamento> metodos_pagamento { get; set; }
        public virtual DbSet<pagamentos_pedido> pagamentos_pedido { get; set; }
        public virtual DbSet<pedidos> pedidos { get; set; }
        public virtual DbSet<precos_produto> precos_produto { get; set; }
        public virtual DbSet<produtos> produtos { get; set; }
        public virtual DbSet<regioes> regioes { get; set; }
        public virtual DbSet<unidades_medida> unidades_medida { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<agendamentos>()
                .Property(e => e.duracao)
                .HasPrecision(12, 4);

            modelBuilder.Entity<agendamentos>()
                .Property(e => e.complemento)
                .IsUnicode(false);

            modelBuilder.Entity<agendamentos>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<agendamentos>()
                .HasMany(e => e.itens_agendamento)
                .WithRequired(e => e.agendamentos)
                .HasForeignKey(e => e.agenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.categorias1)
                .WithOptional(e => e.categorias2)
                .HasForeignKey(e => e.codigo_pai);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.clientes)
                .WithRequired(e => e.categorias)
                .HasForeignKey(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.colaboradores)
                .WithRequired(e => e.categorias)
                .HasForeignKey(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.listas_preco)
                .WithRequired(e => e.categorias)
                .HasForeignKey(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.eh_empresa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cpf_cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.municipio)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.codigo_postal)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.unidade_federativa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.pais)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.telefone_fixo)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.telefone_movel)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .HasMany(e => e.pedidos)
                .WithRequired(e => e.clientes)
                .HasForeignKey(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.municipio)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.codigo_postal)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.unidade_federativa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.pais)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.telefone_fixo)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.telefone_movel)
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.comissao)
                .HasPrecision(5, 2);

            modelBuilder.Entity<colaboradores>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<colaboradores>()
                .HasMany(e => e.agendamentos)
                .WithRequired(e => e.colaboradores)
                .HasForeignKey(e => e.atendente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<colaboradores>()
                .HasMany(e => e.agendamentos1)
                .WithRequired(e => e.colaboradores1)
                .HasForeignKey(e => e.responsavel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<colaboradores>()
                .HasMany(e => e.colaboradoresXregioes)
                .WithRequired(e => e.colaboradores)
                .HasForeignKey(e => e.colaborador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<colaboradores>()
                .HasMany(e => e.pedidos)
                .WithRequired(e => e.colaboradores)
                .HasForeignKey(e => e.vendedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<colaboradoresXregioes>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<itens_agendamento>()
                .Property(e => e.complemento)
                .IsUnicode(false);

            modelBuilder.Entity<itens_agendamento>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<itens_pedido>()
                .Property(e => e.quantidade)
                .HasPrecision(12, 4);

            modelBuilder.Entity<itens_pedido>()
                .Property(e => e.preco)
                .HasPrecision(19, 4);

            modelBuilder.Entity<itens_pedido>()
                .Property(e => e.valor)
                .HasPrecision(19, 4);

            modelBuilder.Entity<itens_pedido>()
                .Property(e => e.comissao)
                .HasPrecision(5, 2);

            modelBuilder.Entity<itens_pedido>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<itens_pedido>()
                .HasMany(e => e.itens_agendamento)
                .WithRequired(e => e.itens_pedido)
                .HasForeignKey(e => e.procedimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<listas_preco>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<listas_preco>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<listas_preco>()
                .Property(e => e.condicao)
                .IsUnicode(false);

            modelBuilder.Entity<listas_preco>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<listas_preco>()
                .HasMany(e => e.pedidos)
                .WithRequired(e => e.listas_preco)
                .HasForeignKey(e => e.lista_preco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<listas_preco>()
                .HasMany(e => e.precos_produto)
                .WithRequired(e => e.listas_preco)
                .HasForeignKey(e => e.lista_preco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<metodos_pagamento>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<metodos_pagamento>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<metodos_pagamento>()
                .Property(e => e.prefixo)
                .IsUnicode(false);

            modelBuilder.Entity<metodos_pagamento>()
                .Property(e => e.sufixo)
                .IsUnicode(false);

            modelBuilder.Entity<metodos_pagamento>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<metodos_pagamento>()
                .HasMany(e => e.pagamentos_pedido)
                .WithRequired(e => e.metodos_pagamento)
                .HasForeignKey(e => e.metodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pagamentos_pedido>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<pedidos>()
                .Property(e => e.comissao)
                .HasPrecision(5, 2);

            modelBuilder.Entity<pedidos>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<pedidos>()
                .HasMany(e => e.agendamentos)
                .WithRequired(e => e.pedidos)
                .HasForeignKey(e => e.pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pedidos>()
                .HasMany(e => e.itens_pedido)
                .WithRequired(e => e.pedidos)
                .HasForeignKey(e => e.pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pedidos>()
                .HasMany(e => e.pagamentos_pedido)
                .WithRequired(e => e.pedidos)
                .HasForeignKey(e => e.pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<precos_produto>()
                .Property(e => e.fator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<precos_produto>()
                .Property(e => e.valor)
                .HasPrecision(12, 4);

            modelBuilder.Entity<precos_produto>()
                .Property(e => e.situacao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<produtos>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<produtos>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<produtos>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<produtos>()
                .Property(e => e.quantidade)
                .HasPrecision(12, 4);

            modelBuilder.Entity<produtos>()
                .Property(e => e.preco)
                .HasPrecision(19, 4);

            modelBuilder.Entity<produtos>()
                .Property(e => e.comissao)
                .HasPrecision(5, 2);

            modelBuilder.Entity<produtos>()
                .HasMany(e => e.itens_pedido)
                .WithRequired(e => e.produtos)
                .HasForeignKey(e => e.produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<produtos>()
                .HasMany(e => e.precos_produto)
                .WithRequired(e => e.produtos)
                .HasForeignKey(e => e.produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<regioes>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<regioes>()
                .Property(e => e.codigo_postal_de)
                .IsUnicode(false);

            modelBuilder.Entity<regioes>()
                .Property(e => e.codigo_postal_ate)
                .IsUnicode(false);

            modelBuilder.Entity<regioes>()
                .Property(e => e.municipio)
                .IsUnicode(false);

            modelBuilder.Entity<regioes>()
                .Property(e => e.unidade_federativa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<regioes>()
                .HasMany(e => e.colaboradoresXregioes)
                .WithRequired(e => e.regioes)
                .HasForeignKey(e => e.regiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<unidades_medida>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<unidades_medida>()
                .Property(e => e.grandeza)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<unidades_medida>()
                .Property(e => e.simbolo)
                .IsUnicode(false);

            modelBuilder.Entity<unidades_medida>()
                .Property(e => e.fator)
                .HasPrecision(12, 4);

            modelBuilder.Entity<unidades_medida>()
                .HasMany(e => e.produtos)
                .WithRequired(e => e.unidades_medida)
                .HasForeignKey(e => e.unidade_medida)
                .WillCascadeOnDelete(false);
        }
    }
}
