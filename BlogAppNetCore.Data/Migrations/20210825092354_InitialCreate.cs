using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAppNetCore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 318, DateTimeKind.Local).AddTicks(7970), "C# Programlama Dili İle İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 318, DateTimeKind.Local).AddTicks(7983), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 318, DateTimeKind.Local).AddTicks(7998), "C++ Programlama Dili İle İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 318, DateTimeKind.Local).AddTicks(8000), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 318, DateTimeKind.Local).AddTicks(8004), "JavaScript Programlama Dili İle İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 318, DateTimeKind.Local).AddTicks(8006), "JavaScript", "CJavaScript Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 323, DateTimeKind.Local).AddTicks(1109), "Admin Rolü Tüm Haklara Sahiptir.", true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 323, DateTimeKind.Local).AddTicks(1124), "Admin", "Admin Rolüdür." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 338, DateTimeKind.Local).AddTicks(2407), "İlk ADmin Kullanıcı", "nadirkorkutt@gmail.com", "Nadir", true, false, "Korkut", "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 338, DateTimeKind.Local).AddTicks(2421), "Admin Kullanıcısı", new byte[] { 98, 100, 48, 98, 49, 49, 50, 99, 53, 100, 53, 52, 54, 98, 99, 49, 48, 50, 56, 51, 102, 56, 97, 98, 100, 57, 48, 55, 56, 101, 101, 49 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "nadirkorkut" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 1, 1, 1, "Geçtiğimiz haftalarda pandemi nedeniyle online düzenlenen Microsoft Build 2020 etkinliğinde birçok yenilik duyurusu yapıldı. Biz yazılım geliştiricilerin en ilgisini çekenlerden biri belki de C# 9 ile hangi yeniliklerin geleceğiydi. Build etkinliğinde duyurulan yeni C# dil özelliklerinden bazılarını bu makalede ele alıp inceleyeceğiz. Elbette gelecek olan yenilikler bu makalede anlatılanlarla sınırlı değil ve bazı yeniliklerin eklenip çıkarılabileceğini biliyoruz. Şunu hatırlatmakta fayda var; bu yazı Haziran 2020’de yazıldı ve henüz resmi bir C# 9 sürümü çıkmadı. Yazıda sadece Build etkinliğinde duyurulan ve yakın gelecekte karşımıza çıkması kuvvetle muhtemel C# 9 dil özelliklerinden bazılarına göz atacağız.Yeni gelecek özellikleri şu başlıklar altında inceleyelim:Target-type newBildiğiniz üzere sınıflar referans tiplerdir.Bir sınıfın örneğini almak için new operatörü kullanırız.C# 9‘dan önce bir sınıfın örneğini almak için aşağıdaki tanımlamayı yapmamız gerekiyordu. List customerNames = new List(); C# 9 ile beraber artık new operatörünü kullandıktan sonra bir tip belirtmemize gerek kalmıyor. Aşağıdaki tanımlama ve yukarıdaki tanımlama aslında aynı şeyi ifade etmekte. var keyword’ünün eşittir operatörünün sağ tarafına geçmiş haline benzetebiliriz sanırım bu kullanımı.List<string> customerNames = new();", "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 314, DateTimeKind.Local).AddTicks(8536), new DateTime(2021, 8, 25, 12, 23, 53, 314, DateTimeKind.Local).AddTicks(6266), true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 314, DateTimeKind.Local).AddTicks(9699), "C# 9.0 Yenilikleri", "Nadir Korkut", "C# 9.0 Yenilikleri", "C#, C# 9", "Default.jpg", "C# 9.0 Yenilikleri", 1, 100 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 2, 2, 1, "C++ dilinde kod geliştiren yazılımcılar, dilin 1998 yılında standartlaşmasının ardından, 2011 yılında C++11 standardı çıkana kadar uzunca bir süre kullandıkları dilde bir değişim olmadan yazılımlarını geliştirmeye devam etmişlerdi. Bu zaman zarfında gelişen ve değişen dünyadaki problemlere çözüm bulmak, C++ dilinde gittikçe zorlaşmış, üçüncü parti kütüphane desteği olmadan güncel problemlere çözüm sunamayan eski kalmış bir dil haline gelmişti. C++ geliştiricileri, Boost gibi kütüphaneler olmadan diğer yazılım dillerinin sağladığı özellikler ile yarışamaz bir durumdaydılar.Uzun bir aranın ardından yayınlanan C++11 standardı,mevcut dile birçok değişiklik getirmiş; C++ dilini adeta yeni bir dil haline getirmişti.Lambda expressions, auto, constexpr, future gibi yeni gelen özellikler ile bugün Modern C++olarak adlandırılan yeni bir dönem başlamış ve C++, diğer yazılım dilleri olan yarışında kendine tekrar üst sıralarda yer bulabilmişti.C++11 ile başlayan ve her 3 yılda bir güncellenen standart, geleneğini C++20 güncellemesi ile devam ettiriyor. C++14 ve C++17 standartları, C++11 ile gelen özelliklerin güçlendirilmesi, daha çok derleyici zamanında kod çalıştırılması gibi yenilikler getirirken, dile çok fazla veya çok büyük yenilikler getirmemişlerdi.Ancak, C++20 standardı ile birlikte gelen 4 büyük yenilik ve birçok yeni iyileştirme sayesinde C++dili, diğer diller ile olan rekabetinde yeni bir sayfa daha açacağa benziyor.Büyük dörtlü olarak ifade edilen, Concepts, Ranges, Coroutines ve Modules özelliklerinin dile eklenmesiyle birlikte, C++ dünyasını, tıpkı C++11 güncellemesi gibi büyük değişiklikler bekliyor.", "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 315, DateTimeKind.Local).AddTicks(2515), new DateTime(2021, 8, 25, 12, 23, 53, 315, DateTimeKind.Local).AddTicks(2513), true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 315, DateTimeKind.Local).AddTicks(2516), "C++ 20 İle Gelen Yenilikler", "Nadir Korkut", "C++ 20 İle Gelen Yenilikler", "C++, C++ 20", "Default.jpg", "C++ 20 İle Gelen Yenilikler", 1, 158 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 3, 3, 1, "Ne haber millet! JavaScript, harika bir programlama dili gelişiyor. ECMAScript 2020 (yaygın olarak ES2020 olarak bilinir) özelliklerinin artık TC39 komitesi tarafından tamamlandığına dair iyi haberi duymaktan mutluluk duyuyoruz.Yeni JavaScript'teki bazı ilginç özellikleri görelim.BigInt BigInt olan yerleşik bir daha büyük bir bütün sayıları temsil etmek için bir yol sağlar nesne POW(2, 53) - 1, JavaScript güvenilir bir şekilde temsil en büyük sayı olan Numarası ilkel ve ile temsil edilen Number.MAX_SAFE_INTEGER sabit.A BigInt,nbir tamsayı değişmezinin sonuna eklenerek veya işlevi çağırarak oluşturulur BigInt(). Bununla birlikte, BigInt kullanarak çok büyük sayıları temsil edebiliriz, BigInt türü normal sayılarla kullanıldığında bazı sınırlamalar vardır. Yerleşik Mathnesnedeki yöntemlerle kullanılamaz ve Numberişlemlerde örnekleri ile karıştırılamaz . Aynı tip ile kullanılmaları gerekir.BigInt,IEEE754 standartlarıyla geriye dönük olarak uyumlu değildir çünkü bu sayı sistemi çok büyük sayıları destekleyemez.İsteğe Bağlı ZincirlemeBu,JavaScript kodunuzun daha net görünmesini sağlayan heyecan verici özelliklerden biridir.İsteğe bağlı zincirleme?., bir ara özellik mevcut olmasa bile,yuvalanmış nesne özelliklerine erişmenin hatasız bir yoludur.Kulağa ilginç geliyor mu ? Bu özellik,derinlemesine iç içe geçmiş nesnenin her seviyesinde özellik varlığını kontrol etmek için çok sayıda kod satırı yazmayı kaydetmelidir.Bir nesnenin bir özelliğine ulaşmak istediğinizde, genellikle &&nesne boş veya tanımsız olduğunda hata almaktan kaçınmak için operatörü kullanabilirsiniz .Bu yeni JavaScript özelliği ile,bu sözdizimi yukarıdakinden daha iyi ve daha net hale gelir.Ağacın her seviyesi için operatör?.eklemek yerine kullanabilirsiniz &&.İsteğe bağlı zincirleme?.değerlendirme ve döner durur undefinedparçası önce,eğer?.bir undefinedya da null.", "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 315, DateTimeKind.Local).AddTicks(2523), new DateTime(2021, 8, 25, 12, 23, 53, 315, DateTimeKind.Local).AddTicks(2521), true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 315, DateTimeKind.Local).AddTicks(2524), "JavaScript ES2020 Yenilikleri", "Nadir Korkut", "JavaScript ES2020 Yenilikleri", "JavaScript, JavaScript ES2020", "Default.jpg", "JavaScript ES2020 Yenilikleri", 1, 14 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 321, DateTimeKind.Local).AddTicks(1671), true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 321, DateTimeKind.Local).AddTicks(1684), "C# Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 2, 2, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 321, DateTimeKind.Local).AddTicks(1698), true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 321, DateTimeKind.Local).AddTicks(1700), "C++ Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 3, 3, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 321, DateTimeKind.Local).AddTicks(1704), true, false, "InitialCreate", new DateTime(2021, 8, 25, 12, 23, 53, 321, DateTimeKind.Local).AddTicks(1705), "JavaScript Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
