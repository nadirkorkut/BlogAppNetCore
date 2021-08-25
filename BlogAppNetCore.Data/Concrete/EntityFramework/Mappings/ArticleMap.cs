using BlogAppNetCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppNetCore.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles");

            builder.HasData(new Article
            {
                Id = 1,
                CategoryId = 1,
                Title = "C# 9.0 Yenilikleri",
                Content = "Geçtiğimiz haftalarda pandemi nedeniyle online düzenlenen Microsoft Build 2020 etkinliğinde birçok yenilik duyurusu yapıldı. Biz yazılım geliştiricilerin en ilgisini çekenlerden biri belki de C# 9 ile hangi yeniliklerin geleceğiydi. Build etkinliğinde duyurulan yeni C# dil özelliklerinden bazılarını bu makalede ele alıp inceleyeceğiz. Elbette gelecek olan yenilikler bu makalede anlatılanlarla sınırlı değil ve bazı yeniliklerin eklenip çıkarılabileceğini biliyoruz. Şunu hatırlatmakta fayda var; bu yazı Haziran 2020’de yazıldı ve henüz resmi bir C# 9 sürümü çıkmadı. Yazıda sadece Build etkinliğinde duyurulan ve yakın gelecekte karşımıza çıkması kuvvetle muhtemel C# 9 dil özelliklerinden bazılarına göz atacağız.Yeni gelecek özellikleri şu başlıklar altında inceleyelim:Target-type newBildiğiniz üzere sınıflar referans tiplerdir.Bir sınıfın örneğini almak için new operatörü kullanırız.C# 9‘dan önce bir sınıfın örneğini almak için aşağıdaki tanımlamayı yapmamız gerekiyordu. List customerNames = new List(); C# 9 ile beraber artık new operatörünü kullandıktan sonra bir tip belirtmemize gerek kalmıyor. Aşağıdaki tanımlama ve yukarıdaki tanımlama aslında aynı şeyi ifade etmekte. var keyword’ünün eşittir operatörünün sağ tarafına geçmiş haline benzetebiliriz sanırım bu kullanımı.List<string> customerNames = new();",
                Thumbnail = "Default.jpg",
                SeoDescription = "C# 9.0 Yenilikleri",
                SeoTags = "C#, C# 9",
                SeoAuthor = "Nadir Korkut",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# 9.0 Yenilikleri",
                UserId = 1,
                ViewsCount = 100,
                CommentCount = 1

            },
            new Article
            {
                Id = 2,
                CategoryId = 2,
                Title = "C++ 20 İle Gelen Yenilikler",
                Content = "C++ dilinde kod geliştiren yazılımcılar, dilin 1998 yılında standartlaşmasının ardından, 2011 yılında C++11 standardı çıkana kadar uzunca bir süre kullandıkları dilde bir değişim olmadan yazılımlarını geliştirmeye devam etmişlerdi. Bu zaman zarfında gelişen ve değişen dünyadaki problemlere çözüm bulmak, C++ dilinde gittikçe zorlaşmış, üçüncü parti kütüphane desteği olmadan güncel problemlere çözüm sunamayan eski kalmış bir dil haline gelmişti. C++ geliştiricileri, Boost gibi kütüphaneler olmadan diğer yazılım dillerinin sağladığı özellikler ile yarışamaz bir durumdaydılar.Uzun bir aranın ardından yayınlanan C++11 standardı,mevcut dile birçok değişiklik getirmiş; C++ dilini adeta yeni bir dil haline getirmişti.Lambda expressions, auto, constexpr, future gibi yeni gelen özellikler ile bugün Modern C++olarak adlandırılan yeni bir dönem başlamış ve C++, diğer yazılım dilleri olan yarışında kendine tekrar üst sıralarda yer bulabilmişti.C++11 ile başlayan ve her 3 yılda bir güncellenen standart, geleneğini C++20 güncellemesi ile devam ettiriyor. C++14 ve C++17 standartları, C++11 ile gelen özelliklerin güçlendirilmesi, daha çok derleyici zamanında kod çalıştırılması gibi yenilikler getirirken, dile çok fazla veya çok büyük yenilikler getirmemişlerdi.Ancak, C++20 standardı ile birlikte gelen 4 büyük yenilik ve birçok yeni iyileştirme sayesinde C++dili, diğer diller ile olan rekabetinde yeni bir sayfa daha açacağa benziyor.Büyük dörtlü olarak ifade edilen, Concepts, Ranges, Coroutines ve Modules özelliklerinin dile eklenmesiyle birlikte, C++ dünyasını, tıpkı C++11 güncellemesi gibi büyük değişiklikler bekliyor.",
                Thumbnail = "Default.jpg",
                SeoDescription = "C++ 20 İle Gelen Yenilikler",
                SeoTags = "C++, C++ 20",
                SeoAuthor = "Nadir Korkut",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ 20 İle Gelen Yenilikler",
                UserId = 1,
                ViewsCount = 158,
                CommentCount = 1
            },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "JavaScript ES2020 Yenilikleri",
                Content = "Ne haber millet! JavaScript, harika bir programlama dili gelişiyor. ECMAScript 2020 (yaygın olarak ES2020 olarak bilinir) özelliklerinin artık TC39 komitesi tarafından tamamlandığına dair iyi haberi duymaktan mutluluk duyuyoruz.Yeni JavaScript'teki bazı ilginç özellikleri görelim.BigInt BigInt olan yerleşik bir daha büyük bir bütün sayıları temsil etmek için bir yol sağlar nesne POW(2, 53) - 1, JavaScript güvenilir bir şekilde temsil en büyük sayı olan Numarası ilkel ve ile temsil edilen Number.MAX_SAFE_INTEGER sabit.A BigInt,nbir tamsayı değişmezinin sonuna eklenerek veya işlevi çağırarak oluşturulur BigInt(). Bununla birlikte, BigInt kullanarak çok büyük sayıları temsil edebiliriz, BigInt türü normal sayılarla kullanıldığında bazı sınırlamalar vardır. Yerleşik Mathnesnedeki yöntemlerle kullanılamaz ve Numberişlemlerde örnekleri ile karıştırılamaz . Aynı tip ile kullanılmaları gerekir.BigInt,IEEE754 standartlarıyla geriye dönük olarak uyumlu değildir çünkü bu sayı sistemi çok büyük sayıları destekleyemez.İsteğe Bağlı ZincirlemeBu,JavaScript kodunuzun daha net görünmesini sağlayan heyecan verici özelliklerden biridir.İsteğe bağlı zincirleme?., bir ara özellik mevcut olmasa bile,yuvalanmış nesne özelliklerine erişmenin hatasız bir yoludur.Kulağa ilginç geliyor mu ? Bu özellik,derinlemesine iç içe geçmiş nesnenin her seviyesinde özellik varlığını kontrol etmek için çok sayıda kod satırı yazmayı kaydetmelidir.Bir nesnenin bir özelliğine ulaşmak istediğinizde, genellikle &&nesne boş veya tanımsız olduğunda hata almaktan kaçınmak için operatörü kullanabilirsiniz .Bu yeni JavaScript özelliği ile,bu sözdizimi yukarıdakinden daha iyi ve daha net hale gelir.Ağacın her seviyesi için operatör?.eklemek yerine kullanabilirsiniz &&.İsteğe bağlı zincirleme?.değerlendirme ve döner durur undefinedparçası önce,eğer?.bir undefinedya da null.",
                Thumbnail = "Default.jpg",
                SeoDescription = "JavaScript ES2020 Yenilikleri",
                SeoTags = "JavaScript, JavaScript ES2020",
                SeoAuthor = "Nadir Korkut",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "JavaScript ES2020 Yenilikleri",
                UserId = 1,
                ViewsCount = 14,
                CommentCount = 1
            }
            );
        }
    }
}
