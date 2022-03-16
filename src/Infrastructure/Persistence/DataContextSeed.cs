using Domain.Entities;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class DataContextSeed
    {
        public static async Task SeedSampleDataAsync(DataContext ctx)
        {
            if(!ctx.Categories.Any())
            {
                var b = Category.Of("Compacto Com Ar", "B", 4.5);
                ctx.Categories.Add(b);

                var c = Category.Of("Econômico Com Ar", "C", 5.2);
                ctx.Categories.Add(c);

                var f = Category.Of("Intermediário", "F", 5.57);
                ctx.Categories.Add(f);

                var l = Category.Of("Executivo", "L", 16.21);
                ctx.Categories.Add(l);
                
                var sv = Category.Of("Suv Elite A Diesel (XFAD)", "SV", 50);
                ctx.Categories.Add(sv);

                var re = Brand.Of("RENAULT");
                ctx.Brands.Add(re);

                var fiat = Brand.Of("FIAT");
                ctx.Brands.Add(fiat);

                var rdy = Brand.Of("HYUNDAI");
                ctx.Brands.Add(rdy);

                var ford = Brand.Of("FORD");
                ctx.Brands.Add(ford);

                var chev = Brand.Of("CHEVROLET");
                ctx.Brands.Add(chev);

                var vw = Brand.Of("VOLKSWAGEN");
                ctx.Brands.Add(vw);

                var toyota = Brand.Of("TOYOTA");
                ctx.Brands.Add(toyota);

                var mitsubishi = Brand.Of("MITSUBISHI");
                ctx.Brands.Add(mitsubishi);

                var kwid = Model.Of("Kwid 1.0", FuelType.FLEX, TrunkCarSize.SMALL, "https://www.localiza.com/brasil-site/geral/Frota/KWID.png", b, re);
                ctx.Models.Add(kwid);

                var mobi = Model.Of("Mobi 1.0", FuelType.FLEX, TrunkCarSize.SMALL, "https://www.localiza.com/brasil-site/geral/Frota/MOBI.png", b, fiat);
                ctx.Models.Add(mobi);

                var uno = Model.Of("Uno 1.0", FuelType.FLEX, TrunkCarSize.SMALL, "https://www.localiza.com/brasil-site/geral/Frota/NUNB.png", b, fiat);
                ctx.Models.Add(uno);

                var gol = Model.Of("Gol 1.0", FuelType.FLEX, TrunkCarSize.MEDIUM, "https://www.localiza.com/brasil-site/geral/Frota/GOLC.png", c, vw);
                ctx.Models.Add(gol);

                var ka = Model.Of("Novo Ford Ka 1.0", FuelType.FLEX, TrunkCarSize.MEDIUM, "https://www.localiza.com/brasil-site/geral/Frota/KACR.png", c, ford);
                ctx.Models.Add(ka);

                var gol16 = Model.Of("Gol 1.6", FuelType.FLEX, TrunkCarSize.MEDIUM, "https://www.localiza.com/brasil-site/geral/Frota/GOLL.png", f, vw);
                ctx.Models.Add(gol16);

                var sandero = Model.Of("Sandero 1.6", FuelType.FLEX, TrunkCarSize.MEDIUM, "https://www.localiza.com/brasil-site/geral/Frota/SAND.png", f, re);
                ctx.Models.Add(sandero);

                var cruze = Model.Of("GM Cruze", FuelType.FLEX, TrunkCarSize.LARGE, "https://www.localiza.com/brasil-site/geral/Frota/CLTZ.png", l, chev);
                ctx.Models.Add(cruze);

                var jetta = Model.Of("Jetta", FuelType.FLEX, TrunkCarSize.LARGE, "https://www.localiza.com/brasil-site/geral/Frota/JETA.png", l, vw);
                ctx.Models.Add(jetta);

                var corola = Model.Of("Corolla GLI", FuelType.FLEX, TrunkCarSize.LARGE, "https://www.localiza.com/brasil-site/geral/Frota/CORO.png", l, toyota);
                ctx.Models.Add(corola);
                
                var pajero = Model.Of("Pajero 2.4", FuelType.DIESEL, TrunkCarSize.LARGE, "https://www.localiza.com/brasil-site/geral/Frota/PJRS.png", sv, mitsubishi);
                ctx.Models.Add(pajero);

                var kwidCar = Car.Of(kwid, 2022, "PRATA", "HQO6R70");

                ctx.Cars.Add(kwidCar);
                ctx.Cars.Add(Car.Of(kwid, 2022, "BRANCO", "HQH2E76"));

                ctx.Cars.Add(Car.Of(mobi, 2022, "PRATA", "HGR6S50"));
                ctx.Cars.Add(Car.Of(mobi, 2022, "BRANCO", "MZX2C48"));

                ctx.Cars.Add(Car.Of(uno, 2022, "PRATA", "GQC3S05"));
                ctx.Cars.Add(Car.Of(uno, 2022, "BRANCO", "HRG9X69"));

                ctx.Cars.Add(Car.Of(gol, 2022, "PRATA", "NAM5A50"));
                ctx.Cars.Add(Car.Of(gol, 2022, "BRANCO", "MEES298"));

                ctx.Cars.Add(Car.Of(ka, 2022, "PRATA", "JTY3C92"));
                ctx.Cars.Add(Car.Of(ka, 2022, "BRANCO", "MTI3K33"));

                ctx.Cars.Add(Car.Of(gol16, 2022, "PRATA", "MWK8B59"));
                ctx.Cars.Add(Car.Of(gol16, 2022, "BRANCO", "MMN3L14"));

                ctx.Cars.Add(Car.Of(sandero, 2022, "PRATA", "JTR5G83"));
                ctx.Cars.Add(Car.Of(sandero, 2022, "BRANCO", "IAM6M12"));

                ctx.Cars.Add(Car.Of(cruze, 2022, "PRATA", "ISO2B77"));
                ctx.Cars.Add(Car.Of(cruze, 2022, "BRANCO", "MYN1S15"));

                ctx.Cars.Add(Car.Of(jetta, 2022, "PRATA", "HFJ9D21"));
                ctx.Cars.Add(Car.Of(jetta, 2022, "BRANCO", "LWJ6G82"));

                ctx.Cars.Add(Car.Of(corola, 2022, "PRATA", "MMY5G70"));
                ctx.Cars.Add(Car.Of(corola, 2022, "BRANCO", "HYZ0R34"));

                ctx.Cars.Add(Car.Of(pajero, 2022, "PRATA", "MNQ2G59"));
                ctx.Cars.Add(Car.Of(pajero, 2022, "BRANCO", "AZQ7T53"));

                var user = User.Of("12345678910", "123");
                ctx.Users.Add(user);

                var customer = Customer.Of("Erisson Costa", "12345678910", new DateOnly(1995, 1, 1), "59293-180", "Rua José Batista Da Silva", "127", null, "Natal", "RN", user);
                ctx.Customers.Add(customer);

                ctx.CheckIns.Add(CheckIn.Of(kwidCar, customer, 1, RentCarType.ACTIVE, DateTime.Now, DateTime.Now));
            }
            await ctx.SaveChangesAsync();
        }
    }
  
}
