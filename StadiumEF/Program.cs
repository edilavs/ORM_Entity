using StadiumEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StadiumEF
{
    class Program
    {
        static void Main(string[] args)
        {
            StadiumDbContext dbContext = new StadiumDbContext();

            bool check = true;
            string answer = "";
            string stadiumName = "";
            string hourPriceStr = "";
            decimal hourPrice;
            string capacityStr;
            int capacity;
            string fullName = "";
            string email = ""; 
            string startDateStr;
            DateTime startDate;
            string endDateStr;
            DateTime endDate;

            while (check)
            {
                Console.WriteLine("---MENU---");
                Console.WriteLine("1.Stadion elave et" +
                    "\n2.Stadionlari goster" +
                    "\n3.Verilmish id-li stadionu goster" +
                    "\n4.Verilmish id-li stadionu sil" +
                    "\n5.User elave et"+
                    "\n6.Userleri goster"+
                    "\n7.Rezervasiyalari goster"+
                    "\n8.Rezervasiya yarat"+
                    "\n9.Verilmiş id-li stadionun rezervasiyalarını goster"+
                    "\n0.Proqrami bitir\n");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Stadion adi daxil edin:");
                            stadiumName = Console.ReadLine();
                        } while (String.IsNullOrEmpty(stadiumName));
                        do
                        {
                            Console.WriteLine("Stadionun limitini daxil edin: ");
                            capacityStr = Console.ReadLine();
                        } while (!int.TryParse(capacityStr, out capacity));
                        do
                        {
                            Console.WriteLine("Stadionun saatliq qiymetini:");
                            hourPriceStr = Console.ReadLine();
                        } while (!decimal.TryParse(hourPriceStr, out hourPrice));

                        Stadium stadium = new Stadium
                        {
                            Name = stadiumName,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };

                        dbContext.Stadiums.Add(stadium);
                        dbContext.SaveChanges();
                        break;

                    case "2":
                        List<Stadium> Stadiums = dbContext.Stadiums.ToList();
                        foreach (var std in Stadiums)
                        {
                            Console.WriteLine($"{std.Id}-{std.Name}-{std.HourPrice}-{std.Capacity}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Axtardiginiz Id-i daxil edin: ");
                        int idInsert = Convert.ToInt32(Console.ReadLine());
                        var st = dbContext.Stadiums.Find(idInsert);
                        Console.WriteLine($"{st.Id}-{st.Name}-{st.Capacity}-{st.HourPrice}");
                        break;

                    case "4":
                        Console.WriteLine("Silinecek Id-i daxil edin: ");
                        int idRemoved = Convert.ToInt32(Console.ReadLine());
                        var data = dbContext.Stadiums.Find(idRemoved);
                        if (data != null)
                        {
                            dbContext.Stadiums.Remove(data);
                        }
                        dbContext.SaveChanges();
                        break;
                    case "5":
                        Console.WriteLine("Elave olunacaq useri fullname-ni daxil edin:");
                        fullName = Console.ReadLine();
                        Console.WriteLine("Email daxil edin:");
                        email = Console.ReadLine();
                        User user = new User()
                        {
                            FullName = fullName ,
                            Email=email
                        };

                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        break;

                    case "6":
                        List<User> allUsers = dbContext.Users.ToList();
                        foreach (var usr in allUsers)
                        {
                            Console.WriteLine($"{usr.Id}-{usr.FullName}-{usr.Email}" );
                        }
                        break;

                    case "7":
                        List<Reservation> allReservations = dbContext.Reservations.ToList();
                        foreach (var reserv in allReservations)
                        {
                            Console.WriteLine($"{reserv.Id}+{reserv.StartDate}+{reserv.EndDate}");
                        }

                        break;

                    case "8":
                        Console.WriteLine("StadiumId daxil edin");
                        int stdId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("UserId daxil edin");
                        int usrId = Convert.ToInt32(Console.ReadLine());

                        do
                        {
                            Console.WriteLine("Rezervasiyanin baslama vaxtini daxil edin:");
                            startDateStr = Console.ReadLine();
                        } while (!DateTime.TryParse(startDateStr, out startDate));
                        do
                        {
                            Console.WriteLine("Rezervasiyanin bitme vaxtini daxil edin:");
                            endDateStr = Console.ReadLine();
                        } while (!DateTime.TryParse(endDateStr, out endDate));


                        Reservation reservation = new Reservation()
                        {
                            UserId = usrId,
                            StadiumId = stdId,
                            StartDate = startDate,
                            EndDate = endDate
                        };

                        dbContext.Reservations.Add(reservation);
                        dbContext.SaveChanges();

                        break;
                    case "9":
                        Console.WriteLine("StadioumId daxil edin:");
                        int stdIdForReserv = Convert.ToInt32(Console.ReadLine());
                        List<Reservation> stdIdReservation = dbContext.Reservations.Where(x => x.StadiumId == stdIdForReserv).ToList();
                        foreach (var item in stdIdReservation)
                        {
                            Console.WriteLine(item.StadiumId +" "+item.StartDate+" "+item.EndDate);
                        }
                        break;

                    case "0":
                        Console.WriteLine("Proqram bitdi.");
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Bele secim yoxdur,duzgun daxil edin.");
                        break;
                }


            }
            
            
        }
    }
}
