using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevHobby.CourseFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsOrderPaid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("29db6e39-1b50-4001-960d-4451bbf2b2ad"), "Software Architecture" },
                    { new Guid("3141995d-9911-48b0-b651-b5ea6aadfc1d"), "Domain Driven Design" },
                    { new Guid("95057448-5345-4657-9668-c8942a28db26"), "Microservices" },
                    { new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "Asp.Net Core" },
                    { new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "C#" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "IsOrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("13f8f25b-87d0-4c1c-b060-29f6115db06d"), true, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, new Guid("66a9d582-f899-455d-ab1b-002c4ff0feff") },
                    { new Guid("1d08316d-d6ba-4cc2-bba1-42e0aa1acae3"), true, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, new Guid("0978fbc5-62b2-4679-8a76-08951b8715bb") },
                    { new Guid("1fac403a-fcc1-4f47-aaad-07734d64f337"), true, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, new Guid("352d43bf-47d0-4bcf-b5e6-2608fab38bb4") },
                    { new Guid("2f2b714d-d7dc-4b41-9fe9-4f6c8b9b44bb"), true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, new Guid("947a072d-74f5-4047-8675-ef3b1c644f86") },
                    { new Guid("34a131be-7afd-46eb-a902-0b566a08b17c"), true, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, new Guid("e9a9e856-c99d-4662-ba3e-a5123f4674a0") },
                    { new Guid("40ca3710-79f6-4dd0-bb77-b776ccc16483"), true, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, new Guid("9ec292d7-4fbb-4b28-83cf-4ebc36c46f77") },
                    { new Guid("47ebb24b-eb9a-4ab6-b1f7-44d9eacb6fc2"), true, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 800, new Guid("3f42f780-60b8-4bae-b1b4-d5146a15935e") },
                    { new Guid("a113de03-c149-4433-8986-d06d7af30402"), true, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, new Guid("2b57862f-ce11-44be-8be7-8aeea1f1fc55") },
                    { new Guid("b221702f-c18c-4be4-9b75-a778590079a9"), true, new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, new Guid("4d614068-1d7e-4053-9d69-70c04be5a1e5") },
                    { new Guid("bf475bb5-2ede-4ee3-ad29-dd83c619cc4d"), true, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, new Guid("b8f9c1db-dd8b-42dc-bf3c-945a6be1e6e3") },
                    { new Guid("bfe84eea-e393-4092-a78e-6467ec30c66f"), true, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, new Guid("24b8db77-b04a-4f8a-94e2-c01d89ed99b2") },
                    { new Guid("c4a7b7cc-12e2-4005-b585-6b38d31c08ab"), true, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 800, new Guid("b862b339-905e-4ffb-a75f-aff4bb4783ad") },
                    { new Guid("c6f158ce-c515-4e55-b797-c9f9c7d98508"), true, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, new Guid("3203e3cb-5175-479a-8cc1-ff2993310c16") },
                    { new Guid("df7d65b2-0c1c-4a0e-b9a3-76efbfcf4e4e"), true, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, new Guid("8b22cce4-cb1e-46b9-ab63-1216ba365f4b") },
                    { new Guid("f633cd12-4a1a-4480-a701-ff133765e25a"), true, new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, new Guid("59df54dd-a756-40a7-bd42-c37884878858") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Author", "CategoryId", "Description", "ImageUrl", "Name", "Price", "PublicationDate" },
                values: new object[,]
                {
                    { new Guid("12ef5a63-7dab-41ff-9b33-68ea7bbf9a68"), "Mariusz Jurczenko", new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "Kiedy po raz pierwszy zacząłem swoją kariera programistyczna, szybko dowiedziałem się, że jest duża różnica między wiedzą, jak pisać kod a wiedzą jak dobrze napisać kod, i tutaj leży wyzwanie.", "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpNajlepszePraktyki.webp", "C# Najlepsze Praktyki Podstawy Języka", 300, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("13c1ad99-cfa2-410d-8cdb-c15cd3808871"), "Mariusz Jurczenko", new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "Ten kurs nauczy Cię kompleksowego tworzenia aplikacji webowych przy użyciu ASP.NET Core, Entity Framework Core oraz Angular. Obejmuje zarówno backend, jak i frontend, w tym funkcje takie jak uwierzytelnianie, integracja z bazami danych i systemy przesyłania wiadomości. Kurs jest idealny dla początkujących programistów oraz osób pragnących zrealizować swój własny projekt.", "https://perfumereverie.com/wp-content/uploads/obrazki/PortalRandkowy.webp", "Zbuduj Profesjonalny Portal Randkowy od Podstaw!", 800, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("190c6fd6-4b5c-42a6-bcf6-fecc68d66d54"), "Mariusz Jurczenko", new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "Tematem tego kursu będzie programowanie w języku C #, a dokładnie wszystko co powinieneś wiedzieć o programowaniu obiektowym. Po podaniu specyfikacji nowej funkcji lub nowej aplikacji zacznij od zidentyfikowania klas z wymagań lub specyfikacji. Programowanie obiektowe reprezentuje encje i koncepcje aplikacji jako zbioru klas.", "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpObiektowka.webp", "C# Podstawy Programowanie Obiektowego", 300, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d548535-86f8-4b9a-b4ec-1570362dad75"), "Mariusz Jurczenko", new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "Kurs ten poprowadzi Cię krok po kroku przez budowę nowoczesnej aplikacji sklepu internetowego z wykorzystaniem ASP.NET MVC i najważniejszych technologii związanych z tworzeniem aplikacji webowych. Nauczysz się, jak tworzyć funkcjonalne aplikacje od podstaw, zarządzać danymi, obsługiwać użytkowników i budować przyjazny interfejs. Wszystko to w oparciu o praktyczne przykłady i z użyciem najlepszych narzędzi dostępnych w ekosystemie ASP.NET.", "https://perfumereverie.com/wp-content/uploads/obrazki/aspnetmvc.webp", "Asp.Net MVC Praktyczny Kurs", 200, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c420bf1-0580-4648-8c1e-5ea2bc6d7155"), "Mariusz Jurczenko", new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "Ten kurs to kompleksowy przewodnik po budowie aplikacji CMS i sklepu internetowego z wykorzystaniem ASP.NET MVC. Projekt łączy w sobie funkcjonalność systemu zarządzania treścią (CMS) oraz sklepu internetowego, a dodatkowo jest zintegrowany z systemem płatności PayPal. Podczas kursu dowiesz się, jak stworzyć pełnoprawną aplikację webową, opanowując nowoczesne techniki i narzędzia używane w rzeczywistych projektach. ", "https://perfumereverie.com/wp-content/uploads/obrazki/cmsshop.webp", "CMS Shop Paypal - Praktyczny projekt", 600, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3da94357-fef3-4ca3-9a58-f5a267c92b7c"), "Mariusz Jurczenko", new Guid("29db6e39-1b50-4001-960d-4451bbf2b2ad"), "Oglądasz właśnie nasz najbardziej podstawowy kurs. To jest miejsce, od którego powinieneś zacząć, jeśli nigdy w życiu nie napisałeś ani jednej linijki kodu, albo nawet jeśli to zrobiłeś i chcesz przejrzeć podstawy.", "https://perfumereverie.com/wp-content/uploads/obrazki/CoToJestProgramowanie.webp", "Co to jest programowanie", 0, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41651ae9-bae0-4311-9052-87b4e902961d"), "Mariusz Jurczenko", new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "W tym kursie pokażę Ci, jak kodować za pomocą prawdopodobnie najbardziej przydatnych i najczęściej używanych kolekcji, takich jak: tablica, lista, stos, kolejka i słownik oraz, co ważne, kiedy używać każdej z tych kolekcji.", "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpKolekcje.webp", "C# Wprowadzenie Do Kolekcji", 300, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63bdb34b-9ebc-4703-8985-c7713cab46f7"), "Mariusz Jurczenko", new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "Czy marzysz o zostaniu programistą, ale nie wiesz, od czego zacząć? \"C# Podstawy Programowania: Twój Pierwszy Krok w Świat Kodowania\" to kurs stworzony z myślą o Tobie! Ten kurs oferuje przystępne wprowadzenie do świata C# - języka, który łączy prostotę dla początkujących z możliwościami dla zaawansowanych użytkowników.", "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpPodstawy.webp", "C# Podstawy Programowania: Twój Pierwszy Krok w Świat Kodowania", 300, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9644c719-52df-4af1-bb6b-c89ed5aafc0b"), "Mariusz Jurczenko", new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "Wprowadzenie do Angular - Szybki start. Rozpoczęcie nowego projektu opartego o Angular wymaga stworzenia odpowiedniej struktury folderów, skonfigurowania środowiska, zainstalowania TypeScript, definicji typów, stworzenia pierwszego komponentu i wywołania funkcji bootstrap. ", "https://perfumereverie.com/wp-content/uploads/obrazki/Angular.webp", "Angular - Od Zera Do Bohatera", 300, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac955e68-9ec9-45af-9128-fe5312c123a2"), "Mariusz Jurczenko", new Guid("29db6e39-1b50-4001-960d-4451bbf2b2ad"), "Czy chcesz nauczyć się budować skalowalne, testowalne i łatwe w utrzymaniu aplikacje w C#? Jeśli tak, to ten kurs jest dla Ciebie! Poznasz zasady Clean Architecture i nauczysz się stosować je w praktyce, tworząc dobrze zaprojektowane aplikacje w .NET.", "https://perfumereverie.com/wp-content/uploads/obrazki/CleanArchitecturePraktyce.webp", "C# Clean Architecture w Praktyce", 300, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b347d23c-0776-4a59-ad9f-b6cce0f70e8e"), "Mariusz Jurczenko", new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "Ten kurs poświęcony typom generycznym w C# to solidna dawka wiedzy, która pozwoli Ci tworzyć bardziej elastyczny, efektywny i wielokrotnego użytku kod. Nauczysz się, jak korzystać z generyków na różnych poziomach – od podstawowych po zaawansowane koncepcje, takie jak budowanie kontenera wstrzykiwania zależności (Dependency Injection Container).", "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpGenerics.webp", "C# Generics", 300, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f11ba266-1618-49e6-ba9b-5896e668d789"), "Mariusz Jurczenko", new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "Przygotuj się na intensywną dawkę wiedzy i praktyki, która pozwoli Ci rozpocząć tworzenie nowoczesnych, responsywnych stron internetowych. Ten kurs jest idealny dla tych, którzy chcą szybko zdobyć umiejętności potrzebne do pracy z technologiami webowymi po stronie klienta. ", "https://perfumereverie.com/wp-content/uploads/obrazki/htmljscss.webp", "Wprowadzenie do HTML5, CSS, JavaScript, jQuery", 300, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fcd6c1d3-da1a-4dc2-bd9e-585d983d9920"), "Mariusz Jurczenko", new Guid("d157b292-cf64-47df-815e-298c34ebc7a3"), "W kursie będziemy budować naszą pierwszą aplikację ASP.NET Core 2.1 MVC z Visual Studio 2017. Ten kurs ma na celu dać ci praktyczny sposób, aby dowiedzieć się jak najwięcej o ASP.NET Core 2.1 MVC.", "https://perfumereverie.com/wp-content/uploads/obrazki/aspnetcore.webp", "ASP.NET Core 2.1 MVC - Pierwsza Aplikacja", 200, new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fdc2a4bb-d08f-4895-95f4-e3f18119f95b"), "Mariusz Jurczenko", new Guid("f7aac0ff-28f0-4427-be8b-41472b9b55db"), "Chcesz nauczyć się programowania gier w C#? Zbuduj od podstaw kultowego Tetrisa i poznaj kluczowe koncepcje programowania! W tym kursie przeprowadzimy Cię przez cały proces – od minimalnej wersji gry (MVP) po bardziej zaawansowane mechaniki i optymalizację. ", "https://perfumereverie.com/wp-content/uploads/obrazki/CsharpTetris.webp", "C# – Zbuduj Własnego Tetrisa! Kompletny Przewodnik", 300, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
