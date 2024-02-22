using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class CloseVisitList : IVisitList
    {
        private Coords _exit;
        protected List<Coords> _places = new List<Coords>();
        protected Dictionary<Coords, double> _distances = new Dictionary<Coords, double>();

        public int Count => _places.Count;

        public CloseVisitList(Coords exit)
        {
            _exit = exit;
        }

        public virtual void AddPlace(Coords place)
        {
            _places.Add(place);
            _distances[place] = GetDistance(place);
        }

        public virtual Coords GetPlace()
        {
            double minDistance = double.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < _places.Count; i++)
            {
                //double dist = GetDistance(_places[i]);
                double dist = _distances[_places[i]];
                if (dist < minDistance)
                {
                    minDistance = dist;
                    minIndex = i;
                }
            }

            Coords result = _places[minIndex];
            _places.RemoveAt(minIndex);
            _distances.Remove(result);
            return result;
        }

        protected double GetDistance(Coords place)
        {
            int dx = place.X - _exit.X;
            int dy = place.Y - _exit.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
