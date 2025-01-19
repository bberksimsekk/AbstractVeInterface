using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVeInterFaceKavrami
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Insan sınıfının  nesnesini oluşturalım
            Insan ins = new Insan("Murtaza", "Şuayipoğlu");
            ins.Yazdir();

            //Personel sınıfının nesnesini oluşturalım
            Personel prs = new Personel("Salih", "Edepoğlu", "Bilgisayar İşletmeni");
            prs.Yazdir();

            //Abstract sınıfların nesnesi oluşturulamaz.
            //Bu sınıfların amacı kalıtımda "base class" olarak kullanılmaktadır.
            //Arac arac = new Arac(); //Hata verir.

            //Binek Aracın nesnesini oluşturalım
            BinekArac ba = new BinekArac("Audi", "Q8", "26 ESES 26");
            ba.Yazdir();

            //Abstract Sınıflar ;
            //1 - Constructor içerebilir.
            //2 - Static Üyeler içerebilir.
            //3 - Farklı tiplerde Access Modifier (Erişim Belirleyicisi)(public, private) içerebilir.
            //4 - Sınıfın ait olduğu kimliği belirlemek amacıyla kullanılır.
            //5 - Bir sınıf sadece bir adet abstract class Implament edebilir.
            //6 - Abstract sınıftan türetilen sınıf elemanlarının kısmi kullanımı mümkündür.


            //Interfaceler ;
            //1 - Constructor içeremez.
            //2 - Static Üyeler içeremez.
            //3 - Farklı tiplerde Access Modifier (Erişim Belirleyicisi)(public, private) içeremez.
            //4 - Sınıfın yapabileceği kabiliyetleri belirtmek için kullanılır.
            //5 - Bir sınıf birden fazla Interface Implament edebilir.
            //6 - Interface sadece metot imzalarını barındırabilir. İçerikleri bulunmaz.
            //7 - Türetilen sınıflar tüm Interface elemanlarını içermek zorundadır.
        }
    }

    public class Insan 
    { 
        public string Isim { get; set; }
        public string Soyisim { get; set; }

        public Insan() { }

        public Insan(string isim, string soyisim)
        {
            Isim = isim;
            Soyisim = soyisim;
        }

        public virtual void Yazdir()
        {
            Console.WriteLine($"Isim = {Isim}\nSoyisim = {Soyisim}");
        }
    }

    public class Personel : Insan
    {
        public string Departman { get; set; }

        public Personel() { }

        public Personel(string isim, string soyisim, string departman)
            : base(isim, soyisim) //Base sınıfının constructor'una parametre gönderdik
        {
            Departman = departman;
        }

        public override void Yazdir() 
        {
            base.Yazdir();
            Console.WriteLine("Departman = " + Departman);
        }
    }

    public abstract class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        public Arac() { }

        public Arac(string marka, string model) 
        {
            Marka = marka;
            Model = model;
        }

        public virtual void Yazdir() 
        {
            Console.WriteLine($"Marka = {Marka}\nModel = {Model}");
        }
    }

    public class BinekArac : Arac
    {
        public string Plaka { get; set; }

        public BinekArac() { }

        public BinekArac(string marka, string model, string plaka)
            :base(marka, model)
        {
            Plaka = plaka;
        }

        public override void Yazdir()
        {
            base.Yazdir();
            Console.WriteLine("Plaka = " + Plaka);
        }
    }

    public interface IEsya 
    {
        void Yazdir(string marka, string model);
    }
    public class BeyazEsya : IEsya
    {
        public void Yazdir(string marka, string model)
        {
            Console.WriteLine($"Marka = {marka}\nModel = {model}");
        }
    }

    public interface IModel
    {
        //IModel(string connectionstring); //Consturctor Tanımlanamaz.
        bool Ekle(object model);
        List<object> Listele();
        object Getir(int id);
        bool Guncelle(object model);
        void Sil(int id);
    }
    public interface IBaglanti 
    { 
        SqlConnection con { set; }
        SqlCommand cmd { set; }
    }

    public class KategoriModel : IModel, IBaglanti
    {
        public SqlConnection con { set => new SqlConnection("Baglantı"); }
        public SqlCommand cmd { set => new SqlCommand(); }

        public bool Ekle(object model)
        {
            throw new NotImplementedException();
        }

        public object Getir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guncelle(object model)
        {
            throw new NotImplementedException();
        }

        public List<object> Listele()
        {
            throw new NotImplementedException();
        }

        public void Sil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
