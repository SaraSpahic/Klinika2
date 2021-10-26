using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klinika2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Klinika2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Klinika2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Klinika2Context>>()))
            {
                // Look for any patients.
                if (context.Patients.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patients.AddRange(
                    new Patients
                    {
                        ImePrezime = "Hana Klarić",
                        DatumRodjenja = DateTime.Parse("1991-02-23"),
                        Spol = PatientGenderEnum.Zenski,
                        BrojTelefona = "061-429-807"
                    },
                    new Patients
                    {
                        ImePrezime = "Neda Đurić",
                        DatumRodjenja = DateTime.Parse("1988-03-15"),
                        Spol = PatientGenderEnum.Zenski,
                        Adresa = "Zije Dizdarevića 31",
                        BrojTelefona = "061-663-040"
                    },

                    new Patients
                    {
                        ImePrezime = "Darija Topić",
                        DatumRodjenja = DateTime.Parse("1989-11-03"),
                        Spol = PatientGenderEnum.Zenski,
                        Adresa = "Tavcarjeva 68",

                    },

                    new Patients
                    {
                        ImePrezime = "Almir Filipović",
                        DatumRodjenja = DateTime.Parse("1947-03-30"),
                        Spol = PatientGenderEnum.Muski,
                        Adresa = "Letališka 82",
                        BrojTelefona = "060-595-906"
                    },

                    new Patients
                    {
                        ImePrezime = "Rio Bravo",
                        DatumRodjenja = DateTime.Parse("1951-4-15"),
                        Spol = PatientGenderEnum.Nepoznato,
                        Adresa = "Zmaja od Bosne 6",
                        BrojTelefona = "061-832-159"
                    },

                    new Patients
                    {
                        ImePrezime = "Dejan Klarić",
                        DatumRodjenja = DateTime.Parse("1947-04-03"),
                        Spol = PatientGenderEnum.Muski,
                        Adresa = "Kolodvorska 77",
                        BrojTelefona = "064-553-734"
                    }
                );

                context.Ljekar.AddRange(
                  new Ljekar
                  {
                      Ime = "Verica",
                      Prezime = "Poljak",
                      Titula = LjekarTitulaEnum.Specijalista,
                      Sifra = "421",
                  },

                  new Ljekar
                  {
                      Ime = "Željko",
                      Prezime = "Jerković",
                      Titula = LjekarTitulaEnum.Specijalista,
                      Sifra = "953",
                  },

                       new Ljekar
                       {
                           Ime = "Alma",
                           Prezime = "Šimić",
                           Titula = LjekarTitulaEnum.MedicinskaSestra,
                           Sifra = "245",
                       },

                            new Ljekar
                            {
                                Ime = "Jelena",
                                Prezime = "Petrović",
                                Titula = LjekarTitulaEnum.Specijalizant,
                                Sifra = "150",
                            },
                             new Ljekar
                             {
                                 Ime = "Damir",
                                 Prezime = "Bilić",
                                 Titula = LjekarTitulaEnum.Specijalizant,
                                 Sifra = "386",
                             }



                  )
                   ;

                context.SaveChanges();

                context.Prijem.AddRange(
                    new Prijem
                    {
                        DatumVrijeme = new DateTime(2021, 10, 1, 7, 30, 0),
                        PacijentId = context.Patients
                        .Where(b => b.ImePrezime == "Hana Klarić")
                        .FirstOrDefault()
                        .Id,
                        LjekarId = context.Ljekar
                        .Where(b => b.Sifra == "953")
                        .FirstOrDefault()
                        .Id,
                        Hitno = true,
                    },
                      new Prijem
                      {
                          DatumVrijeme = new DateTime(2021, 12, 5, 8, 30, 0),
                          PacijentId = context.Patients
                        .Where(b => b.ImePrezime == "Almir Filipović")
                        .FirstOrDefault()
                        .Id,
                          LjekarId = context.Ljekar
                        .Where(b => b.Sifra == "421")
                        .FirstOrDefault()
                        .Id,
                          Hitno = false,
                      }
                    );

                context.SaveChanges();

                context.Nalaz.AddRange(
                   new Nalaz
                   {
                       DatumVrijeme = new DateTime(2021, 10, 1, 7, 30, 0),
                       PrijemID = context.Prijem
                       .Where(b => b.Pacijent.ImePrezime == "Hana Klarić")
                       .FirstOrDefault()
                       .Id,
                       Opis = "Kontrolni CT toraksa proksimalnog abdomena ucinjen je Postkontrastno monofazno u bolesnice s npl. procesom donjeg plucnog renja desno. Sprovedena je kemoterapija te radioteraplja torakalnih kraljezaka.",
                   }
                   ) ;

                context.SaveChanges();
            }
        }
    }
}

