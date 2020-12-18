using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia2017
{
    class Monopoly
    {
        const int StartCash = 6000;

        private List<Players> players = new List<Players>();
        public List<Goods> fields = new List<Goods>()
        {
            new Goods("Ford",new  AUTO (), 0),
            new Goods("MCDonald",new FOOD(), 0),
            new Goods("Lamoda", new CLOTHER(), 3),
             new Goods("Air Baltic", new TRAVEL(), 0),
             new Goods("Nordavia", new TRAVEL(), 0),
            new Goods("Prison", new PRISON(), 0),
             new Goods("MCDonald", new FOOD(), 0),
              new Goods("TESLA", new AUTO(), 0),
        };

        public Monopoly(string[] p, int v)
        {
            for (int i = 0; i < v; i++)
            {
                players.Add(new Players(p[i], i, StartCash));
            }

        }

        internal List<Players> GetPlayersList()
        {
            return players;
        }


        internal List<Goods> GetFieldsList()
        {
            return fields;
        }

        public Goods GetFieldByName(string name)
        {
            return fields.FirstOrDefault(f => f.Name == name);
        }

        public int GetIndexFieldByName(Goods good)
        {
            return fields.Select((item, index) => new { name = item.Name, index = index })
                   .Where(n => n.name == good.Name)
                   .Select(p => p.index).FirstOrDefault();
        }

        public bool Buy(int indexPlayer  , Goods good)
        {
            Players x = GetPlayerInfo(indexPlayer);

            int cash = 0;

            if (good.Owner != 0)
                return false;

            cash = x.Cash - good.Type.SellPrice;
            players[indexPlayer] = new Players(x.Name, x.Id, cash);

            int indexField = GetIndexFieldByName(good);
            fields[indexField] = new Goods(good.Name, good.Type, indexPlayer);

            return true;
            }

            public Players GetPlayerInfo(int id)
        {
            return players.FirstOrDefault(f => f.Id== id);
        }


    public bool Renta(int v, Goods k)
    {
            var z = GetPlayerInfo(v);
            Players o = null;

            if (k.Owner == 0)
                return false;

            //    switch (k.Item2)
            //    {
            //        case Type.AUTO:
            //            if (k.Item3 == 0)
            //                return false;
            //            o = GetPlayerInfo(k.Item3);
            //            z = new Tuple<string, int>(z.Item1, z.Item2 - 250);
            //            o = new Tuple<string, int>(o.Item1, o.Item2 + 250);
            //            break;
            //        case Type.FOOD:
            //            if (k.Item3 == 0)
            //                return false;
            //            o = GetPlayerInfo(k.Item3);
            //            z = new Tuple<string, int>(z.Item1, z.Item2 - 250);
            //            o = new Tuple<string, int>(o.Item1, o.Item2 + 250);

            //            break;
            //        case Type.TRAVEL:
            //            if (k.Item3 == 0)
            //                return false;
            //            o = GetPlayerInfo(k.Item3);
            //            z = new Tuple<string, int>(z.Item1, z.Item2 - 300);
            //            o = new Tuple<string, int>(o.Item1, o.Item2 + 300);
            //            break;
            //        case Type.CLOTHER:
            //            if (k.Item3 == 0)
            //                return false;
            //            o = GetPlayerInfo(k.Item3);
            //            z = new Tuple<string, int>(z.Item1, z.Item2 - 100);
            //            o = new Tuple<string, int>(o.Item1, o.Item2 + 1000);

            //            break;
            //        case Type.PRISON:
            //            z = new Tuple<string, int>(z.Item1, z.Item2 - 1000);
            //            break;
            //        case Type.BANK:
            //            z = new Tuple<string, int>(z.Item1, z.Item2 - 700);
            //            break;
            //        default:
            //            return false;
            //    }
            //    players[v - 1] = z;
            //    if (o != null)
            //        players[k.Item3 - 1] = o;

            return true;
    }
}
}
