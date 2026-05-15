# Ticketing System — Part 1 Session Notes
**Date:** 15 May 2026  
**Project:** Ticket System (Free Time Project)  
**Tech Stack:** ASP.NET MVC, Entity Framework Core, SQL Server, Bootstrap

---

## 1. Project Overview

A ticketing application for managing tasks, issues, and projects. Inspired by the freeCodeCamp ticketing app challenge, rebuilt using a C# / SQL Server stack instead of the original Next.js / MongoDB stack.

### Stack Mapping

| Original | Replacement |
|---|---|
| Next.js + App Router | ASP.NET MVC |
| Tailwind CSS | Bootstrap |
| MongoDB Atlas | SQL Server |
| Mongoose | Entity Framework Core |

---

## 2. Planning Decisions

### Entities
Rather than creating separate tables for Tasks, Issues, and Projects, all work items are represented as a single **Ticket** entity with a `Category` property to describe the type.

Two entities were identified:
- **User** — represents anyone who interacts with the system
- **Ticket** — represents a work item

### Key Design Decisions
- A User can be both a Requester and a Handler depending on the ticket, so no separate tables are needed — only a **Role** property on User.
- RequesterID and HandlerID live on the **Ticket** table as foreign keys pointing back to the User table.
- **Soft deletes** implemented via an `IsActive` BIT column (default: true) instead of hard deletes, to preserve data integrity.
- **Role** handled via a `UserRole` enum with values: `Requester`, `Handler`.
- **Priority** handled via a `PriorityStatus` enum with values: `Low`, `Medium`, `High`.

### Features (CRUD)
- Create a ticket
- Read / track tickets
- Update ticket details, assignment, and priority
- Soft delete a ticket
- Filter tickets by priority
- Role-based dashboards (Requester view / Handler view)

### Pages
- Login page
- Requester dashboard
- Handler dashboard

---

## 3. Models Built

### User.cs
```csharp
public class User
{
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public UserRole UserRole { get; set; }

    [InverseProperty("Requester")]
    public List<Ticket>? RequestedTickets { get; set; }

    [InverseProperty("Handler")]
    public List<Ticket>? HandledTickets { get; set; }
}
```

### Ticket.cs
```csharp
public class Ticket
{
    public int TicketId { get; set; }
    public string? Subject { get; set; }
    public string? Description { get; set; }
    public PriorityStatus Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DueDate { get; set; }
    public int RequesterId { get; set; }
    public int HandlerId { get; set; }
    public bool IsActive { get; set; } = true;

    [ForeignKey("RequesterId")]
    public User? Requester { get; set; }

    [ForeignKey("HandlerId")]
    public User? Handler { get; set; }
}
```

### Enums
```csharp
public enum UserRole { Requester, Handler }
public enum PriorityStatus { Low, Medium, High }
```

---

## 4. Database Setup

### NuGet Packages Installed
- `Microsoft.EntityFrameworkCore` — core EF library
- `Microsoft.EntityFrameworkCore.SqlServer` — SQL Server provider
- `Microsoft.EntityFrameworkCore.Tools` — enables migration commands
- `Microsoft.EntityFrameworkCore.Design` — required for design-time tooling

### DbContext
```csharp
public class TicketingSystemDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }

    public TicketingSystemDbContext(DbContextOptions<TicketingSystemDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Requester)
            .WithMany(u => u.RequestedTickets)
            .HasForeignKey(t => t.RequesterId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Handler)
            .WithMany(u => u.HandledTickets)
            .HasForeignKey(t => t.HandlerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
```

### Connection String (appsettings.json)
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=LAPTOP-G138HG6D\\SQLEXPRESS;Database=TicketingSystemDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Program.cs Registration
```csharp
builder.Services.AddDbContext<TicketingSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## 5. Migrations

### Commands Used
```
Add-Migration InitialCreate
Add-Migration ConfigureRelationships
Drop-Database
Update-Database
```

### What Each Migration Did
- **InitialCreate** — generated SQL to create Users and Tickets tables with primary keys, foreign keys, and indexes.
- **ConfigureRelationships** — updated foreign keys from `ON DELETE CASCADE` to `ON DELETE NO ACTION` to resolve the multiple cascade paths error.

---

## 6. Key Concepts Learned

### MVC Pattern
- **Model** — C# classes representing real-world domain objects (blueprints)
- **View** — what the user sees (HTML + Bootstrap)
- **Controller** — handles HTTP requests and passes data to the View

### Code First vs Database First
- **Database First** — design tables in SSMS, generate models from them
- **Code First** — write C# models, EF generates the database automatically via migrations

### Entity Framework Core
- `DbContext` represents the database session
- `DbSet<T>` represents a table
- Migrations track model changes and apply them to the database

### Dependency Injection
- Instead of a class creating its own dependencies, it declares what it needs and the framework provides it
- `builder.Services.AddDbContext<>()` registers the DbContext so controllers can receive it automatically

### Navigation Properties
- `[ForeignKey("RequesterId")]` tells EF which int property is the foreign key
- `[InverseProperty("Requester")]` tells EF which collection maps to which navigation property
- Both are needed when two foreign keys point to the same table

### Cascade Delete Issue
- Two foreign keys from Ticket to User caused a "multiple cascade paths" error in SQL Server
- Fixed by setting `DeleteBehavior.NoAction` in `OnModelCreating`
- This means deleting a User will not automatically delete their tickets

### Soft Deletes
- Instead of removing records permanently, an `IsActive` column flags records as inactive
- Preserves historical data and maintains referential integrity

---

## 7. Database Result

`TicketingSystemDb` successfully created in SQL Server with:
- **Users** table — UserId, Name, Email, Password, UserRole
- **Tickets** table — TicketId, Subject, Description, Priority, CreatedAt, UpdatedAt, DueDate, RequesterId, HandlerId, IsActive

---

## 8. Next Steps (Part 2)

- Build `TicketController` with CRUD actions
- Build `UserController` for login and role management
- Create Razor Views for dashboards
- Implement role-based routing
- Add Bootstrap styling
