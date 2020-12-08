﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal enum Type
    {
        AUTO,
        FOOD,
        CLOTHER,
        TRAVEL,
        PRISON,
        BANK
    }
    class Monopoly
    {
        private List<Tuple<string, int>> players = new List<Tuple<string, int>>();
        private List<Tuple<string, Type, int, bool>> fields = new List<Tuple<string, Type, int, bool>>()
        {
              new Tuple<string, Type, int, bool>("Ford", Type.AUTO, 0, false),
               new Tuple<string, Type, int, bool>("MCDonald", Type.FOOD, 0, false),
               new Tuple<string, Type, int, bool>("Lamoda",Type.CLOTHER, 0, false),
               new Tuple<string, Type, int, bool>("Air Baltic", Type.TRAVEL, 0, false),
               new Tuple<string, Type, int, bool>("Nordavia", Type.TRAVEL, 0, false),
               new Tuple<string, Type, int, bool>("Prison", Type.PRISON, 0, false),
                new Tuple<string, Type, int, bool>("MCDonald",Type.FOOD, 0, false),
                new Tuple<string, Type, int, bool>("TESLA", Type.AUTO, 0, false),
        };
        

        public Monopoly(string[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                players.Add(new Tuple<string, int>(p[i], 6000));
            }
         }

            public List<Tuple<string, Type, int, bool>> Fields
        {
            get {
            

                return fields;
            }
            private set { fields = value; }
        }

        internal List<Tuple<string, int>> GetPlayersList()
        {
              return players;
        }

      

        internal List<Tuple<string, Type, int, bool>> GetFieldsList()
        {

            return fields;
        }

        internal Tuple<string, Type, int, bool> GetFieldByName(string v)
        {
            return (from p in fields where p.Item1 == v select p).FirstOrDefault();
        }

        internal bool Buy(int v, Tuple<string, Type, int, bool> k)
        {
            var x = GetPlayerInfo(v);
            int cash = 0;
            switch (k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.Item2 - 500;
                    players[v - 1] = new Tuple<string, int>(x.Item1, cash);
                    break;
                case Type.FOOD:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.Item2 - 250;
                    players[v - 1] = new Tuple<string, int>(x.Item1, cash);
                    break;
                case Type.TRAVEL:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.Item2 - 700;
                    players[v - 1] = new Tuple<string, int>(x.Item1, cash);
                    break;
                case Type.CLOTHER:
                    if (k.Item3 != 0)
                        return false;
                    cash = x.Item2 - 100;
                    players[v - 1] = new Tuple<string, int>(x.Item1, cash);
                    break;
                default:
                    return false;
            }
            int i = players.Select((item, index) => new { name = item.Item1, index = index })
                .Where(n => n.name == x.Item1)
                .Select(p => p.index).FirstOrDefault();
            fields[i] = new Tuple<string, Type, int, bool>(k.Item1, k.Item2, v, k.Item4);
            return true;
        }

        internal Tuple<string, int> GetPlayerInfo(int v)
        {
            return players[v - 1];
        }

        internal bool Renta(int v, Tuple<string, Type, int, bool> k)
        {
            var z = GetPlayerInfo(v);
            Tuple<string, int> o = null;
            switch (k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 250);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 250);
                    break;
                case Type.FOOD:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 250);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 250);

                    break;
                case Type.TRAVEL:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 300);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 300);
                    break;
                case Type.CLOTHER:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 100);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 1000);

                    break;
                case Type.PRISON:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 1000);
                    break;
                case Type.BANK:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 700);
                    break;
                default:
                    return false;
            }
            players[v - 1] = z;
            if (o != null)
                players[k.Item3 - 1] = o;
            return true;
        }
    }

   
}
