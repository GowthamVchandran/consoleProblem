using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CheckAnagram
{

    public class ITestcollection:IEnumerable
    {
        private int a, b, c;

        public ITestcollection(int i,int j,int k)
        {
            this.a = i;
            this.b = j;
            this.c = k;
        }

        public IEnumerator GetEnumerator()
        {
            yield return a;
            yield return b;
            yield return c;

        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }
       
    }
    public class Subject
    {
        public int subjectID { get; set; }
        public string subjectName { get; set; }
    }
    public class customer
    {
        public int customerid { get; set; }
        public string cName { get; set; }        
    } 
    public class Program
    {

        public static void testlinq()
        {
            IList<string> strList1 = new List<string>() {
    "One",
    "Two",
    "Three",
    "Four"
};

            IList<string> strList2 = new List<string>() {
    "One",
    "Two",
    "Five",
    "Six"
};
            var innerJoin = strList1.Join(strList2, str1 => str1, str2 => str2,
                      (str1, str2) => str1);


            IList<Student> studentList = new List<Student>()
            {
        new Student() { StudentID = 1, StudentName = "John", Age = 18 , date=new DateTime(2015,12,01)  } ,
        new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 , date=new DateTime(2014,11,01) } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 , date=new DateTime(2012,08,01) } ,
        new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 , date=new DateTime(2015,12,01) } ,
        new Student() { StudentID = 5, StudentName = "Abram" , Age = 24 , date=new DateTime(2015,12,01) }
            };

            var t = studentList.Select(s => s.Age >= 20);

        }
        public static string testcodertype()
        {
            string str = "1234azAZ";

            bool ischar = false;
            foreach(var i in str)
            {
                if(i>=65 && i<=90 || i>=97 && i <= 122)
                {
                    ischar=true;
                    break;
                }
            }

            if (!ischar) return null;


            for (int i = 0; i < str.Length; i++)
            {
                int j = i + 1; int count = 0;

                while (j < str.Length)
                {
                    string temp = "";

                    while (i < str.Length && j < str.Length && str[i] == str[j])
                    {
                        temp += str[j];
                        i++; j++;
                        count++;
                    }

                    if (count > 1) return "Yes " + temp;

                    j++;

                }
            }
            return "no pattern";
        }

        public static void addStatic()
        {
          
        }


        public static bool IsAnagram(string s, string t)
        {

            string a = "tassr";

            IEnumerable<char> value = a.Where(x => x != 's');

            if (s.Length == 0 || t.Length == 0) return false;

            s = s.ToLower();
            t = t.ToLower();

            string str1 = "";
            string str2 = "";


            foreach (var item in s)
            {
                if (item >= 97 && item <= 122)
                    str1 += item;
            }
            foreach (var item in t)
            {
                if (item >= 97 && item <= 122)
                    str2 += item;
            }

            s = str1; t = str2;

            if (s.Length > t.Length) return false;

            Dictionary<char, int> hs = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (hs.ContainsKey(item))
                    hs[item] = ++hs[item];
                else
                    hs.Add(item, 1);
            }

            foreach (var item in t)
            {
                if (!hs.ContainsKey(item) || hs[item] < 1)
                {
                    return false;
                }
                else
                {
                    hs[item] = --hs[item];
                }
            }
            return true;

        }
        static void Main(string[] args)
        {

           

            Program.testcodertype();

            Program.testlinq();
            Program.IsAnagram("Tom Marvolo Riddle", "I am Lord Voldemort!");
            Console.WriteLine("Hello World!");

        }
    }
}
