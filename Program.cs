using AutoSale.Model;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace AutoSale
{
    public class Program
    {
        public static Connect conn = new Connect();
        public static List<Car> cars = new List<Car>(); 
        public static void feladat1() 
        {
            string sql = "SELECT * from cars";
            conn.Connection.Open();

            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            do
            {
                Car car = new Car();
                car.Id = dr.GetInt32(0);
                car.Brand = dr.GetString(1);
                car.Type = dr.GetString(2);
                car.License = dr.GetString(3);
                car.Date = dr.GetInt32(4);
                cars.Add(car);  

            } while (dr.Read());



            conn.Connection.Close();
        }

        public static void feladat2() 
        {
            string marka, tipus, azon;
            int ev;

            Console.WriteLine("Kerem az auto markajat");
            marka = Console.ReadLine();

            Console.WriteLine("Kerem az auto tipusat");
            tipus = Console.ReadLine();

            Console.WriteLine("Kerem az auto azonositojat");
            azon = Console.ReadLine();

            Console.WriteLine("Kerem az auto gyartasi evet");
            ev = Convert.ToInt32(Console.ReadLine());

            string sql = $"INSERT INTO `cars`(`Brand`, `Type`, `License`, `Date`) VALUES('{marka}', '{tipus}', '{azon}', '{ev}')";
            conn.Connection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn.Connection);
            mySqlCommand.ExecuteNonQuery();

            conn.Connection.Close();
        }
        public static void feladat3()
        {
            int ev,id;
            Console.WriteLine("Adja meg melyik autot irjam at");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Adja meg az auto gyartasi evet");
            ev = Convert.ToInt32(Console.ReadLine());


            conn.Connection.Open();

            string sql = $"UPDATE `cars` SET `Date`='{ev}'  WHERE `Id` = {id}";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn.Connection);
            mySqlCommand.ExecuteNonQuery();

            conn.Connection.Close();
        }
        public static void feladat4()
        {
            int id;

            Console.WriteLine("Adja meg melyik sort toroljem ki");
            id = Convert.ToInt32(Console.ReadLine());

            conn.Connection.Open();
            string sql = $"DELETE FROM `cars` WHERE `Id` = {id}";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn.Connection);
            mySqlCommand.ExecuteNonQuery();
            conn.Connection.Close();
        }
        static void Main(string[] args)
        {
            feladat1();
            foreach (var item in cars)
            {
                Console.WriteLine($"Marka: {item.Brand}, Azonosito: {item.License}");
            }
            feladat2();
            feladat3();
            feladat4();
            Console.ReadLine();
        }
    }
}
