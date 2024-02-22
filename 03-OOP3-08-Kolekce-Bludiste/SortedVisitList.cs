using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class SortedVisitList : CloseVisitList
    {
        public SortedVisitList(Coords exit) : base(exit)
        {
        }

        public override void AddPlace(Coords place)
        {
            double distance = GetDistance(place);

            if (_places.Count == 0) //když tam je prázdno
            {
                _places.Add(place);
                return;
            }

            for (int i = 0; i < _places.Count; i++) //najdi, kdy už to bude menší
            {
                if (distance > _distances[_places[i]])
                {
                    _places.Insert(i, place); // a ulož
                    break;
                }
            }
        }

        public override Coords GetPlace()
        {
            int lastIndex = _places.Count - 1; //nejmenší skladujeme na konci - odebereme z konce
            Coords result = _places[lastIndex];
            
            _places.RemoveAt(lastIndex);
            _distances.Remove(result);
            
            return result;
        }
    }
}
