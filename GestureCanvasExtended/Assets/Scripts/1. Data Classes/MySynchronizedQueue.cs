using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySynchronizedQueue<T>
{
    private object baton = new object();
    private Queue<T> theQ = new Queue<T>();

    public void Enqueue(T item)
    {
        lock (baton)
            theQ.Enqueue(item);
    }

    public T Dequeue()
    {
        lock (baton)
        {
            if (theQ.Count > 0) return theQ.Dequeue();
            else return default(T);
        }

    }

    public int Count
    {
        get { lock (baton) return theQ.Count; }
    }

    public Queue<T>.Enumerator GetEnumerator()
    {
        lock (baton)
            return theQ.GetEnumerator();
    }

    public object SyncRoot
    {
        get { return baton; }
    }


}
