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
        Console.WriteLine("CheckNum");
        Console.WriteLine(CheckNum(q1,1));
        Console.WriteLine("CheckNeighbors");
        Console.WriteLine(CheckNeighbors(q1,3));
        Console.WriteLine("CheckQIsPerfect");
        Console.WriteLine(CheckQIsPerfect(q1));
        Queue<int> q2= new Queue<int>();
        q2.Insert(1);
        q2.Insert(3);
        q2.Insert(7);
        q2.Insert(19);
        Console.WriteLine("old"+q2);
        Console.WriteLine("new"+InsertInOrder(q2, 4));
        Console.WriteLine("new" + InsertInOrder(q2, 20));
        Console.WriteLine("new" + InsertInOrder(q2, -1));

    }

    public static bool CheckNum(Queue<int> q, int num)
    {
        Queue<int> qCopy = SetQCopy(q);

        Console.WriteLine(qCopy);
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
        //insert item less then  num
        while (curr < num)
        {
            qresult.Insert(curr);
            curr = q.Remove();
        }
        qresult.Insert(num);
        //insert bigger then num
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


}