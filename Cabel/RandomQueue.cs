using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabel
{
    class RandomQueue<T>
    {
        Random rng;
        IEnumerable<T> data;
        Queue<int> indices;

        public RandomQueue(IEnumerable<T> data, int seed)
        {
            this.data = data;

            rng = new Random(seed);
            GenerateIndexSet();
        }

        private void GenerateIndexSet()
        {
            indices = new Queue<int>();
            int count = data.Count();

            var ordered = new HashSet<int>();
            for (int i = 0; i < count; i++)
                ordered.Add(i);

            for (int i = 0; i < count; i++)
            {
                int a = ordered.ElementAt(rng.Next(count));
                indices.Enqueue(a);
            }
        }

        public T Next()
        {
            if (indices.Count < 1)
                GenerateIndexSet();
            return data.ElementAt(indices.Dequeue());   
        }
    }
}
