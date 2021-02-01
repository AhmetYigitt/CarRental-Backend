using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //Ekleme Testi
            carManager.Add(new Car { CarId = 7, BrandId = 2, ColorId = 3, DailyPrice = 450500, Description = "Yeni Eklenen Araba", ModelYear = 2021 });
            //Getirme Testi
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Tarifi: " + car.Description + "\nAraba Fiyatı: " + car.DailyPrice +
                    "\nArabanın Çıkış Yılı: " + car.ModelYear + "\n");
            }




            Console.WriteLine("\n\n\n");
            //Güncelleme Testi
            carManager.Update(new Car { CarId = 7, BrandId = 2, ColorId = 3, DailyPrice = 450500, Description = "Yeni Eklenen Araba GÜNCELLENDİ!!!!!!!", ModelYear = 2021 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Tarifi: " + car.Description + "\nAraba Fiyatı: " + car.DailyPrice +
                    "\nArabanın Çıkış Yılı: " + car.ModelYear + "\n");
            }



            Console.WriteLine( "\n\n\n" );
            //Silme Testi
            carManager.Delete(new Car { CarId = 7, BrandId = 2, ColorId = 3, DailyPrice = 450500, Description = "Yeni Eklenen Araba GÜNCELLENDİ!!!!!!!", ModelYear = 2021 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araba Tarifi: " + car.Description + "\nAraba Fiyatı: " + car.DailyPrice +
                    "\nArabanın Çıkış Yılı: " + car.ModelYear + "\n");
            }

            

            Console.WriteLine("\n\n\n");

            //Id ye göre getirme testi
            foreach (var car in carManager.GetByColorId(3)) //3 numaralı renk id sine göre arabalrı getirir
            {
                Console.WriteLine("Araba Tarifi: " + car.Description + "\nAraba Fiyatı: " + car.DailyPrice +
                    "\nArabanın Çıkış Yılı: " + car.ModelYear + "\n");
            }
        }
    }
}
