using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    public class Heap<T>
    {
        private T[] heap;
        public Comparison<T> Comparer;
        public int Capacity
        {
            get
            {
                return heap.Length;
            }
        }
        private int size;
        public Heap(Comparison<T> comparer, int capacity)
        {
            Comparer = comparer;
            heap = new T[capacity + 1];
            size = 1;
        }

        public void Insert(T value)
        {
            if (size >= Capacity)
            {
                Resize((Capacity - 1) * 2);
            }
            heap[size] = value;
            heapifyUp(size);
            size++;
            return;
        }

        public T Pop()
        {
            if(heap.Length <= 1)
            {
                return null;
            }
            T least = heap[1];
            size--;
            heap[1] = heap[size];
            heapifyDown(1);
            if (size - 1 < (Capacity - 1) / 4)
            {
                Resize((Capacity - 1) / 2);
            }
            return least;
        }

        void heapifyUp(int index)
        {
            int parentIndex = index / 2;
            if (index == 1)
            {
                return;
            }
            if (Comparer(heap[index], heap[parentIndex]) < 0)
            {
                T swapVal = heap[parentIndex];
                heap[parentIndex] = heap[index];
                heap[index] = swapVal;
                heapifyUp(parentIndex);
            }
        }

        void heapifyDown(int index)
        {
            int leftChildIndex = index * 2;
            int rightChildIndex = leftChildIndex + 1;
            int lowestChildIndex;
            if (leftChildIndex >= size) { return; }
            if (rightChildIndex >= size) { lowestChildIndex = leftChildIndex; }
            else
            {
                lowestChildIndex = Comparer(heap[leftChildIndex], heap[rightChildIndex]) > 0 ? rightChildIndex : leftChildIndex;
            }
            if (Comparer(heap[lowestChildIndex], heap[index]) < 0)
            {
                T swapVal = heap[index];
                heap[index] = heap[lowestChildIndex];
                heap[lowestChildIndex] = swapVal;
                heapifyDown(lowestChildIndex);
            }

        }

        void Resize(int newCapactity)
        {
            int count = Math.Min(newCapactity + 1, Capacity);
            T[] newHeap = new T[newCapactity];
            for (int i = 0; i < count - 1; i++)
            {
                newHeap[i] = heap[i];
            }
            heap = newHeap;
        }
    }
}
