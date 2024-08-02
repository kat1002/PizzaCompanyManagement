using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public partial class PizzaOrderSystemContext : DbContext
{
    public PizzaOrderSystemContext()
    {

    }

    public PizzaOrderSystemContext(DbContextOptions<PizzaOrderSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Crust> Crusts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<DrinkOrder> DrinkOrders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }

    public virtual DbSet<Side> Sides { get; set; }

    public virtual DbSet<SideOrder> SideOrders { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Topping> Toppings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("DB"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crust>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Crust__3214EC271560C42E");

            entity.ToTable("Crust");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC271A7516BB");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.IsAdmin).HasColumnName("isadmin");
        });

        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drinks__3214EC2706B43D5A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<DrinkOrder>(entity =>
        {
            entity.HasKey(e => new { e.DrinkId, e.OrderId }).HasName("PK__DrinkOrd__DD819B1D89884396");

            entity.ToTable("DrinkOrder");

            entity.Property(e => e.DrinkId).HasColumnName("drinkID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Drink).WithMany(p => p.DrinkOrders)
                .HasForeignKey(d => d.DrinkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DrinkOrde__drink__5535A963");

            entity.HasOne(d => d.Order).WithMany(p => p.DrinkOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DrinkOrde__order__5629CD9C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC27D6ACF980");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.OrderDate).HasColumnName("orderDate");
            entity.Property(e => e.OrderTime).HasColumnName("orderTime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__customerI__4AB81AF0");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pizza__3214EC271E4B785D");

            entity.ToTable("Pizza");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CrustId).HasColumnName("crustID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SizeId).HasColumnName("sizeID");

            entity.HasOne(d => d.Crust).WithMany(p => p.Pizzas)
                .HasForeignKey(d => d.CrustId)
                .HasConstraintName("FK__Pizza__crustID__4316F928");

            entity.HasOne(d => d.Size).WithMany(p => p.Pizzas)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__Pizza__sizeID__440B1D61");

            entity.HasMany(d => d.Toppings).WithMany(p => p.Pizzas)
                .UsingEntity<Dictionary<string, object>>(
                    "PizzaTopping",
                    r => r.HasOne<Topping>().WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PizzaTopp__toppi__47DBAE45"),
                    l => l.HasOne<Pizza>().WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PizzaTopp__pizza__46E78A0C"),
                    j =>
                    {
                        j.HasKey("PizzaId", "ToppingId").HasName("PK__PizzaTop__C7E285AF92753869");
                        j.ToTable("PizzaTopping");
                        j.IndexerProperty<int>("PizzaId").HasColumnName("pizzaID");
                        j.IndexerProperty<int>("ToppingId").HasColumnName("toppingID");
                    });
        });
        modelBuilder.Entity<PizzaOrder>(entity =>
        {
            entity.HasKey(e => new { e.PizzaId, e.OrderId }).HasName("PK__PizzaOrd__8DCC03F8CC004649");

            entity.ToTable("PizzaOrder");

            entity.Property(e => e.PizzaId).HasColumnName("pizzaID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.PizzaOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PizzaOrde__order__4E88ABD4");

            entity.HasOne(d => d.Pizza).WithMany(p => p.PizzaOrders)
                .HasForeignKey(d => d.PizzaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PizzaOrde__pizza__4D94879B");
        });

        modelBuilder.Entity<Side>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sides__3214EC27B4C3B349");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<SideOrder>(entity =>
        {
            entity.HasKey(e => new { e.SideId, e.OrderId }).HasName("PK__SideOrde__A0909300D52BF947");

            entity.ToTable("SideOrder");

            entity.Property(e => e.SideId).HasColumnName("sideID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.SideOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SideOrder__order__52593CB8");

            entity.HasOne(d => d.Side).WithMany(p => p.SideOrders)
                .HasForeignKey(d => d.SideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SideOrder__sideI__5165187F");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Size__3214EC27805D5E49");

            entity.ToTable("Size");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Topping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Toppings__3214EC27710EF858");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
