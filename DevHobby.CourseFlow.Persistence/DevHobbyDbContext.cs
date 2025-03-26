using DevHobby.CourseFlow.Domain.Common;
using DevHobby.CourseFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence;

public class DevHobbyDbContext : DbContext
{
    public DevHobbyDbContext(DbContextOptions<DevHobbyDbContext> options) : base(options)
    {       
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevHobbyDbContext).Assembly);
        SeedInitialData(modelBuilder);
    }

    private static void SeedInitialData(ModelBuilder modelBuilder)
    {
        var csharpGuid = Guid.Parse("{f7aac0ff-28f0-4427-be8b-41472b9b55db}");
        var aspnetcoreGuid = Guid.Parse("{d157b292-cf64-47df-815e-298c34ebc7a3}");
        var softwareArchitectureGuid = Guid.Parse("{29db6e39-1b50-4001-960d-4451bbf2b2ad}");
        var domainDrivenDesignGuid = Guid.Parse("{3141995d-9911-48b0-b651-b5ea6aadfc1d}");
        var microservicesGuid = Guid.Parse("{95057448-5345-4657-9668-c8942a28db26}");

        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = csharpGuid,
            Name = "C#"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = aspnetcoreGuid,
            Name = "Asp.Net Core"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = softwareArchitectureGuid,
            Name = "Software Architecture"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = domainDrivenDesignGuid,
            Name = "Domain Driven Design"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = microservicesGuid,
            Name = "Microservices"
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{63bdb34b-9ebc-4703-8985-c7713cab46f7}"),
            Name = "C# Podstawy Programowania: Twój Pierwszy Krok w Świat Kodowania",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2025, 2, 10),
            Description = "Czy marzysz o zostaniu programistą, ale nie wiesz, od czego zacząć? \"C# Podstawy Programowania: Twój Pierwszy Krok w Świat Kodowania\" to kurs stworzony z myślą o Tobie! Ten kurs oferuje przystępne wprowadzenie do świata C# - języka, który łączy prostotę dla początkujących z możliwościami dla zaawansowanych użytkowników.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpPodstawy.webp",
            CategoryId = csharpGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{190c6fd6-4b5c-42a6-bcf6-fecc68d66d54}"),
            Name = "C# Podstawy Programowanie Obiektowego",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2025, 1, 20),
            Description = "Tematem tego kursu będzie programowanie w języku C #, a dokładnie wszystko co powinieneś wiedzieć o programowaniu obiektowym. Po podaniu specyfikacji nowej funkcji lub nowej aplikacji zacznij od zidentyfikowania klas z wymagań lub specyfikacji. Programowanie obiektowe reprezentuje encje i koncepcje aplikacji jako zbioru klas.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpObiektowka.webp",
            CategoryId = csharpGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{12ef5a63-7dab-41ff-9b33-68ea7bbf9a68}"),
            Name = "C# Najlepsze Praktyki Podstawy Języka",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2025, 1, 2),
            Description = "Kiedy po raz pierwszy zacząłem swoją kariera programistyczna, szybko dowiedziałem się, że jest duża różnica między wiedzą, jak pisać kod a wiedzą jak dobrze napisać kod, i tutaj leży wyzwanie.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpNajlepszePraktyki.webp",
            CategoryId = csharpGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{41651ae9-bae0-4311-9052-87b4e902961d}"),
            Name = "C# Wprowadzenie Do Kolekcji",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 12, 7),
            Description = "W tym kursie pokażę Ci, jak kodować za pomocą prawdopodobnie najbardziej przydatnych i najczęściej używanych kolekcji, takich jak: tablica, lista, stos, kolejka i słownik oraz, co ważne, kiedy używać każdej z tych kolekcji.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpKolekcje.webp",
            CategoryId = csharpGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{b347d23c-0776-4a59-ad9f-b6cce0f70e8e}"),
            Name = "C# Generics",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 11, 17),
            Description = "Ten kurs poświęcony typom generycznym w C# to solidna dawka wiedzy, która pozwoli Ci tworzyć bardziej elastyczny, efektywny i wielokrotnego użytku kod. Nauczysz się, jak korzystać z generyków na różnych poziomach – od podstawowych po zaawansowane koncepcje, takie jak budowanie kontenera wstrzykiwania zależności (Dependency Injection Container).",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpGenerics.webp",
            CategoryId = csharpGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{fdc2a4bb-d08f-4895-95f4-e3f18119f95b}"),
            Name = "C# – Zbuduj Własnego Tetrisa! Kompletny Przewodnik",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 11, 22),
            Description = "Chcesz nauczyć się programowania gier w C#? Zbuduj od podstaw kultowego Tetrisa i poznaj kluczowe koncepcje programowania! W tym kursie przeprowadzimy Cię przez cały proces – od minimalnej wersji gry (MVP) po bardziej zaawansowane mechaniki i optymalizację. ",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpTetris.webp",
            CategoryId = csharpGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{ac955e68-9ec9-45af-9128-fe5312c123a2}"),
            Name = "C# Clean Architecture w Praktyce",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2025, 3, 26),
            Description = "Czy chcesz nauczyć się budować skalowalne, testowalne i łatwe w utrzymaniu aplikacje w C#? Jeśli tak, to ten kurs jest dla Ciebie! Poznasz zasady Clean Architecture i nauczysz się stosować je w praktyce, tworząc dobrze zaprojektowane aplikacje w .NET.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CleanArchitecturePraktyce.webp",
            CategoryId = softwareArchitectureGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{13c1ad99-cfa2-410d-8cdb-c15cd3808871}"),
            Name = "Zbuduj Profesjonalny Portal Randkowy od Podstaw!",
            Price = 800,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 10, 22),
            Description = "Ten kurs nauczy Cię kompleksowego tworzenia aplikacji webowych przy użyciu ASP.NET Core, Entity Framework Core oraz Angular. Obejmuje zarówno backend, jak i frontend, w tym funkcje takie jak uwierzytelnianie, integracja z bazami danych i systemy przesyłania wiadomości. Kurs jest idealny dla początkujących programistów oraz osób pragnących zrealizować swój własny projekt.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/PortalRandkowy.webp",
            CategoryId = aspnetcoreGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{3c420bf1-0580-4648-8c1e-5ea2bc6d7155}"),
            Name = "CMS Shop Paypal - Praktyczny projekt",
            Price = 600,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 10, 11),
            Description = "Ten kurs to kompleksowy przewodnik po budowie aplikacji CMS i sklepu internetowego z wykorzystaniem ASP.NET MVC. Projekt łączy w sobie funkcjonalność systemu zarządzania treścią (CMS) oraz sklepu internetowego, a dodatkowo jest zintegrowany z systemem płatności PayPal. Podczas kursu dowiesz się, jak stworzyć pełnoprawną aplikację webową, opanowując nowoczesne techniki i narzędzia używane w rzeczywistych projektach. ",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/cmsshop.webp",
            CategoryId = aspnetcoreGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{fcd6c1d3-da1a-4dc2-bd9e-585d983d9920}"),
            Name = "ASP.NET Core 2.1 MVC - Pierwsza Aplikacja",
            Price = 200,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 9, 14),
            Description = "W kursie będziemy budować naszą pierwszą aplikację ASP.NET Core 2.1 MVC z Visual Studio 2017. Ten kurs ma na celu dać ci praktyczny sposób, aby dowiedzieć się jak najwięcej o ASP.NET Core 2.1 MVC.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/aspnetcore.webp",
            CategoryId = aspnetcoreGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{2d548535-86f8-4b9a-b4ec-1570362dad75}"),
            Name = "Asp.Net MVC Praktyczny Kurs",
            Price = 200,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 8, 11),
            Description = "Kurs ten poprowadzi Cię krok po kroku przez budowę nowoczesnej aplikacji sklepu internetowego z wykorzystaniem ASP.NET MVC i najważniejszych technologii związanych z tworzeniem aplikacji webowych. Nauczysz się, jak tworzyć funkcjonalne aplikacje od podstaw, zarządzać danymi, obsługiwać użytkowników i budować przyjazny interfejs. Wszystko to w oparciu o praktyczne przykłady i z użyciem najlepszych narzędzi dostępnych w ekosystemie ASP.NET.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/aspnetmvc.webp",
            CategoryId = aspnetcoreGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{f11ba266-1618-49e6-ba9b-5896e668d789}"),
            Name = "Wprowadzenie do HTML5, CSS, JavaScript, jQuery",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 7, 25),
            Description = "Przygotuj się na intensywną dawkę wiedzy i praktyki, która pozwoli Ci rozpocząć tworzenie nowoczesnych, responsywnych stron internetowych. Ten kurs jest idealny dla tych, którzy chcą szybko zdobyć umiejętności potrzebne do pracy z technologiami webowymi po stronie klienta. ",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/htmljscss.webp",
            CategoryId = aspnetcoreGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{9644c719-52df-4af1-bb6b-c89ed5aafc0b}"),
            Name = "Angular - Od Zera Do Bohatera",
            Price = 300,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 6, 17),
            Description = "Wprowadzenie do Angular - Szybki start. Rozpoczęcie nowego projektu opartego o Angular wymaga stworzenia odpowiedniej struktury folderów, skonfigurowania środowiska, zainstalowania TypeScript, definicji typów, stworzenia pierwszego komponentu i wywołania funkcji bootstrap. ",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/Angular.webp",
            CategoryId = aspnetcoreGuid
        });

        modelBuilder.Entity<Course>().HasData(new Course
        {
            CourseId = Guid.Parse("{3da94357-fef3-4ca3-9a58-f5a267c92b7c}"),
            Name = "Co to jest programowanie",
            Price = 0,
            Author = "Mariusz Jurczenko",
            PublicationDate = new DateTime(2024, 6, 17),
            Description = "Oglądasz właśnie nasz najbardziej podstawowy kurs. To jest miejsce, od którego powinieneś zacząć, jeśli nigdy w życiu nie napisałeś ani jednej linijki kodu, albo nawet jeśli to zrobiłeś i chcesz przejrzeć podstawy.",
            ImageUrl = "https://perfumereverie.com/wp-content/uploads/obrazki/CoToJestProgramowanie.webp",
            CategoryId = softwareArchitectureGuid
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{2f2b714d-d7dc-4b41-9fe9-4f6c8b9b44bb}"),
            OrderTotal = 300,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 1, 1),
            UserId = Guid.Parse("{947a072d-74f5-4047-8675-ef3b1c644f86}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{c6f158ce-c515-4e55-b797-c9f9c7d98508}"),
            OrderTotal = 1000,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 1, 10),
            UserId = Guid.Parse("{3203e3cb-5175-479a-8cc1-ff2993310c16}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{40ca3710-79f6-4dd0-bb77-b776ccc16483}"),
            OrderTotal = 600,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 1, 22),
            UserId = Guid.Parse("{9ec292d7-4fbb-4b28-83cf-4ebc36c46f77}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{c4a7b7cc-12e2-4005-b585-6b38d31c08ab}"),
            OrderTotal = 800,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 2, 2),
            UserId = Guid.Parse("{b862b339-905e-4ffb-a75f-aff4bb4783ad}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{a113de03-c149-4433-8986-d06d7af30402}"),
            OrderTotal = 600,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 2, 2),
            UserId = Guid.Parse("{2b57862f-ce11-44be-8be7-8aeea1f1fc55}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{f633cd12-4a1a-4480-a701-ff133765e25a}"),
            OrderTotal = 400,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 2, 9),
            UserId = Guid.Parse("{59df54dd-a756-40a7-bd42-c37884878858}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{13f8f25b-87d0-4c1c-b060-29f6115db06d}"),
            OrderTotal = 300,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 2, 12),
            UserId = Guid.Parse("{66a9d582-f899-455d-ab1b-002c4ff0feff}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{b221702f-c18c-4be4-9b75-a778590079a9}"),
            OrderTotal = 600,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 2, 27),
            UserId = Guid.Parse("{4d614068-1d7e-4053-9d69-70c04be5a1e5}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{bfe84eea-e393-4092-a78e-6467ec30c66f}"),
            OrderTotal = 200,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 2),
            UserId = Guid.Parse("{24b8db77-b04a-4f8a-94e2-c01d89ed99b2}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{1d08316d-d6ba-4cc2-bba1-42e0aa1acae3}"),
            OrderTotal = 400,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 8),
            UserId = Guid.Parse("{0978fbc5-62b2-4679-8a76-08951b8715bb}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{1fac403a-fcc1-4f47-aaad-07734d64f337}"),
            OrderTotal = 600,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 11),
            UserId = Guid.Parse("{352d43bf-47d0-4bcf-b5e6-2608fab38bb4}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{47ebb24b-eb9a-4ab6-b1f7-44d9eacb6fc2}"),
            OrderTotal = 800,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 14),
            UserId = Guid.Parse("{3f42f780-60b8-4bae-b1b4-d5146a15935e}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{34a131be-7afd-46eb-a902-0b566a08b17c}"),
            OrderTotal = 400,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 17),
            UserId = Guid.Parse("{e9a9e856-c99d-4662-ba3e-a5123f4674a0}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{df7d65b2-0c1c-4a0e-b9a3-76efbfcf4e4e}"),
            OrderTotal = 600,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 21),
            UserId = Guid.Parse("{8b22cce4-cb1e-46b9-ab63-1216ba365f4b}"),
        });

        modelBuilder.Entity<Order>().HasData(new Order
        {
            OrderId = Guid.Parse("{bf475bb5-2ede-4ee3-ad29-dd83c619cc4d}"),
            OrderTotal = 300,
            IsOrderPaid = true,
            OrderPlaced = new DateTime(2025, 3, 25),
            UserId = Guid.Parse("{b8f9c1db-dd8b-42dc-bf3c-945a6be1e6e3}"),
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
