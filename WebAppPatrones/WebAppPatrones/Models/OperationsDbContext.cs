using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppPatrones.Models
{
    public partial class OperationsDbContext : DbContext
    {
        public OperationsDbContext()
        {
        }

        public OperationsDbContext(DbContextOptions<OperationsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AtributosDefecto> AtributosDefecto { get; set; }
        public virtual DbSet<BindLine> BindLine { get; set; }
        public virtual DbSet<DefectosPatrones> DefectosPatrones { get; set; }
        public virtual DbSet<DefectosPedido> DefectosPedido { get; set; }
        public virtual DbSet<DefectosPlantilla> DefectosPlantilla { get; set; }
        public virtual DbSet<DestinoPedido> DestinoPedido { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<EstadosPatron> EstadosPatron { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<GruposColumnas> GruposColumnas { get; set; }
        public virtual DbSet<HistoricoPasadasPatron> HistoricoPasadasPatron { get; set; }
        public virtual DbSet<HistoricoPatronActivo> HistoricoPatronActivo { get; set; }
        public virtual DbSet<IdatosCiclos> IdatosCiclos { get; set; }
        public virtual DbSet<InspectionLine> InspectionLine { get; set; }
        public virtual DbSet<LimitesXusuario> LimitesXusuario { get; set; }
        public virtual DbSet<Line> Line { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }
        public virtual DbSet<Maquinas> Maquinas { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<MotivosEstados> MotivosEstados { get; set; }
        public virtual DbSet<Patron> Patron { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Planta> Planta { get; set; }
        public virtual DbSet<Plantilla> Plantilla { get; set; }
        public virtual DbSet<Remitentes> Remitentes { get; set; }
        public virtual DbSet<RepBindTestPipe> RepBindTestPipe { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<TestPipeAttribute> TestPipeAttribute { get; set; }
        public virtual DbSet<TestPipeAttributeValue> TestPipeAttributeValue { get; set; }
        public virtual DbSet<TestPipeRevision> TestPipeRevision { get; set; }
        public virtual DbSet<TipoAtributo> TipoAtributo { get; set; }
        public virtual DbSet<TipoDefecto> TipoDefecto { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Tolerancia> Tolerancia { get; set; }
        public virtual DbSet<TrkPatron> TrkPatron { get; set; }
        public virtual DbSet<TrkPedidos> TrkPedidos { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ValoresAtributos> ValoresAtributos { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        // Unable to generate entity type for table 'dbo.ValoresAtributosPedido'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PAT_GruposUsuarios'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PAT_UsuariosXGrupo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PAT_Atributos'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.patroTemp'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TipoXLinea'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Estiba'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.BrazosEstiba'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Medido'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.MedirNotch'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.patronAux'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Mediciones'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.MarcasDefecto'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DefectImage'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UsuariosPedido'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ValoresAtributosPlantilla'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TR-202-NB;Database=patrones;User Id=sa;Password=hola1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AtributosDefecto>(entity =>
            {
                entity.HasKey(e => new { e.IdAtributo, e.IdTipoDefecto });

                entity.HasOne(d => d.IdAtributoNavigation)
                    .WithMany(p => p.AtributosDefecto)
                    .HasForeignKey(d => d.IdAtributo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosDefecto_TipoAtributo");

                entity.HasOne(d => d.IdTipoDefectoNavigation)
                    .WithMany(p => p.AtributosDefecto)
                    .HasForeignKey(d => d.IdTipoDefecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosDefecto_TipoDefecto");
            });

            modelBuilder.Entity<BindLine>(entity =>
            {
                entity.Property(e => e.IdBindLine).ValueGeneratedNever();

                entity.HasOne(d => d.IdLineNavigation)
                    .WithMany(p => p.BindLine)
                    .HasForeignKey(d => d.IdLine)
                    .HasConstraintName("FK_BindLine_Line");

                entity.HasOne(d => d.IdLineaNavigation)
                    .WithMany(p => p.BindLine)
                    .HasForeignKey(d => d.IdLinea)
                    .HasConstraintName("FK_BindLine_Linea");
            });

            modelBuilder.Entity<DefectosPatrones>(entity =>
            {
                entity.HasKey(e => new { e.IdPatron, e.IdDefecto });

                entity.HasIndex(e => e.IdDefecto)
                    .HasName("IX_DefectosPatrones_Def")
                    .IsUnique();

                entity.Property(e => e.IdDefecto).ValueGeneratedOnAdd();

                entity.Property(e => e.IdResponsable).HasDefaultValueSql("(0)");

                entity.Property(e => e.Letra).IsUnicode(false);

                entity.HasOne(d => d.IdPatronNavigation)
                    .WithMany(p => p.DefectosPatrones)
                    .HasForeignKey(d => d.IdPatron)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefectosPatrones_Patron");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.DefectosPatrones)
                    .HasForeignKey(d => d.IdResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefectosPatrones_Usuarios");

                entity.HasOne(d => d.IdTipoDefectoNavigation)
                    .WithMany(p => p.DefectosPatrones)
                    .HasForeignKey(d => d.IdTipoDefecto)
                    .HasConstraintName("FK_DefectosPatrones_TipoDefecto");
            });

            modelBuilder.Entity<DefectosPedido>(entity =>
            {
                entity.HasIndex(e => e.IdPedido)
                    .HasName("IX_DefectosPedido");

                entity.HasIndex(e => e.IdTipoDefecto)
                    .HasName("IX_DefectosPedido_1");

                entity.Property(e => e.Letra).IsUnicode(false);

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DefectosPedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefectosPedido_Pedidos");

                entity.HasOne(d => d.IdTipoDefectoNavigation)
                    .WithMany(p => p.DefectosPedido)
                    .HasForeignKey(d => d.IdTipoDefecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefectosPedido_TipoDefecto");
            });

            modelBuilder.Entity<DefectosPlantilla>(entity =>
            {
                entity.HasOne(d => d.IdPlantillaNavigation)
                    .WithMany(p => p.DefectosPlantilla)
                    .HasForeignKey(d => d.IdPlantilla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefectosPlantilla_Plantilla1");

                entity.HasOne(d => d.IdTipoDefectoNavigation)
                    .WithMany(p => p.DefectosPlantilla)
                    .HasForeignKey(d => d.IdTipoDefecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DefectosPlantilla_TipoDefecto");
            });

            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<EstadosPatron>(entity =>
            {
                entity.Property(e => e.Status).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Existe).HasDefaultValueSql("(1)");
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Evento).IsUnicode(false);

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Operador).IsUnicode(false);

                entity.Property(e => e.Tabla).IsUnicode(false);
            });

            modelBuilder.Entity<HistoricoPasadasPatron>(entity =>
            {
                entity.Property(e => e.Centro).IsUnicode(false);

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Original).HasDefaultValueSql("(1)");

                entity.Property(e => e.Puesto)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('CND')");

                entity.HasOne(d => d.IdPatronNavigation)
                    .WithMany(p => p.HistoricoPasadasPatron)
                    .HasForeignKey(d => d.IdPatron)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoPasadasPatron_Patron");
            });

            modelBuilder.Entity<HistoricoPatronActivo>(entity =>
            {
                entity.Property(e => e.Activo).HasDefaultValueSql("(1)");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Original).HasDefaultValueSql("(0)");

                entity.Property(e => e.Referencia).HasDefaultValueSql("(80)");

                entity.Property(e => e.Tolerancia).HasDefaultValueSql("(5)");
            });

            modelBuilder.Entity<IdatosCiclos>(entity =>
            {
                entity.Property(e => e.Acero).IsUnicode(false);

                entity.Property(e => e.Diametro).IsUnicode(false);

                entity.Property(e => e.Espesor).IsUnicode(false);

                entity.Property(e => e.Grado).IsUnicode(false);

                entity.Property(e => e.GradoDes).IsUnicode(false);
            });

            modelBuilder.Entity<InspectionLine>(entity =>
            {
                entity.Property(e => e.IdInspectionLine).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.IdStationNavigation)
                    .WithMany(p => p.InspectionLine)
                    .HasForeignKey(d => d.IdStation)
                    .HasConstraintName("FK_InspectionLine_Station");
            });

            modelBuilder.Entity<LimitesXusuario>(entity =>
            {
                entity.HasIndex(e => new { e.IdLinea, e.IdTipoTubo, e.IdUsuario })
                    .HasName("IX_LimitesXUsuario")
                    .IsUnique();
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.Property(e => e.IdLine).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdZoneNavigation)
                    .WithMany(p => p.Line)
                    .HasForeignKey(d => d.IdZone)
                    .HasConstraintName("FK_Line_Zone");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.HasOne(d => d.IdPlantaNavigation)
                    .WithMany(p => p.Linea)
                    .HasForeignKey(d => d.IdPlanta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linea_Planta");
            });

            modelBuilder.Entity<MotivosEstados>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Patron>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.Diametro, e.Espesor, e.Acero })
                    .HasName("IX_Patron_Medidas");

                entity.Property(e => e.Acero)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Acustica).HasDefaultValueSql("(0)");

                entity.Property(e => e.Casilla).IsUnicode(false);

                entity.Property(e => e.Ciclo).HasDefaultValueSql("(0)");

                entity.Property(e => e.Cliente).IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Colada).HasDefaultValueSql("(0)");

                entity.Property(e => e.Cuerpo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Diametro).HasDefaultValueSql("(0)");

                entity.Property(e => e.Esdefinicion).HasDefaultValueSql("(0)");

                entity.Property(e => e.Espesor).HasDefaultValueSql("(0)");

                entity.Property(e => e.Expediente)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaAlta).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Grado)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdBrazoEstiba).HasDefaultValueSql("(1)");

                entity.Property(e => e.IdEstado).HasDefaultValueSql("(0)");

                entity.Property(e => e.IdPadre).HasDefaultValueSql("(0)");

                entity.Property(e => e.IdUbicacion).HasDefaultValueSql("(null)");

                entity.Property(e => e.Longitud).HasDefaultValueSql("(0)");

                entity.Property(e => e.Nivel).IsUnicode(false);

                entity.Property(e => e.NroPasadas).HasDefaultValueSql("(0)");

                entity.Property(e => e.Pasillo).IsUnicode(false);

                entity.Property(e => e.PosicionTag).HasDefaultValueSql("(0)");

                entity.Property(e => e.Registo).IsUnicode(false);

                entity.Property(e => e.Replica).HasDefaultValueSql("(0)");

                entity.Property(e => e.Tipo).HasDefaultValueSql("(1)");

                entity.Property(e => e.TratamientoTermico)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Ubicacion).IsUnicode(false);

                entity.Property(e => e.UltimaPasada).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UltimoUso)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Patron)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patron_EstadosPatron");

                entity.HasOne(d => d.IdMotivoNavigation)
                    .WithMany(p => p.Patron)
                    .HasForeignKey(d => d.IdMotivo)
                    .HasConstraintName("FK_Patron_MotivosEstados");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Patron)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK_Patron_Pedidos");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Patron)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_Patron_Ubicacion");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Patron)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patron_Tipos");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Pedidos");

                entity.Property(e => e.Acero).IsUnicode(false);

                entity.Property(e => e.Acustica).HasDefaultValueSql("(0)");

                entity.Property(e => e.Auditor).IsUnicode(false);

                entity.Property(e => e.Cliente).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Expediente).IsUnicode(false);

                entity.Property(e => e.FechaUltimaModif).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Grado).IsUnicode(false);

                entity.Property(e => e.Motivo).IsUnicode(false);

                entity.Property(e => e.NotificarAuditor).HasDefaultValueSql("(0)");

                entity.Property(e => e.Obs).IsUnicode(false);

                entity.Property(e => e.Ot).IsUnicode(false);

                entity.Property(e => e.Producto).IsUnicode(false);

                entity.Property(e => e.TratamientoTermico).IsUnicode(false);

                entity.Property(e => e.Ubicacion).IsUnicode(false);

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdDestino)
                    .HasConstraintName("FK_Pedidos_DestinoPedido");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_EstadosPatron");

                entity.HasOne(d => d.IdRemitenteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdRemitente)
                    .HasConstraintName("FK_Pedidos_Remitentes");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_Pedidos_Tipos");

                entity.HasOne(d => d.LineaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Linea)
                    .HasConstraintName("FK_Pedidos_Linea");
            });

            modelBuilder.Entity<Planta>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Remitentes>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Nregistro).IsUnicode(false);
            });

            modelBuilder.Entity<RepBindTestPipe>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.IdStation).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdLineNavigation)
                    .WithMany(p => p.Station)
                    .HasForeignKey(d => d.IdLine)
                    .HasConstraintName("FK_Station_Line");
            });

            modelBuilder.Entity<TestPipeAttribute>(entity =>
            {
                entity.Property(e => e.DataType).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<TestPipeAttributeValue>(entity =>
            {
                entity.Property(e => e.IdTestPipeAttributeValue).ValueGeneratedNever();

                entity.Property(e => e.Value).IsUnicode(false);
            });

            modelBuilder.Entity<TipoAtributo>(entity =>
            {
                entity.HasIndex(e => e.IdAtributo)
                    .HasName("IX_TipoAtributo");

                entity.Property(e => e.AtMarca).HasDefaultValueSql("(0)");

                entity.Property(e => e.Decimales).HasDefaultValueSql("(3)");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Descripcion2).IsUnicode(false);

                entity.Property(e => e.Unidad)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('--')");

                entity.HasOne(d => d.GrupoMedicionNavigation)
                    .WithMany(p => p.TipoAtributoGrupoMedicionNavigation)
                    .HasForeignKey(d => d.GrupoMedicion)
                    .HasConstraintName("FK_TipoAtributo_GruposColumnas1");

                entity.HasOne(d => d.GrupoPedidoNavigation)
                    .WithMany(p => p.TipoAtributoGrupoPedidoNavigation)
                    .HasForeignKey(d => d.GrupoPedido)
                    .HasConstraintName("FK_TipoAtributo_GruposColumnas");

                entity.HasOne(d => d.ToleranciaNavigation)
                    .WithMany(p => p.TipoAtributo)
                    .HasForeignKey(d => d.Tolerancia)
                    .HasConstraintName("FK_TipoAtributo_Tolerancia");
            });

            modelBuilder.Entity<TipoDefecto>(entity =>
            {
                entity.Property(e => e.ArchivoDibujo).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Tipos>(entity =>
            {
                entity.Property(e => e.AplicaNorma).HasDefaultValueSql("(1)");

                entity.Property(e => e.Label).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Tolerancia>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<TrkPatron>(entity =>
            {
                entity.HasIndex(e => e.IdPatron)
                    .HasName("IX_TRK_Patron");

                entity.Property(e => e.Acero).IsUnicode(false);

                entity.Property(e => e.Casilla).IsUnicode(false);

                entity.Property(e => e.Cliente).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Cuerpo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Expediente).IsUnicode(false);

                entity.Property(e => e.Grado).IsUnicode(false);

                entity.Property(e => e.Nivel).IsUnicode(false);

                entity.Property(e => e.Pasillo).IsUnicode(false);

                entity.Property(e => e.Registro).IsUnicode(false);

                entity.Property(e => e.TratamientoTermico).IsUnicode(false);

                entity.Property(e => e.Ubicacion).IsUnicode(false);

                entity.Property(e => e.UltimoUso).IsUnicode(false);
            });

            modelBuilder.Entity<TrkPedidos>(entity =>
            {
                entity.Property(e => e.Acero).IsUnicode(false);

                entity.Property(e => e.Auditor).IsUnicode(false);

                entity.Property(e => e.Cliente).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Expediente).IsUnicode(false);

                entity.Property(e => e.FechaUltimaModif).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Grado).IsUnicode(false);

                entity.Property(e => e.Producto).IsUnicode(false);

                entity.Property(e => e.TratamientoTermico).IsUnicode(false);

                entity.Property(e => e.Ubicacion).IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.Property(e => e.IdUbicacion).ValueGeneratedNever();

                entity.HasOne(d => d.IdlineaNavigation)
                    .WithMany(p => p.Ubicacion)
                    .HasForeignKey(d => d.Idlinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ubicacion_Linea");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.CargaPatrones).HasDefaultValueSql("(1)");

                entity.Property(e => e.CertificaDefectos).HasDefaultValueSql("(1)");

                entity.Property(e => e.Clave).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nivel).HasDefaultValueSql("(0)");

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Nregistro).IsUnicode(false);
            });

            modelBuilder.Entity<ValoresAtributos>(entity =>
            {
                entity.HasKey(e => new { e.IdDefecto, e.IdAtributo });

                entity.HasOne(d => d.IdAtributoNavigation)
                    .WithMany(p => p.ValoresAtributos)
                    .HasForeignKey(d => d.IdAtributo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValoresAtributos_TipoAtributo");

                entity.HasOne(d => d.IdDefectoNavigation)
                    .WithMany(p => p.ValoresAtributos)
                    .HasPrincipalKey(p => p.IdDefecto)
                    .HasForeignKey(d => d.IdDefecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValoresAtributos_DefectosPatrones");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.Property(e => e.IdZone).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });
        }
    }
}
