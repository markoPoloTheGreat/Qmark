using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qmark
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        public void Insert(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.first == null)
                this.first = newNode;
            else
                this.last.SetNext(newNode);
            this.last = newNode;
        }
        public T Remove()
        {
            T value = this.first.GetValue();
            this.first = this.first.GetNext();
            if (this.first == null)
                this.last = null;
            return value;
        }
        public T Head()
        {
            return this.first.GetValue();
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public override string ToString()
        {
            return "H[" + this.first;
        }
    }
}
