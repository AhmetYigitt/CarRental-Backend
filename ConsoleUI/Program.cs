using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            int choose;
            bool temp = true;
            while(temp){

                Console.WriteLine("----------MENU----------");
                Console.WriteLine("1)Araba Ekleme\n2)Araba Silme\n3)Araba Güncelleme\n4)Tüm Arabaları Gösterme\n5)Arabaları Marka Id'sine Göre Listeleme" +
                    "\n6)Arabaları Renk Id'sine Göre Listeleme\n7)Tüm Renkleri Görüntüleme\n8)Renk Ekleme\n9)Renk Güncelleme\n" +
                    "10)Tüm Markaları Görüntüleme\n11)Marka Ekleme\n12)Marka Güncelleme\n13)Çıkış");

                Console.Write("Seçiminiz: ");
                choose = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                switch (choose)
                {
                    case 1:
                        MyAddOperation(carManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        MyDeleteOperation(carManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        MyUpdateOperation(carManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        MyListOperation(carManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        MyGetCarsByBrandIdOperation(carManager, brandManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        MyGetCarsByColorIdOperation(carManager, colorManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        MyColorListOperation(colorManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 8:
                        MyColorAddOperation(colorManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 9:
                        MyColorListOperation(colorManager);
                        MyColorUpdateOperation(colorManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 10:
                        MyBrandListOperation(brandManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 11:
                        MyBrandAddOperation(brandManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 12:
                        MyBrandListOperation(brandManager);
                        MyBrandUpdateOperation(brandManager);
                        Console.WriteLine("\nMenüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 13:
                        Console.WriteLine("Sistemden Çıkış Yaptınız");
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yaptınız Menüye Dönmek İçin Enter'a Basınız");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        private static void MyBrandUpdateOperation(BrandManager brandManager)
        {
            Console.WriteLine("Güncellemek İstediğiniz Markanın Id Ve Adını Giriniz");
            Console.Write("Id: "); int Id = int.Parse(Console.ReadLine());
            Console.Write("Adı: "); string brandName = Console.ReadLine();
            brandManager.Update(new Brand { BrandId = Id, BrandName = brandName });
        }

        private static void MyBrandAddOperation(BrandManager brandManager)
        {
            Console.Write("Eklemek İstediğiniz Markayı Giriniz: ");
            string addedBrand = Console.ReadLine();
            brandManager.Add(new Brand { BrandName = addedBrand });
        }

        private static void MyBrandListOperation(BrandManager brandManager)
        {
            Console.WriteLine("Id  Marka Adı\n-------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0}   {1}", brand.BrandId, brand.BrandName);
            }
        }

        private static void MyColorUpdateOperation(ColorManager colorManager)
        {
            Console.WriteLine("Güncellemek İstediğiniz Rengin Id Ve Adını Giriniz");
            Console.Write("Id: "); int Id = int.Parse(Console.ReadLine());
            Console.Write("Adı: "); string colorName = Console.ReadLine();
            colorManager.Update(new Color { ColorId = Id, ColorName = colorName });
        }

        private static void MyColorAddOperation(ColorManager colorManager)
        {
            Console.Write("Eklemek İstediğiniz Rengi Giriniz: ");
            string addedColor = Console.ReadLine();
            colorManager.Add(new Color { ColorName = addedColor });
        }

        private static void MyColorListOperation(ColorManager colorManager)
        {
            Console.WriteLine("Id   Renk\n-------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0}   {1}", color.ColorId, color.ColorName);
            }
        }

        private static void MyGetCarsByColorIdOperation(CarManager carManager, ColorManager colorManager)
        {
            Console.WriteLine("Id   Renk\n-------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0}   {1}", color.ColorId, color.ColorName);
            }
            Console.Write("İstediğiniz Renkteki Araçları Görmek  İçin Yukarıdan Renk Id Seçiniz: "); int Id = int.Parse(Console.ReadLine());
            foreach (var car in carManager.GetCarsByBrandId(Id))
            {
                Console.WriteLine("\nAraba Özelliği: {0}\nAraba Çıkış Yılı: {1}\nAraba Fiyatı: {2}", car.Description, car.ModelYear, car.DailyPrice);
            }
        }

        private static void MyGetCarsByBrandIdOperation(CarManager carManager, BrandManager brandManager)
        {
            Console.WriteLine("Id  Marka Adı\n-------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0}   {1}", brand.BrandId, brand.BrandName);
            }
            Console.Write("İstediğiniz Markadaki Araçları Görmek  İçin Yukarıdan Marka Id Seçiniz: "); int Id = int.Parse(Console.ReadLine());
            foreach (var car in carManager.GetCarsByBrandId(Id))
            {
                Console.WriteLine("\nAraba Özelliği: {0}\nAraba Çıkış Yılı: {1}\nAraba Fiyatı: {2}", car.Description, car.ModelYear, car.DailyPrice);
            }
        }

        private static void MyUpdateOperation(CarManager carManager)
        {
            Console.Write("Arabanın Id: "); int Id = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Marka Id: "); int brandId = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Color Id: "); int colorId = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Çıkış Tarihi: "); int modelYear = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Fiyatı: "); decimal dailyPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Arabaının Tanımı: "); string description = Console.ReadLine();

            carManager.Update(new Car
            {
                CarId = Id,
                BrandId = brandId,
                ColorId = colorId,
                DailyPrice = dailyPrice,
                Description = description,
                ModelYear = modelYear,
            });
        }

        private static void MyListOperation(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("\nAraba Özelliği: {0}\nAraba Çıkış Yılı: {1}\nAraba Fiyatı: {2}", car.Description, car.ModelYear, car.DailyPrice);
            }
        }

        private static void MyDeleteOperation(CarManager carManager)
        {
            Console.WriteLine("Id  Araba\n-------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}   {1}", car.CarId, car.Description);
            }
            Console.Write("Silmek İstediğiniz Arabanın Id: "); int deletedCarId = int.Parse(Console.ReadLine());
            carManager.Delete(new Car { CarId = deletedCarId });
        }

        private static void MyAddOperation(CarManager carManager)
        {
            Console.Write("Arabanın Marka Id: "); int brandId = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Color Id: "); int colorId = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Çıkış Tarihi: "); int modelYear = int.Parse(Console.ReadLine());
            Console.Write("Arabanın Fiyatı: "); decimal dailyPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Arabaının Tanımı: "); string description = Console.ReadLine();

            carManager.Add(new Car {BrandId = brandId, ColorId = colorId, DailyPrice = dailyPrice, ModelYear = modelYear, Description = description });
        }
    }
}
