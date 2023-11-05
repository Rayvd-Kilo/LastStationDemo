using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Utils
{
    public class PrototypedPool<T> : ObjectsPool<T>
    {
        private Dictionary<T, List<T>> _prototypedPool;
        
        public PrototypedPool(Func<T, T> objectsInstantiationDelegate,
            Action<T> releaseObjectDelegate, T[] prototypePrefabs) : base(
            objectsInstantiationDelegate, releaseObjectDelegate)
        {
            _prototypedPool = new Dictionary<T, List<T>>();

            foreach (var prototypePrefab in prototypePrefabs)
            {
                _prototypedPool.Add(prototypePrefab, new List<T>());
            }
        }

        public new T GetObject(T prototype)
        {
            if (_prototypedPool[prototype].Count.Equals(0))
            {
                var newPoolObject = objectsInstantiationDelegate.Invoke(prototype);

                return newPoolObject;
            }
            
            var nonActiveElement = _prototypedPool[prototype].First();

            _prototypedPool[prototype].Remove(nonActiveElement);

            return nonActiveElement;
        }
        
        public void ReleaseObject(T prototype, T poolObject)
        {
            releaseObjectDelegate.Invoke(poolObject);

            _prototypedPool[prototype].Add(poolObject);
        }
    }
}