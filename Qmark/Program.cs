using System;

namespace Qmark;
public class Program
    //mark 21/1
{
    public static void Main(string[] args)
    {
        Queue<int> q1 = new Queue<int>();
        q1.Insert(1);
        q1.Insert(5);
        q1.Insert(4);
        q1.Insert(-1);
        q1.Insert(-5);
        Console.WriteLine("CheckNum 1");
        Console.WriteLine(CheckNum(q1,1));
        Console.WriteLine("CheckNeighbors place 3");
        Console.WriteLine(CheckNeighbors(q1,3));
        Console.WriteLine("CheckQIsPerfect");
        Console.WriteLine(CheckQIsPerfect(q1));
        Queue<int> q2= new Queue<int>();
        q2.Insert(1);
        q2.Insert(3);
        q2.Insert(7);
        q2.Insert(19);
        Console.WriteLine("old "+q2);
        Console.WriteLine("new"+InsertInOrder(q2, 4));
        Console.WriteLine("new" + InsertInOrder(q2, 20));
        Console.WriteLine("new" + InsertInOrder(q2, -1));
        Console.WriteLine("Insert in order students");
        Student s1 = new("lior", 70);
        Student s2 = new("itay", 80);
        Student s3 = new("ariel",90);
        Student s4 = new("efrat", 95);
        Student s5 = new("mark", 85);
        Queue<Student> qS = new();
        qS.Insert(s1); qS.Insert(s2); qS.Insert(s3); qS.Insert(s4);
        Console.WriteLine("old" + qS);
        Console.WriteLine("new" + InsertStudentInOrder(qS,s5));
        Student s6 = new("lia b", 100);
        Student s7 = new("ben simon", 50);
        Console.WriteLine("new" + InsertStudentInOrder(qS, s6));
        Console.WriteLine("new" + InsertStudentInOrder(qS, s7));

    }

    public static bool CheckNum(Queue<int> q, int num)
    {
        Queue<int> qCopy = SetQCopy(q);

        int currCheck;
        while (!qCopy.IsEmpty())
        {
            currCheck = qCopy.Remove();
            if (currCheck == num)
            {
                Console.WriteLine(q);
                return true;
            }
        }
        Console.WriteLine(q);
        return false;


    }
    public static bool CheckNeighbors(Queue<int> q, int index)
    {

        //Receives a queue with numbers and a number of index 
        //Returns if the number is perfect
        Queue<int> qCopy = SetQCopy(q);
        int left = 0, right, target;
        //check edge case
        if (index == 1)
        {
            return false;
        }
        for (int i = 0; i < index - 1; i++)
        {
            left = qCopy.Remove();
        }
        target = qCopy.Remove();
        //check if last
        if (qCopy.IsEmpty())
        {
            return false;
        }
        right = qCopy.Remove();
        if (right + left == target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool CheckQIsPerfect(Queue<int> q)
    {
        //The function receives a queue with int numbers
        //Returns if the queue is perfect
        Queue<int> qCopy = SetQCopy(q);
        qCopy.Remove(); 
        int i = 2;
        bool isPerfect = true;
        while (!qCopy.IsEmpty())
        {
            qCopy.Remove();
            //check if last
            if (qCopy.IsEmpty())
            {
                return isPerfect;
            }
            //Using the function to check if the number is perfect
            isPerfect = isPerfect && CheckNeighbors(q, i);
            i++;
        }
        return isPerfect;
    }
    public static Queue<int> InsertInOrder(Queue<int> q, int num)
    {
        Queue<int> qresult = new();
        int curr = q.Remove();
        //check if the new should be first
        if (curr > num)
        {
            qresult.Insert(num);
            while (!q.IsEmpty())
            {
                qresult.Insert(q.Remove());
            }
            while (!qresult.IsEmpty())
            {
                q.Insert(qresult.Remove());
            }
            return q;
        }
        //insert item less then new
        while (curr < num)
        {
            qresult.Insert(curr);
            curr = q.Remove();
            if (q.IsEmpty())
            {
                qresult.Insert(curr);
                while (!qresult.IsEmpty())
                {
                    q.Insert(qresult.Remove());
                }
                q.Insert(num);
                return q;
            }
        }
        qresult.Insert(num);
        qresult.Insert(curr);
        //insert bigger then new
        while (!q.IsEmpty())
        {
            qresult.Insert(q.Remove());
        }
        //insert back to q
        while (!qresult.IsEmpty())
        {
            q.Insert(qresult.Remove());
        }
        return q;
    }
    public static Queue<Student> InsertStudentInOrder(Queue<Student> q, Student newS)
    {
        Queue<Student> qresult = new();
        Student curr = q.Remove();
        //check if the new should be first
        if (curr.GetGrade() > newS.GetGrade())
        {
            qresult.Insert(newS);
            while (!q.IsEmpty())
            {
                qresult.Insert(q.Remove());
            }
            while (!qresult.IsEmpty())
            {
                q.Insert(qresult.Remove());
            }
            return q;
        }
        //insert item less then new
        while (curr.GetGrade() < newS.GetGrade())
        {
            qresult.Insert(curr);
            curr = q.Remove();
            if (q.IsEmpty())//if the new should be last
            {
                qresult.Insert(curr);
                while (!qresult.IsEmpty())
                {
                    q.Insert(qresult.Remove());
                }
                q.Insert(newS);
                return q;
            }
        }
        qresult.Insert(newS);
        qresult.Insert(curr);
        //insert bigger then new
        while (!q.IsEmpty())
        {
            qresult.Insert(q.Remove());
        }
        //insert back to q
        while (!qresult.IsEmpty())
        {
            q.Insert(qresult.Remove());
        }
        return q;
    }
    public static Queue<int> SetQCopy(Queue<int> q)
    {
        Queue<int> qCopy = new();
        Queue<int> qTemp = new();
        int currItem;
        //פריקת התור המקורי ויצירת תור העתק ותור זמני
        while (!q.IsEmpty())
        {
            currItem = q.Remove();
            qTemp.Insert(currItem);
            qCopy.Insert(currItem);
        }
        //שחזור התור המקורי
        while (!qTemp.IsEmpty())
        {
            q.Insert(qTemp.Remove());
        }
        return qCopy;
    }
    public static Queue<T> EmptyQ2Copy<T>(Queue<T> q)
    {
        Queue<T> qCopy = new();
        while (!q.IsEmpty())
        {
            qCopy.Insert(q.Remove());
        }
        return qCopy;
    }


}