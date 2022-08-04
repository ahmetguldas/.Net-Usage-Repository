using Microsoft.EntityFrameworkCore;

namespace CORE_Usage_Repository.Models
{
    public class ProjectContext : DbContext
    {
        /*
         * ProductRepository icerisinde ki veriler bagimliliktan dolayi sadece oradaki veriler geliyor 
         * Ancak ProductRepository nin icerisindeki veriler gelmesinde benim veritabanimdaki veriler gelsin diyoruz.
         * EntityFramework ile calismamiz gerekiyor benim verdigim connectionstring ile baglanacaksin ve daha sonrasinda da connectionstring ile baglandigin veritabanini getireceksin yada insert edeceksin diyorum bunu yapabilmek icinde bir veritabani olusturmamiz gerekiyor onun icinde context class i gerekiyor.
         * 
         */

        /*
         * Bu class in icinde connectionstring i yazabiliyoruz yada connectionstring neredeyse orayi referans verebiliyoruz mesele connectionstring i git base den cek diyebiliyoruz.
         * Yada veritabaninda olusturulacak tablolari isaret edebiliyoruz.
         * Models klasorunun icerisinde Product entity sinden Product tablosu olussun diyebiliyoruz mesela yada on tane class imiz olsun onlarin icerisinde 5 inden olussun 5 inden olusmasin diyebiliyoruz.
         * Burada yazacagimiz DbSet satirlari tablolarimizi isaret ediyor.
         * 
         * DbContext  class indan inherit almamiz gerekiyor.
         * inherit alabilmemiz icin entityframeworkcore package ini entegre etmemiz gerekiyor.
         */

        //burada options i al base e gonder demis oluyoruz.
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)// bu base program.cs oluyor net 5 de startup.cs class i oluyor.
        {
            // Connection String i Program.cs de yada Startup da tanimlayacagiz.
        }
        public DbSet<Product> Products { get; set; } //Products ismi veritabanindaki  tablo ismi olmayacak buradaki iceriden ulasacagimiz isim bu benim veritabanimdaki tablo adimi olusturacak diye birsey yok

    }
}
