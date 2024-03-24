using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectPoolFiles
{
    public class ObjectPool<T>
        where T : MonoBehaviour
    {
        private Transform _container;
        private T _prefab;
        private List<T> _poolGeneric;

        public ObjectPool(T prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;
            GetInitialization(count, prefab);
        }

        public bool AutoExpand { get; private set; }

        public bool TryGetObject(out T spawned, T prefabs)
        {
            var filter = _poolGeneric.Where(p => p.gameObject.activeSelf == false);
            var index = Random.Range(0, filter.Count());

            if (filter.Count() == 0 && AutoExpand)
            {
                spawned = CreateObject(prefabs);
                return spawned != null;
            }

            spawned = filter.ElementAt(index);
            // spawned.gameObject.SetActive(true);
            return spawned != null;
        }

        public void GetFirstObject(out T spawned, T prefabs)
        {
            T filter = _poolGeneric.FirstOrDefault(p => p.gameObject.activeSelf == false);
            spawned = filter;
            // return true;
        }

        public void SetAutoExpand(bool flag)
        {
            AutoExpand = flag;
        }

        public void Reset()
        {
            foreach (var item in _poolGeneric)
                item.gameObject.SetActive(false);
        }

        private void GetInitialization(int count, T prefabs)
        {
            _poolGeneric = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var spawned = Object.Instantiate(prefabs, _container.transform);
                spawned.gameObject.SetActive(false);
                _poolGeneric.Add(spawned);
            }
        }

        private T CreateObject(T prefabs)
        {
            var spawned = Object.Instantiate(prefabs, _container.transform);
            spawned.gameObject.SetActive(true);
            _poolGeneric.Add(spawned);
            return spawned;
        }
    }
}