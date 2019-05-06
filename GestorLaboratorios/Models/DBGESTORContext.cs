using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorLaboratorios.Models
{
    public partial class DBGESTORContext : DbContext
    {
        public DBGESTORContext()
        {
        }

        public DBGESTORContext(DbContextOptions<DBGESTORContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdmElemento> AdmElemento { get; set; }
        public virtual DbSet<AdmElementoParte> AdmElementoParte { get; set; }
        public virtual DbSet<AdmLaboratorio> AdmLaboratorio { get; set; }
        public virtual DbSet<AdmMantenimiento> AdmMantenimiento { get; set; }
        public virtual DbSet<AdmPerfil> AdmPerfil { get; set; }
        public virtual DbSet<AdmPrestamoReserva> AdmPrestamoReserva { get; set; }
        public virtual DbSet<AdmPrestamoReservaElemento> AdmPrestamoReservaElemento { get; set; }
        public virtual DbSet<AdmTipoElemento> AdmTipoElemento { get; set; }
        public virtual DbSet<AdmUsuario> AdmUsuario { get; set; }
        public virtual DbSet<AdmUsuarioLaboratorio> AdmUsuarioLaboratorio { get; set; }
        public virtual DbSet<LogElementoEstado> LogElementoEstado { get; set; }
        public virtual DbSet<SysElementoEstado> SysElementoEstado { get; set; }
        public virtual DbSet<SysEstadoPrestamoReserva> SysEstadoPrestamoReserva { get; set; }
        public virtual DbSet<SysEstadoUsuario> SysEstadoUsuario { get; set; }
        public virtual DbSet<SysTipoMantenimiento> SysTipoMantenimiento { get; set; }
        public virtual DbSet<SysTipoPrestamoReserva> SysTipoPrestamoReserva { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;port=3306;Database=gestor_laboratorios;user=root;password=Sa2019%");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmElemento>(entity =>
            {
                entity.HasKey(e => e.EleId);

                entity.ToTable("adm_elemento");

                entity.HasIndex(e => e.EleEstado)
                    .HasName("FK_adm_elemento__sys_elemento_estado_idx");

                entity.HasIndex(e => e.EleLaboratorio)
                    .HasName("FK_adm_elemento__adm_laboratorio_idx");

                entity.HasIndex(e => e.EleTipoElemento)
                    .HasName("FK_adm_elemento__adm_tipo_elemento_idx");

                entity.HasIndex(e => e.EleUsuarioCreacion)
                    .HasName("FK_adm_elemento__adm_usuario_idx");

                entity.Property(e => e.EleId)
                    .HasColumnName("ele_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EleActivo)
                    .HasColumnName("ele_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EleDescripcion)
                    .HasColumnName("ele_descripcion")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.EleEstado)
                    .HasColumnName("ele_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EleFechaCreacion)
                    .HasColumnName("ele_fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.EleLaboratorio)
                    .HasColumnName("ele_laboratorio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EleMarca)
                    .HasColumnName("ele_marca")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EleModelo)
                    .HasColumnName("ele_modelo")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EleObservaciones)
                    .HasColumnName("ele_observaciones")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ElePlacaUan)
                    .HasColumnName("ele_placa_uan")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EleSerial)
                    .HasColumnName("ele_serial")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EleTipoElemento)
                    .HasColumnName("ele_tipo_elemento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EleUsuarioCreacion)
                    .HasColumnName("ele_usuario_creacion")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.EleEstadoNavigation)
                    .WithMany(p => p.AdmElemento)
                    .HasForeignKey(d => d.EleEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_elemento__sys_elemento_estado");

                entity.HasOne(d => d.EleLaboratorioNavigation)
                    .WithMany(p => p.AdmElemento)
                    .HasForeignKey(d => d.EleLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_elemento__adm_laboratorio");

                entity.HasOne(d => d.EleTipoElementoNavigation)
                    .WithMany(p => p.AdmElemento)
                    .HasForeignKey(d => d.EleTipoElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_elemento__adm_tipo_elemento");

                entity.HasOne(d => d.EleUsuarioCreacionNavigation)
                    .WithMany(p => p.AdmElemento)
                    .HasForeignKey(d => d.EleUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_elemento__adm_usuario");
            });

            modelBuilder.Entity<AdmElementoParte>(entity =>
            {
                entity.HasKey(e => e.EpaId);

                entity.ToTable("adm_elemento_parte");

                entity.HasIndex(e => e.EpaElemento)
                    .HasName("FK_adm_elemento_parte__adm_elemento");

                entity.Property(e => e.EpaId)
                    .HasColumnName("epa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EpaActivo)
                    .HasColumnName("epa_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EpaDescripcion)
                    .HasColumnName("epa_descripcion")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EpaElemento)
                    .HasColumnName("epa_elemento")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.EpaElementoNavigation)
                    .WithMany(p => p.AdmElementoParte)
                    .HasForeignKey(d => d.EpaElemento)
                    .HasConstraintName("FK_adm_elemento_parte__adm_elemento");
            });

            modelBuilder.Entity<AdmLaboratorio>(entity =>
            {
                entity.HasKey(e => e.LabId);

                entity.ToTable("adm_laboratorio");

                entity.Property(e => e.LabId)
                    .HasColumnName("lab_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LabActivo)
                    .HasColumnName("lab_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LabCorreo)
                    .HasColumnName("lab_correo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LabEncargado)
                    .HasColumnName("lab_encargado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LabLogo)
                    .HasColumnName("lab_logo")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LabNombre)
                    .IsRequired()
                    .HasColumnName("lab_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LabTelefono)
                    .HasColumnName("lab_telefono")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ProAbreviatura)
                    .IsRequired()
                    .HasColumnName("pro_abreviatura")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<AdmMantenimiento>(entity =>
            {
                entity.HasKey(e => e.ManId);

                entity.ToTable("adm_mantenimiento");

                entity.HasIndex(e => e.ManElemento)
                    .HasName("FK_adm_mantenimiento__adm_elemento_idx");

                entity.HasIndex(e => e.ManTipoMantenimiento)
                    .HasName("FK_adm_mantenimiento__sys_tipo_mantenimiento");

                entity.HasIndex(e => e.ManUsuarioCreacion)
                    .HasName("FK_adm_mantenimiento__adm_usuario_idx");

                entity.Property(e => e.ManId)
                    .HasColumnName("man_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ManDescripcion)
                    .HasColumnName("man_descripcion")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ManElemento)
                    .HasColumnName("man_elemento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ManFechaFin)
                    .HasColumnName("man_fecha_fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManFechaInicio)
                    .HasColumnName("man_fecha_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManFinalizado)
                    .HasColumnName("man_finalizado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ManRepuestos)
                    .HasColumnName("man_repuestos")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ManTipoMantenimiento)
                    .HasColumnName("man_tipo_mantenimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ManUsuarioCreacion)
                    .HasColumnName("man_usuario_creacion")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ManElementoNavigation)
                    .WithMany(p => p.AdmMantenimiento)
                    .HasForeignKey(d => d.ManElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_mantenimiento__adm_elemento");

                entity.HasOne(d => d.ManTipoMantenimientoNavigation)
                    .WithMany(p => p.AdmMantenimiento)
                    .HasForeignKey(d => d.ManTipoMantenimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_mantenimiento__sys_tipo_mantenimiento");

                entity.HasOne(d => d.ManUsuarioCreacionNavigation)
                    .WithMany(p => p.AdmMantenimiento)
                    .HasForeignKey(d => d.ManUsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_mantenimiento__adm_usuario");
            });

            modelBuilder.Entity<AdmPerfil>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.ToTable("adm_perfil");

                entity.Property(e => e.PerId)
                    .HasColumnName("per_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerActivo)
                    .HasColumnName("per_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PerDescripcion)
                    .IsRequired()
                    .HasColumnName("per_descripcion")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<AdmPrestamoReserva>(entity =>
            {
                entity.HasKey(e => e.PreId);

                entity.ToTable("adm_prestamo_reserva");

                entity.HasIndex(e => e.PreEstado)
                    .HasName("FK_adm_prestamo__sys_estado_prestamo_reserva_idx");

                entity.HasIndex(e => e.PreLaboratorio)
                    .HasName("FK_adm_prestamo_reserva__adm_laboratorio_idx");

                entity.HasIndex(e => e.PreTipo)
                    .HasName("FK_adm_prestamo__sys_tipo_prestamo_reserva_idx");

                entity.HasIndex(e => e.PreUsuario)
                    .HasName("FK_adm_prestamo_reserva__adm_usuario_idx");

                entity.Property(e => e.PreId)
                    .HasColumnName("pre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreEstado)
                    .HasColumnName("pre_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreFechaCreacion)
                    .HasColumnName("pre_fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.PreFechaPrestamoReserva)
                    .HasColumnName("pre_fecha_prestamo_reserva")
                    .HasColumnType("datetime");

                entity.Property(e => e.PreHoraFin)
                    .HasColumnName("pre_hora_fin")
                    .HasColumnType("time");

                entity.Property(e => e.PreHoraInicio)
                    .HasColumnName("pre_hora_inicio")
                    .HasColumnType("time");

                entity.Property(e => e.PreLaboratorio)
                    .HasColumnName("pre_laboratorio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreMateria)
                    .HasColumnName("pre_materia")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PreProfesor)
                    .HasColumnName("pre_profesor")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PreTipo)
                    .HasColumnName("pre_tipo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreUsuario)
                    .HasColumnName("pre_usuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PreEstadoNavigation)
                    .WithMany(p => p.AdmPrestamoReserva)
                    .HasForeignKey(d => d.PreEstado)
                    .HasConstraintName("FK_adm_prestamo__sys_estado_prestamo_reserva");

                entity.HasOne(d => d.PreLaboratorioNavigation)
                    .WithMany(p => p.AdmPrestamoReserva)
                    .HasForeignKey(d => d.PreLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_prestamo_reserva__adm_laboratorio");

                entity.HasOne(d => d.PreTipoNavigation)
                    .WithMany(p => p.AdmPrestamoReserva)
                    .HasForeignKey(d => d.PreTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_prestamo__sys_tipo_prestamo_reserva");

                entity.HasOne(d => d.PreUsuarioNavigation)
                    .WithMany(p => p.AdmPrestamoReserva)
                    .HasForeignKey(d => d.PreUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_prestamo_reserva__adm_usuario");
            });

            modelBuilder.Entity<AdmPrestamoReservaElemento>(entity =>
            {
                entity.HasKey(e => new { e.PreReserva, e.PreElemento });

                entity.ToTable("adm_prestamo_reserva_elemento");

                entity.HasIndex(e => e.PreElemento)
                    .HasName("FK_adm_prestamo_reserva_elemento__adm_elemento_idx");

                entity.Property(e => e.PreReserva)
                    .HasColumnName("pre_reserva")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreElemento)
                    .HasColumnName("pre_elemento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreEntregado)
                    .HasColumnName("pre_entregado")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PreElementoNavigation)
                    .WithMany(p => p.AdmPrestamoReservaElemento)
                    .HasForeignKey(d => d.PreElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_prestamo_reserva_elemento__adm_elemento");

                entity.HasOne(d => d.PreReservaNavigation)
                    .WithMany(p => p.AdmPrestamoReservaElemento)
                    .HasForeignKey(d => d.PreReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_prestamo_reserva_elemento__adm_prestamo_reserva");
            });

            modelBuilder.Entity<AdmTipoElemento>(entity =>
            {
                entity.HasKey(e => e.TelId);

                entity.ToTable("adm_tipo_elemento");

                entity.HasIndex(e => e.TelLaboratorio)
                    .HasName("FK_adm_tipo_elemento__adm_elemento_idx");

                entity.Property(e => e.TelId)
                    .HasColumnName("tel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TelActivo)
                    .HasColumnName("tel_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TelDescripcion)
                    .IsRequired()
                    .HasColumnName("tel_descripcion")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TelLaboratorio)
                    .HasColumnName("tel_laboratorio")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TelLaboratorioNavigation)
                    .WithMany(p => p.AdmTipoElemento)
                    .HasForeignKey(d => d.TelLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_tipo_elemento__adm_laboratorio");
            });

            modelBuilder.Entity<AdmUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("adm_usuario");

                entity.HasIndex(e => e.UsuEstado)
                    .HasName("FK_adm_usuario__sys_estado_usuario_idx");

                entity.HasIndex(e => e.UsuPerfil)
                    .HasName("FK_adm_usuario__adm_perfil_idx");

                entity.Property(e => e.UsuId)
                    .HasColumnName("usu_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuActivo)
                    .HasColumnName("usu_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuApellido)
                    .IsRequired()
                    .HasColumnName("usu_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UsuCodigo)
                    .HasColumnName("usu_codigo")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.UsuContrasena)
                    .IsRequired()
                    .HasColumnName("usu_contrasena")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UsuCorreo)
                    .IsRequired()
                    .HasColumnName("usu_correo")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UsuEstado)
                    .HasColumnName("usu_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuFechaCreacion)
                    .HasColumnName("usu_fecha_creacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFoto)
                    .IsRequired()
                    .HasColumnName("usu_foto")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.UsuIdentificacion)
                    .HasColumnName("usu_identificacion")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("usu_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UsuPerfil)
                    .HasColumnName("usu_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuTelefono)
                    .HasColumnName("usu_telefono")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.UsuEstadoNavigation)
                    .WithMany(p => p.AdmUsuario)
                    .HasForeignKey(d => d.UsuEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_usuario__sys_estado_usuario");

                entity.HasOne(d => d.UsuPerfilNavigation)
                    .WithMany(p => p.AdmUsuario)
                    .HasForeignKey(d => d.UsuPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_usuario__adm_perfil");
            });

            modelBuilder.Entity<AdmUsuarioLaboratorio>(entity =>
            {
                entity.HasKey(e => new { e.UprUsuario, e.UprLaboratorio });

                entity.ToTable("adm_usuario_laboratorio");

                entity.HasIndex(e => e.UprLaboratorio)
                    .HasName("FK_adm_usuario_propiedad__adm_propiedad_idx");

                entity.Property(e => e.UprUsuario)
                    .HasColumnName("upr_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UprLaboratorio)
                    .HasColumnName("upr_laboratorio")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UprLaboratorioNavigation)
                    .WithMany(p => p.AdmUsuarioLaboratorio)
                    .HasForeignKey(d => d.UprLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_usuario_laboratorio__adm_laboratorio");

                entity.HasOne(d => d.UprUsuarioNavigation)
                    .WithMany(p => p.AdmUsuarioLaboratorio)
                    .HasForeignKey(d => d.UprUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adm_usuario_propiedad__adm_usuario");
            });

            modelBuilder.Entity<LogElementoEstado>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("log_elemento_estado");

                entity.HasIndex(e => e.LogElemento)
                    .HasName("FK_log_elemento_estado__adm_elemento_idx");

                entity.HasIndex(e => e.LogEstadoFin)
                    .HasName("FK_log_elemento_estado_idx");

                entity.HasIndex(e => new { e.LogEstadoInicio, e.LogEstadoFin })
                    .HasName("FK_log_elemento_estado__sys_elemento_estado_idx");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LogElemento)
                    .HasColumnName("log_elemento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LogEstadoFin)
                    .HasColumnName("log_estado_fin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LogEstadoInicio)
                    .HasColumnName("log_estado_inicio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LogFecha)
                    .HasColumnName("log_fecha")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.LogElementoNavigation)
                    .WithMany(p => p.LogElementoEstado)
                    .HasForeignKey(d => d.LogElemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_elemento_estado__adm_elemento");

                entity.HasOne(d => d.LogEstadoFinNavigation)
                    .WithMany(p => p.LogElementoEstadoLogEstadoFinNavigation)
                    .HasForeignKey(d => d.LogEstadoFin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_elemento_estado");

                entity.HasOne(d => d.LogEstadoInicioNavigation)
                    .WithMany(p => p.LogElementoEstadoLogEstadoInicioNavigation)
                    .HasForeignKey(d => d.LogEstadoInicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_elemento_estado__adm_usuario");
            });

            modelBuilder.Entity<SysElementoEstado>(entity =>
            {
                entity.HasKey(e => e.EesId);

                entity.ToTable("sys_elemento_estado");

                entity.Property(e => e.EesId)
                    .HasColumnName("ees_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EesActivo)
                    .HasColumnName("ees_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EesDescripcion)
                    .IsRequired()
                    .HasColumnName("ees_descripcion")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<SysEstadoPrestamoReserva>(entity =>
            {
                entity.HasKey(e => e.EprId);

                entity.ToTable("sys_estado_prestamo_reserva");

                entity.Property(e => e.EprId)
                    .HasColumnName("epr_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EprActivo)
                    .HasColumnName("epr_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EprDescripcion)
                    .IsRequired()
                    .HasColumnName("epr_descripcion")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysEstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.EusId);

                entity.ToTable("sys_estado_usuario");

                entity.Property(e => e.EusId)
                    .HasColumnName("eus_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EusActivo)
                    .HasColumnName("eus_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EusDescripcion)
                    .IsRequired()
                    .HasColumnName("eus_descripcion")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<SysTipoMantenimiento>(entity =>
            {
                entity.HasKey(e => e.TmaId);

                entity.ToTable("sys_tipo_mantenimiento");

                entity.Property(e => e.TmaId)
                    .HasColumnName("tma_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TmaActivo)
                    .HasColumnName("tma_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TmaDescripcion)
                    .IsRequired()
                    .HasColumnName("tma_descripcion")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<SysTipoPrestamoReserva>(entity =>
            {
                entity.HasKey(e => e.TprId);

                entity.ToTable("sys_tipo_prestamo_reserva");

                entity.Property(e => e.TprId)
                    .HasColumnName("tpr_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TprActivo)
                    .HasColumnName("tpr_activo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TprDescripcion)
                    .IsRequired()
                    .HasColumnName("tpr_descripcion")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
