using System;
using System.Collections.Generic;
using System.Linq;

namespace GourmetsRealm.LastStationDemo.Utils
{
    public class ObjectsPool<T>
    {
        protected readonly Func<T, T> objectsInstantiationDelegate;
        protected readonly Action<T> releaseObjectDelegate;

        private readonly List<T> _pool;

        public ObjectsPool(Func<T,T> objectsInstantiationDelegate, Action<T> releaseObjectDelegate)
        {
            this.objectsInstantiationDelegate = objectsInstantiationDelegate;
            this.releaseObjectDelegate = releaseObjectDelegate;

            _pool = new List<T>();
        }

        public T GetObject(T prototype)
        {
            if (_pool.Count.Equals(0))
            {
                var newPoolObject = objectsInstantiationDelegate.Invoke(prototype);

                return newPoolObject;
            }
            
            var nonActiveElement = _pool.First();

            _pool.Remove(nonActiveElement);

            return nonActiveElement;
        }

        public void ReleaseObject(T poolObject)
        {
            releaseObjectDelegate.Invoke(poolObject);
            
            _pool.Add(poolObject);
        }
    }
}