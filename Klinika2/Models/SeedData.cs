﻿using System;
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
                // Look for any movies.
                if (context.Patients.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patients.AddRange(
                    new Patients
                    {
                        ImePrezime = "When Harry Met Sally",
                        DatumRodjenja = DateTime.Parse("1989-2-12"),
                        Spol = PatientGenderEnum.Muski,
                        Adresa = "Zije Dizdarevica",
                        
                    },

                    new Patients
                    {
                        ImePrezime = "Ghostbusters ",
                        DatumRodjenja = DateTime.Parse("1984-3-13"),
                        Spol = PatientGenderEnum.Zenski,
                        Adresa = "Zeljeznicka",

                    },

                    new Patients
                    {
                        ImePrezime = "Ghostbusters 2",
                        DatumRodjenja = DateTime.Parse("1986-2-23"),
                        Spol = PatientGenderEnum.Zenski,
                        Adresa = "Stupska 12 B",
                    },

                    new Patients
                    {
                        ImePrezime = "Rio Bravo",
                        DatumRodjenja = DateTime.Parse("1959-4-15"),
                        Spol = PatientGenderEnum.Nepoznato,
                        Adresa = "Zmaja od Bosne 6",
                    }
                );; ;
                context.SaveChanges();
            }
        }
    }
}

