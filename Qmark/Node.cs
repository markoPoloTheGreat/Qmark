using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qmark
{
    class Node<T>
    {
        private T value;//ערך החוליה
        private Node<T> next;//מצביע על החוליה הבאה
                             //פונקציה בונה שיוצרת חוליה עם ערך ללא חוליות אחריה
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T GetValue()
        {
            return this.value;
        }

        public Node<T> GetNext()
        {
            return this.next;
        }
        //הפונק' מחזירה אמת אם לחוליה הנוכחית יש חוליה עוקבת
        public bool HasNext()
        {
            return (this.next != null);
        }
        //פונק' הקובעת את ערך החוליה הנוכחית
        public void SetValue(T value)
        {
            this.value = value;
        }
        //פונק' הקובעת את החוליה העוקבת של החוליה הנוכחית
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        //פונקציה המכינה מחרוזת מכל החוליות המקושרות החל מן החוליה
        //הנתונה
        public override string ToString()
        {
            string str2return = "";
            if (this.next == null)
                str2return =  this.value + "]";
            else
                str2return =(this.value + "," + this.next);
            return str2return;
        }
    }
}
