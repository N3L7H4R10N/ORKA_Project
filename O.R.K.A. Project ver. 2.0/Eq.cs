﻿using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace O.R.K.A._Project_ver._2._0
{
    public class Eq
    {
        Methods methods = new Methods();
        public List<Item> Items = new List<Item>() { };
        
        public void ItemsDisplay()
        {
            //Może się przydać
            //Item[] itemsArray = Items.ToArray();
            eqStart:
            methods.Clear();
            Console.WriteLine("EKWIPUNEK \n");
            Console.WriteLine("0. Wyjdź");
            
            //Items Display
            if (Items.Any())
            {
                foreach (var Item in Items)
                {
                    int count = 1;
                    Console.WriteLine($"{count}. {Item.name}\n");
                    count++;
                    methods.Sleep(500);
                }
            }
            else
            {
                Console.WriteLine("\n*Ekwipunek jest pusty*\n");
            }

            string eqChoice = Console.ReadLine();
            bool isNumber = int.TryParse(eqChoice, out int eqChoiceInt);

            if (isNumber)
            {
                if (eqChoiceInt > 0)
                {
                    methods.Clear();
                    eqChoiceInt = eqChoiceInt - 1;
                    Console.WriteLine(Items[eqChoiceInt].description);
                    if (Items[eqChoiceInt].usable)
                    {
                        methods.Clear();
                        Console.WriteLine("1. Użyj");
                        Console.WriteLine("2. Wróć\n");

                        string itemChoice = Console.ReadLine();

                        if (itemChoice == "1" && Items[eqChoiceInt].isWeapon)
                        {
                            
                        }
                        else if (itemChoice == "1" && Items[eqChoiceInt].isShield)
                        {
                            
                        }
                        else
                        {
                            
                        }
                    }
                }
                else if (eqChoiceInt == 0)
                {
                    methods.Clear();
                }
                else
                {
                    methods.Clear();
                    Console.WriteLine("Wprowadź poprawną liczbę");
                    methods.Ent();
                    goto eqStart;
                }
            }
            else
            {
                methods.Clear();
                Console.WriteLine("Wprowadź poprawną LICZBĘ");
                methods.Ent();
                goto eqStart;
            }
            
            
            //For debug only
            /*{
                foreach (Item Item in Items)
                {
                    int count = 1;
                    Console.WriteLine(
                        $"{count}. " +
                        $"name:{Item.name} " +
                        $"{Item.dmgMinHead} " +
                        $"{Item.dmgMaxHead} " +
                        $"{Item.dmgMinBody} " +
                        $"{Item.dmgMaxBody} " +
                        $"{Item.dmgMinLegs} " +
                        $"{Item.dmgMaxLegs}"
                        );
                    count++;
                    methods.Sleep(500);
                }*/
        }
    }
    public class Item
    {
        public string name;
        public string description;
        public bool usable;
        public bool isShield;
        public int parry;
        public int dmgMinHead;
        public int dmgMaxHead;
        public int dmgMinBody;
        public int dmgMaxBody;
        public int dmgMinLegs;
        public int dmgMaxLegs;
        public bool isWeapon;
        
        
        public Item
            (string name,
            string description,
            bool usable = false,
            bool isShield = false,
            int parry = 0,
            int dmgMinHead = 0, 
            int dmgMaxHead = 0, 
            int dmgMinBody = 0, 
            int dmgMaxBody = 0, 
            int dmgMinLegs = 0, 
            int dmgMaxLegs = 0,
            bool isWeapon = false)
        {
            this.name = name;
            this.description = description;
            this.usable = usable;
            this.isShield = isShield;
            this.parry = parry;
            this.dmgMinHead = dmgMinHead;
            this.dmgMaxHead = dmgMaxHead;
            this.dmgMinBody = dmgMinBody;
            this.dmgMaxBody = dmgMaxBody;
            this.dmgMinLegs = dmgMinLegs;
            this.dmgMaxLegs = dmgMaxLegs;
        }
        
        //Normal items
        public static Item Jacket = new Item(
            "Kurtka", 
            "Kurtka twojego kolegi");
        public static Item Code = new Item(
            "Kot", 
            "Kartka z kodem do drzwi");
        public static Item Milk = new Item(
            "Mlekooo", 
            "Karton mleka");
        public static Item Rope = new Item(
            "Lina", 
            "Długa lina, na tyle silna żeby cię utrzymać");
        public static Item CrispsOfImmortality = new Item(
            "Chipsy of Immortality", 
            "Paczka powietrza zawierająca 25% chipsów, zwiększa obronę o 10 do końca walki");
        public static Item Dell = new Item(
            "Dell", 
            "Niezwykle mijający się ze swoim celem laptop gaming'owy");
        public static Item Hp = new Item(
            "HP", 
            "Zwykły hp'ek, naszczęście ma niezmienione hasło do teb-serwis");
        public static Item ThinkPad = new Item(
            "Thinkpad", 
            "Każdy go chce, eksperci twierdzą że 'no, jest dobry' oraz 'laptop jak laptop'");

        public static Item WygasPc = new Item(
            "Laptop Wygasła",
            "Komputer z najlepszym wygaśaczem ekranu");
        public static Item BrokenMouse = new Item(
            "Zepsuta myszka",
            "Mogłaby się przydać do zrobienia kursu sicso, gdyby tylko dało się ją naprawić");
        public static Item C4 = new Item(
            "C4", 
            "Pdobno 'Rozpierdoli to pół domu', w zestawie również zdalny detonator");
        public static Item KeyTo17 = new Item(
            "Klucz do 17", 
            "Klucz z przyczepionym napisem '17'");
        public static Item RepairKit = new Item(
            "Kit naprawczy", 
            "Zestaw naprawczy jednorazowego użytku do myszki z serii 'Pieniądze to nie problem'");
        public static Item Coin = new Item(
            "Moneta", 
            "Moneta o nominale ...zł");
        public static Item Jbl = new Item(
            "Głośnik JBL", 
            "Świetny do imitacji dźwięków pukania");
        public static Item UsbKiller = new Item(
            "Usb killer", 
            "Usb killer, prawdopodobnie należał do Wygasła");
        
        //Usable
        public static Item CoffeMilk = new Item(
            "Kawamleko", 
            "Kawa z mlekiem, powiększa maksymalne zdrowie o 75hp", 
            true);
        public static Item BatonOfPower = new Item(
            "Baton of Power", 
            "Baton z automatu szkolnego, podnosi obrażenia o 10 do końca walki", 
            true);
        public static Item DrinkOfYoutk = new Item(
            "Napój of Youth", 
            "Podejrzanie żółty napój, przywraca 60hp",
            true);
        
        //Weapons
        public static Item Axe = new Item(
            "Siekiera", 
            "Siekiera ze stróżówki, 6-20 dmg",
            true, 
            false,
            0, 
            10, 20, 
            7, 16, 
            6, 13,
            true);
        public static Item Rabab = new Item(
            "Gaśnica", 
            "Rabab, przekazywany tylko wbrańcom, 24-50",
            true, 
            false,
            0, 
            38, 50,
            27, 39,
            24, 32,
            true);
        public static Item Thermos = new Item(
            "Termos", 
            "Wielka aluminiowa pała do trzymania wody, 2-12 dmg",
            true, 
            false,
            0, 
            7, 12, 
            5, 8, 
            2, 4,
            true);
        public static Item ThermosWater = new Item(
            "Termoswoda", 
            "Wielka aluminiowa pała z wodą, 7-21 dmg",
            true, 
            false,
            0, 
            12, 21,
            11, 17, 
            7, 10,
            true);
        public static Item ThermosTea = new Item(
            "Termosherbata", 
            "Wielka aluminiowa pała z herbatką, 6-19 dmg",
            true, 
            false,
            0, 
            10, 19, 
            9, 16, 
            6, 8,
            true);
        public static Item Extingusher = new Item(
            "Gaśnica", 
            "Gaśnica 'pożyczona' z korytarza szkolnego, 4-20 dmg",
            true, 
            false,
            0, 
            8, 14, 
            5, 10, 
            4, 20,
            true);
        public static Item Lightsaber = new Item(
            "Lightsaber", 
            "May the force be with you",
            true, 
            false,
            0, 
            31, 44, 
            23, 35, 
            21, 32,
            true);
        public static Item StaffOfSosnowiec = new Item(
            "Staff of Sosnowiec", 
            "Unikalna ręcznie zrobiona pałka wykonania Sosnowcowego, 21-37",
            true, 
            false,
            0, 
            29, 37, 
            24, 34, 
            21, 29,
            true);
        public static Item Secator = new Item(
            "Sekator",
            "Popularne narzędzie fryzjerskie, 1-9 dmg",
            true, 
            false,
            0, 
            5, 9, 
            3, 6, 
            2, 4,
            true);
        public static Item Hand = new Item(
            "Ręka", 
            "O Boże!!! To moja ręka! 1-7dmg",
            true, 
            false,
            0, 
            3, 7, 
            2, 3, 
            1, 2,
            true);
        
        //Shields
        public static Item Desk = new Item(
            "Deska", 
            "Deska pokryta jest tajemniczymi hieroglifami",
            true, 
            true, 
            6);
        public static Item DeskUpgraded = new Item(
            "Deska ulepszona", 
            "Deska ulepszona zdjęciem odByta, +9 obrony",
            true, 
            true, 
            9);
        public static Item ParryHand = new Item(
            "Ręka", 
            "O Boże!!! To moja ręka! 1-7dmg",
            true, 
            true, 
            3);
        public static Item Doors = new Item(
            "Drzwi", 
            "Drzwi, miejmy nadzieje że są bardziej wytrzymałe niż zawiasy, +12 obrony",
            true, 
            true, 
            12);
        public static Item Fap3000 = new Item(
            "Fap3000", 
            "Własnoręcznie stoworzony laptop, świetny do obrony, +15 obrony",
            true, 
            true, 
            15);
    }
}