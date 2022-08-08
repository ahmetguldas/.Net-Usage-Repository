using Microsoft.EntityFrameworkCore;

namespace CORE_Usage_Repository.Models
{
    public static class SeedData
    {
        /* belli verileri olusturmamiz icin olusturdugumuz seeddata class i 
         * using anahtar kelimesi herhangi bir islem yaptiktan sonra garbagecollection beklemeden islem yapsin diyoruz.
         * using blogu bittiginde temizlenmesini soyluyoruz.
         * 
         */
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                ProjectContext context = serviceScope.ServiceProvider.GetService<ProjectContext>();

                context.Database.Migrate();//migrate aciklamasini oku

                if (!context.Products.Any())//tabloda herhangi veri yoksa asagidakileri ekleyecek
                {
                    context.Products.AddRange
                        ( //buraya yeni veri eklersek tekrar calistirirsak en son veriyi eklemez veritabaninindaki verileri silip tekrar calistirmamiz gerekir burada veritabaninda herhangi birsey yok ise ekle dedigimizden dolayi
                            new Product() { ProductName = "Salatalik", Description = "Taze dalindan sofraya", Category = "Sebzeler", Price = 10.99M },//id kisimlarini kendisi otomatik ekleyeceginden sildik. id kisimlari varsa runtime hatasi verir.
                            new Product() { ProductName = "Kiraz", Description = "Afyon kirazi", Category = "Meyveler", Price = 14.99M },
                            new Product() { ProductName = "Elma", Description = "Amasya", Category = "Meyveler", Price = 9.99M },
                            new Product() { ProductName = "Domates", Description = "Diyarbakir", Category = "Sebzeler", Price = 18.99M }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
