using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul
{
    // TODO 2: Create the Tank class and its structure as specified in the class diagram.

    public class Tank
    {
        public string Id { get; }
        public int Capasity { get; }
        public int CurrentAmount { get; private set; }
        public JuiceType Juice { get; private set; }

        public Tank(string id, int capasity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Id cannot be empty.");

            if (capasity <= 0)
                throw new ArgumentException("Capacity must be greater than 0.");

            Id = id;
            Capasity = capasity;
            CurrentAmount = 0;
            Juice = JuiceType.UNKNOWN;
            TankCount++;
        }

        public Tank(string id, int capasity, int currentAmount, JuiceType juice) : this(id, capasity)
        {
            if (currentAmount < 0 || currentAmount > Capasity)
                throw new ArgumentException("Current amount must be between 0 and capacity.");

            if (!Enum.IsDefined(typeof(JuiceType), juice))
                throw new ArgumentException("Invalid juice type.");

            CurrentAmount = currentAmount;
            Juice = juice;
        }

        public static int TankCount { get; private set; }
        public static int CriticalPercentage { get; private set; } = 90;

        public bool IsFree => CurrentAmount == 0;
        public bool IsFull => CurrentAmount >= (Capasity * CriticalPercentage / 100);
        public int FreeAmount => Capasity * (CriticalPercentage - (CurrentAmount * 100 / Capasity)) / 100;

        public bool AddJuice(int amount, JuiceType newJuice)
        {
            if (IsFull || amount <= 0 || !IsSameType(newJuice))
                return false;

            if (CurrentAmount + amount > Capasity * CriticalPercentage / 100)
                return false;

            CurrentAmount += amount;
            return true;
        }

        public void MakeFree()
        {
            CurrentAmount = 0;
            Juice = JuiceType.UNKNOWN;
        }

        public string GetInfo()
        {
            return $"Id: {Id}, Capasity: {Capasity}, Current amount: {CurrentAmount}, Juice type: {Juice}";
        }

        public static bool IsSameType(JuiceType newJuice)
        {
            return newJuice == JuiceType.UNKNOWN || Juice == JuiceType.UNKNOWN || Juice == newJuice;
        }

        public static bool AllowedPour(Tank t1, Tank t2)
        {
            return !t1.IsFull && !t2.IsFree && IsSameType(t1.Juice, t2.Juice);
        }

        public static void PourJuice(Tank t1, Tank t2)
        {
            if (AllowedPour(t1, t2))
            {
                int amountToTransfer = Math.Min(t2.CurrentAmount, t1.FreeAmount);
                t1.AddJuice(amountToTransfer, t2.Juice);
                t2.CurrentAmount -= amountToTransfer;
                if (t2.CurrentAmount == 0)
                    t2.Juice = JuiceType.UNKNOWN;
                Console.WriteLine("Process is OK!");
            }
            else
            {
                Console.WriteLine("Process isn't OK!");
            }
        }

        public static void ChangeCriticalPercentage(int percentage)
        {
            if (percentage > 0 && percentage <= 100)
                CriticalPercentage = percentage;
        }
    }

    public enum JuiceType
    {
        UNKNOWN,
        APPLE,
        ORANGE,
        TOMATO
    }
}
