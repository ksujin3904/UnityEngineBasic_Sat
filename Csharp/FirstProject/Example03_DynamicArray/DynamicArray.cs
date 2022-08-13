using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example03_DynamicArray
{
    internal class DynamicArray<T> // Generic Type
    {
        private const int DEFAULT_SIZE = 1;
        private T[] _data = new T[DEFAULT_SIZE];

        public int Count; // 실제 데이터 개수

        // 프로퍼티
        // set / get 접근자를 멤버로 가질 수 있는 필드
        public int Capacity // 배열의 길이
        {
            // private set
            // {
            //     _data = new int[value];
            // }
            
            get
            {
                return _data.Length;
            }
        }
     
        // public void SetCapacity(int value)
        // {
        //     _data = new int[value];
        // }
        // 
        // public int GetCapacity()
        // {
        //     return _data.Length;
        // }

        // 삽입 알고리즘
        // (최선의경우) 일반적으로 O(1)
        // Capacity가 모자라서 새로 생성하는 경우 O(N)
        public void Add(T item)
        {
            // Capacity가 모자라면 배열의 크기를 늘림
            if (Count >= Capacity)
            {
                T[] tmp = new T[Capacity * 2];
                // 데이터를 새로운 배열에 복제
                for(int i = 0; i < Count; i++)
                {
                    tmp[i] = _data[i];
                }
                // data 배열을 tmp배열로 변경 => 전체 크기의 변경
                _data = tmp;
            }
            _data[Count] = item; // 아이템을 0번째에 등록
            Count++;
        }


        // 탐색 알고리즘
        // 최악의 경우를 생각해야하므로 O(N)

        public int FindIndex(T item)
        {
            for(int i = 0; i < Count; i++)
            {
                if(Comparer<T>.Default.Compare(_data[i],item) == 0)
                    return i;
            }
            return -1;
        }

        // 삭제 알고리즘
        // 1. 인덱스 삭제 알고리즘
        // O(N)

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count - 1)
                return false;
            
            for(int i = index; i < Count-1; i++)
            {
                _data[i] = _data[i+1];
            }
            _data[Count-1] = default(T);
            Count--;
            return true;
        }

        // 2. 데이터 삭제 알고리즘
        
        public bool Remove(T item)
        {
            return RemoveAt(FindIndex(item)); // 유효한 인덱스면 RemoveAt을 통해 삭제, true 실행
        }


    }
}
