using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnumerables
{
    public class MyEnumerator : IEnumerator<int>
    {
        private int _current;
        private int _final;

        public MyEnumerator()
        {
            var rnd = new Random();
            _current = rnd.Next(10, 20);
            _final = _current + 60;
        }

        public int Current
        {
            get
            {
                if (_current > 0) return _current;
                throw new ObjectDisposedException("Enumerator was disposed");
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _current = -100;
        }

        public bool MoveNext()
        {
            _current++;
            //return _current <= _final;
            return true;
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }
    }
}
