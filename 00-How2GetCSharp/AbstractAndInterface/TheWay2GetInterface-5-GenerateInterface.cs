﻿using System;
using System.Threading.Channels;

namespace AbstractInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle ivCar=new Car();
            ivCar.Fill();
            IVehicle ivTruck= new Truck();
            ivTruck.Running();
        } 
        interface IVehicle
        {
            void Running();
            void Stop();
            void Fill();
        }

        abstract class Vehicle:IVehicle
        {
            public virtual void Running()
            {
                Console.WriteLine("RUN FROM INTERFACE...");
            }

            public virtual  void Stop()
            {
                Console.WriteLine("stop from interface...");
            }

            public abstract void Fill();
        }

        class Car : Vehicle
        {
            public override void Fill()
            {
                Console.WriteLine("Fill in abstract class Vehicle is a abstract method");
            }

            public override void Stop()
            {
                Console.WriteLine("stop in abstract class Vehicle is a virtual but not abstract method");
            }

            public override void Running()
            {
                Console.WriteLine("running in abstract class Vehicle is a virtual but not abstract method");
            }
        }

        class Truck : Vehicle
        {
            public override void Fill()
            {
                Console.WriteLine("Truck Fill in abstract class Vehicle is a abstract method");
            }

            public override void Stop()
            {
                Console.WriteLine("Truck stop in abstract class Vehicle is a virtual but not abstract method");
            }

            public override void Running()
            {
                Console.WriteLine("Truck running in abstract class Vehicle is a virtual but not abstract method");
            }
        }

    }
}