using System;
using System.Collections.Generic;

namespace Modul
{
    public class Program
    {

        static void Main(string[] args)
        {
            string id;
            int capasity;
            int currentAmount;
            JuiceType juice;
            Tank tank = null;

            Console.WriteLine("Passing tests....");

            //================ Test 1 =====================
            Console.WriteLine("\n===== Test 1: =====");
            id = "";
            capasity = 1000;

            try
            {
                tank = new Tank(id, capasity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 2 =====================
            Console.WriteLine("\n===== Test 2: =====");
            id = "tank_00";
            capasity = -100;

            try
            {
                tank = new Tank(id, capasity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 3 =====================
            Console.WriteLine("\n===== Test 3: =====");
            id = "tank_00";
            capasity = 0;

            try
            {
                tank = new Tank(id, capasity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 4 =====================
            Console.WriteLine("\n===== Test 4: =====");
            id = "tank_00";
            capasity = 1000;
            currentAmount = -50;

            try
            {
                tank = new Tank(id, capasity, currentAmount, JuiceType.Apple);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 5 =====================
            Console.WriteLine("\n===== Test 5: =====");
            id = "tank_00";
            capasity = 1000;
            currentAmount = 950;

            try
            {
                tank = new Tank(id, capasity, currentAmount, JuiceType.Apple);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 6 =====================
            Console.WriteLine("\n===== Test 6: =====");
            id = "tank_00";
            capasity = 1000;
            currentAmount = 650;
            juice = (JuiceType)10;

            try
            {
                tank = new Tank(id, capasity, currentAmount, juice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 7 =====================
            Console.WriteLine("\n ===== Test 7: =====");
            id = "tank_00";
            capasity = 1000;
            currentAmount = 650;
            juice = (JuiceType)3;

            try
            {
                tank = new Tank(id, capasity, currentAmount, juice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Tank count = {Tank.TankCount}");

            //================ Test 8 =====================
            Console.WriteLine("\n===== Test 8: =====");

            Console.WriteLine(tank.GetInfo());
            Console.WriteLine($"Free amount: {tank.FreeAmount}");
            Console.WriteLine($"Free? {tank.IsFree}");
            Console.WriteLine($"Full? {tank.IsFull}");

            //================ Test 9 =====================
            Console.WriteLine("\n===== Test 9: =====");

            bool result = tank.AddJuice(200, JuiceType.Tomato);
            Console.WriteLine($"Add juice? {result}");

            //================ Test 10 =====================
            Console.WriteLine("\n===== Test 10: =====");

            result = tank.AddJuice(250, JuiceType.Orange);
            Console.WriteLine($"Add juice? {result}");
            Console.WriteLine($"Capacity: {tank.Capasity}");
            Console.WriteLine($"Current amount: {tank.CurrentAmount}");
            Console.WriteLine($"Free amount: {tank.FreeAmount}");
            Console.WriteLine($"Free? {tank.IsFree}");
            Console.WriteLine($"Full? {tank.IsFull}");

            //================ Test 11 =====================
            Console.WriteLine("\n===== Test 11: =====");

            result = tank.AddJuice(150, JuiceType.Orange);
            Console.WriteLine($"Add juice? {result}");
            Console.WriteLine($"Full? {tank.IsFull}");

            //================ Test 12 =====================
            Console.WriteLine("\n===== Test 12: =====");

            tank.MakeFree();
            Console.WriteLine($"Free? {tank.IsFree}");

            //================ Test 13 =====================
            Console.WriteLine("\n===== Test 13: =====");

            id = "tank_01";
            capasity = 1000;
            currentAmount = 350;
            juice = (JuiceType)5;

            Tank t1 = new Tank(id, capasity, currentAmount, juice);

            id = "tank_02";
            capasity = 1000;
            currentAmount = 450;
            juice = (JuiceType)5;

            Tank t2 = new Tank(id, capasity, currentAmount, juice);

            PourJuice(t1, t2);

            //================ Test 14 =====================
            Console.WriteLine("\n===== Test 14: =====");

            id = "tank_03";
            capasity = 1000;
            currentAmount = 150;
            juice = (JuiceType)5;

            Tank t3 = new Tank(id, capasity, currentAmount, juice);

            PourJuice(t1, t3);

            //================ Test 15 =====================
            Console.WriteLine("\n===== Test 15: =====");

            id = "tank_04";
            capasity = 1000;
            currentAmount = 50;
            juice = (JuiceType)1;

            Tank t4 = new Tank(id, capasity, currentAmount, juice);

            PourJuice(t1, t4);

            //================ Test 16 =====================
            Console.WriteLine("\n===== Test 16: =====");

            id = "tank_05";
            capasity = 1000;

            Tank t5 = new Tank(id, capasity);

            PourJuice(t5, t3);

            Console.WriteLine($"Tank count = {Tank.TankCount}");

            // TODO 4: 
            //================ Test 17 =====================
            Console.WriteLine("\n===== Test 17: =====");

            List<Tank> tanks = new List<Tank> { tank, t1, t2, t3, t4, t5 };

            foreach (var t in tanks)
            {
                Console.WriteLine(t.GetInfo());
            }

            //================ Test 18 =====================
            Console.WriteLine("\n===== Test 18: =====");

            var tomatoTanks = tanks.FindAll(t => t.Juice == JuiceType.Tomato);

            foreach (var t in tomatoTanks)
            {
                Console.WriteLine(t.GetInfo());
            }

            //================ Test 19 =====================
            Console.WriteLine("\n===== Test 19: =====");

            var freeTanks = tanks.FindAll(t => t.IsFree);

            int count = freeTanks.Count;
            Console.WriteLine($"Amount of free tanks = {count}");

            //================ Test 20 =====================
            Console.WriteLine("\n===== Test 20: =====");

            tanks.RemoveAll(t => t.IsFree);

            foreach (var t in tanks)
            {
                Console.WriteLine(t.GetInfo());
            }
        }
    }
}
