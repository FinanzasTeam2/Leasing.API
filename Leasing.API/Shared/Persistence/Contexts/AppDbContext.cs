

using Leasing.API.App.Domain.Models;
using Leasing.API.App.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Leasing.API.App.Shared.Persistence.Contexts;

public class AppDbContext:DbContext
{
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LeasingData> LeasingData { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<LeasingMethod> LeasingMethods { get; set; }
        public DbSet<LeasingResult> LeasingResults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*-----------------------Properties and keys-----------------------*/

            
            //LeasingData
            builder.Entity<LeasingData>().ToTable("leasing_datos");
            builder.Entity<LeasingData>().HasKey(p => p.Id);
            builder.Entity<LeasingData>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            
            builder.Entity<LeasingData>().Property(p => p.Porcentaje_Primera_Tasa_Efectiva).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Duracion_Primera_Tasa_Efectiva).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Porcentaje_Segunda_Tasa_Efectiva).HasMaxLength(50);

            builder.Entity<LeasingData>().Property(p => p.Precio_de_Venta_del_Activo).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Porcentaje_Cuota_Inicial).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Numero_de_Anios_a_Pagar).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Frecuencia_de_Pago_en_Dias).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Numero_de_Dias_por_Anio).HasMaxLength(50);
            
            builder.Entity<LeasingData>().Property(p => p.Primer_Plazo_de_Gracia_Meses).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Primer_Tipo_de_Gracia).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Segundo_Plazo_de_Gracia_Meses).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Segundo_Tipo_de_Gracia).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Costes_Notariales).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Costes_Registrales).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Tasacion).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Tasacion).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Comision_de_Estudio).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Comision_de_Activacion).HasMaxLength(50);

            builder.Entity<LeasingData>().Property(p => p.Comision_Periodica).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Portes).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Gastos_de_Administracion).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Porcentaje_de_Seguro_de_Desgravamen).HasMaxLength(50);
            builder.Entity<LeasingData>().Property(p => p.Porcentaje_de_Seguro_de_Riesgo).HasMaxLength(50);

            builder.Entity<LeasingData>().Property(p => p.Costo_de_Oportunidad).HasMaxLength(50);
            
            //LeasingResults
            builder.Entity<LeasingResult>().ToTable("leasing_resultados");
            builder.Entity<LeasingResult>().HasKey(p => p.Id);
            builder.Entity<LeasingResult>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            
            builder.Entity<LeasingResult>().Property(p => p.Saldo_a_Financiar).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Monto_del_Prestamo).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Numero_de_Cuotas_por_Anio).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Numero_Total_de_Cuotas).HasMaxLength(50);

            builder.Entity<LeasingResult>().Property(p => p.Porcentaje_de_Seguro_Desgravamen_Periodo).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Seguro_Riesgo).HasMaxLength(50);
            
            builder.Entity<LeasingResult>().Property(p => p.Intereses).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Amortizacion_del_Capital).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Seguro_de_Desgravamen).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Seguro_Contra_Todo_Riesgo).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Comisiones_Periodicas_Riesgo).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.Portes_Gastos_de_Administracion).HasMaxLength(50);

            builder.Entity<LeasingResult>().Property(p => p.Tasa_de_Descuento).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.TIR_de_la_Operacion).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.TCEA_de_la_Operacion).HasMaxLength(50);
            builder.Entity<LeasingResult>().Property(p => p.VAN_Operacion).HasMaxLength(50);

            //LeasingMethod
            builder.Entity<LeasingMethod>().ToTable("leasing_metodos");
            builder.Entity<LeasingMethod>().HasKey(p => p.Id);
            builder.Entity<LeasingMethod>().Property(p => p.Id).IsRequired();
            builder.Entity<LeasingMethod>().Property(p => p.Nombre).HasMaxLength(50);
            
            //User
            builder.Entity<User>().ToTable("usuarios");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired();
            builder.Entity<User>().Property(p => p.Nombre).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Apellido).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Correo).HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Contrasenia).HasMaxLength(50);

            //CurrencyType
            builder.Entity<CurrencyType>().ToTable("tipo_monedas");
            builder.Entity<CurrencyType>().HasKey(p => p.Id);
            builder.Entity<CurrencyType>().Property(p => p.Id).IsRequired();
            builder.Entity<CurrencyType>().Property(p => p.Moneda).HasMaxLength(50);
            builder.Entity<CurrencyType>().Property(p => p.Valor).HasMaxLength(50);

            /*----------------------- Relationships and Foreignkeys -----------------------*/
            
            // --------------------------- User -------------------------------- //
            
            //User with LeasingData
            builder.Entity<User>()
                .HasMany(p => p.LeasingData)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // --------------------------- CurrencyType -------------------------------- //
            
            //CurrencyType with LeasingData 
            builder.Entity<CurrencyType>()
                .HasMany(p => p.LeasingData)
                .WithOne(p => p.CurrencyType)
                .HasForeignKey(p => p.CurrencyTypeId);

            // --------------------------- LeasingData -------------------------------- //
            
            //LeasingData with LeasingResult 
            builder.Entity<LeasingData>()
                .HasMany(p => p.LeasingResults)
                .WithOne(p => p.LeasingData)
                .HasForeignKey(p => p.LeasingDataId);
            
            // --------------------------- LeasingMethod -------------------------------- //
            
            //LeasingMethod with LeasingResult 
            builder.Entity<LeasingMethod>()
                .HasMany(p => p.LeasingResults)
                .WithOne(p => p.LeasingMethod)
                .HasForeignKey(p=>p.LeasingMethodId);

            //builder.UseSnakeCaseNamingConvention();
        }
}
