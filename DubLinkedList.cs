using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm5 {
    public class DubLinkedList<T> {
        DubFrag<T> Helm;
        DubFrag<T> Back;
        int len;
        public void PushBack(T data) {
            DubFrag<T> Frag = new DubFrag<T>(data);

            if (Helm == null) Helm = Frag;
            else {
                Back.Next = Frag;
                Frag.Prev = Back;
            }
            Back = Frag;
            len++;
        }
        public void PushInf(T data) {
            DubFrag<T> Frag = new DubFrag<T>(data);
            DubFrag<T> Save = Helm;

            Save.Next = Frag;
            Helm = Frag;
            
            if (len == 0) Back = Save;
            else Helm.Prev = Save;
            len++;
        }
        public bool Remove(T data) {
            DubFrag<T> Pivot = Back;
            while (Pivot != null) {
                if (Pivot.Data.Equals(data)) break;
                Pivot = Pivot.Next;
            }
            if (Pivot != null) {
                if (Pivot.Next != null) {
                    Pivot.Next.Prev = Pivot.Prev;
                }
                else {
                    Pivot.Prev.Next = null;
                    Helm = Pivot.Prev;
                }

                if (Pivot.Prev != null)
                {
                    Pivot.Next.Prev = Pivot.Prev;
                }
                else {
                    Pivot.Next.Prev = null;
                    Back = Pivot.Next;
                }
                len--;
                return true;
            }
            return false;
        }
        public int Length { get { return len; } }
        public bool IsEmpty { get { return len == 0; } }
        public bool Contains(T data) {
            DubFrag<T> Pivot = Back;
            while (Pivot != null) {
                if (Pivot.Data.Equals(data)) return true;
                Pivot = Pivot.Next;
            }
            return false;
        }
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return Helm.Data;
            }
        }
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return Back.Data;
            }
        }
    }
}
