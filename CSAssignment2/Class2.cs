using System;
using System.Collections.Generic;

namespace CSAssignment2
{

    interface ICache<TKey, TVal>                        //declaring interface for cache Dictionary.
    {
        void AddVal(TKey key, TVal val, int size);      //adding values function declaration.
        void DisplayItems();                            //displating value function declaation.
    }

    class Cache<TKey, TVal> : ICache<TKey, TVal>
    {
        public int counter;
        Dictionary<TKey, TVal> cache = new Dictionary<TKey, TVal>();        //Declaring Dictionay to hold keys and values.
        Queue<TKey> keys = new Queue<TKey>();                               //declaring queue to hold keys.
        /// <summary>
        /// Adds the value to the cache class
        /// </summary>
        /// <param name="key">Index of Value added</param>
        /// <param name="val">Value to be added</param>
        /// <param name="size">Size of class created</param>
        public void AddVal(TKey key, TVal val, int size)
        {
            if (cache.ContainsValue(val))
            {
                TKey removeKey;
                foreach (KeyValuePair<TKey, TVal> item in cache)
                {
                    if (item.Value.Equals(val))
                    {
                        removeKey = item.Key;       //if cache have value already then track that key into removekey.
                        int keysCount = keys.Count;
                        for (int cacheIndex = default; cacheIndex < keysCount; cacheIndex++)
                        {
                            TKey cacheItem = keys.Dequeue();
                            if (cacheItem.ToString() != removeKey.ToString())
                            {
                                keys.Enqueue(cacheItem);
                            }
                        }
                        keys.Enqueue(removeKey);
                        break;
                    }
                }


            }
            else if (cache.Count == size)       //if size of cache is full
            {
                TKey old = keys.Dequeue();      //taking old key 
                cache[old] = val;               //insert value at that position.
                keys.Enqueue(old);              //add key

            }
            else
            {
                cache.Add(key, val);            //simply adding value to cache
                keys.Enqueue(key);              //adding value to queue of keys
                counter++;
            }
        }
        /// <summary>
        ///  Displaying Cache items.
        /// </summary>
        public void DisplayItems()             
        {
            foreach (KeyValuePair<TKey, TVal> item in cache)
            {
                Console.WriteLine("{0}", item.Value);
            }
        }
    }
}