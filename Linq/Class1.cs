using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq
{
    public class LinqExample
    {
        public static void LinqOperation()
        {
            var numbers = Enumerable.Range(1, 4);
            var squares = numbers.Select(s => s * s);

            string sentence = "this is nice word";

            var count = sentence.Split().Select(x => x.Length);
            //Console.WriteLine(count);


            var wordswithlength = sentence.Split().Select(x => new { word = x, size = x.Length });

            Random rand = new Random();
            var randomNumber = Enumerable.Range(1, 10).Select(_ => rand.Next(10));
            Console.WriteLine(randomNumber);

            var sequences = new[] { "red,green,blue", "orange", "white,pink" };

            var selectseq = sequences.Select(s => s.Split(','));

            var selectMany = sequences.SelectMany(s => s.Split(','));

            string[] colors = { "red", "green", "gray" };
            string[] objects = { "house", "car", "bicycle" };

            //cross product 
            var pairs = sequences.SelectMany(_ => objects, (c, o) => new { color = c, sobject = o });

            var newnumber = Enumerable.Range(1, 10);
            var oddsquare = newnumber.Select(x => x * x).Where(y => y % 2 == 1);  // 1 ,9, 25,81

            //filter by type..

            object[] values = { 1, 2.5, 3, 4.56f };

            Console.WriteLine(values.OfType<float>());

            var ResultTask = newnumber.Select(x => x * x).Where(y => y % 2 == 0 && y < 50);

        }

        public static void Group()
        {
            var people = new List<People>
            {
                new People{Age=20,Name="Adam"},
                new People{ Age=36, Name="Boris"},
                     new People{Age=36,Name="Adam"},
                new People{ Age=18, Name="Boris"},
                     new People{Age=36,Name="clarie"},
                      new People{Age=20,Name="Adam"},
                new People{ Age=20, Name="jack"}

            };

            IEnumerable<IGrouping<int, People>> bygroup = people.GroupBy(p => p.Age);
            var bygroupwithage = people.GroupBy(p => p.Age < 30);

            var groupbyNameandAge = people.GroupBy(s => s.Age, s => s.Name);

            foreach (var item in groupbyNameandAge)
            {
                Console.WriteLine(item);
            }
        }

        public static void set()
        {
            int[] nums = { 1, 2, 3, 4, 5 };

            bool ans = nums.All(x => x > 0);

            bool ansAny = nums.Any(x => x < 2); // atleast any number

            var numbers = new[] { -3, -1, 3, 7, -3, 7 };

            var skiptake = numbers.Skip(2).Take(4);

            IEnumerable<int> dn = numbers.Where(i => i > 0);

            int count = 0;
            foreach (var item in dn)
            {
                count++;
            }

            var takewhile = numbers.TakeWhile(i => i > 10);
            Console.WriteLine();
        }

        public void Jsoncollection()
        {
            string json = @"{
                    gowtham:615,raju:780,kumar:177 
              }";
            //  Object rss = XObject.Parse(json);
        }

        public static void ElementOperation()
        {

            try
            {
                var numbers = new List<int> { 1, 2, 2, 2, 3 };

                var Efirst = numbers.First();
                // var wfirst = numbers.First(x => x > 10); //return error

                //var testf =numbers.FirstOrDefault(x => x > 30);
                // var singleordef = numbers.SingleOrDefault(t => t==2);

                Console.WriteLine(new int[] { 123, 34 }.SingleOrDefault(x => x == 123));
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Join()
        {
            var people = new Person[]
    {
        new Person("Jane", "jane@foo.com"),
        new Person("John", "john@foo.com"),
        new Person("Chris", string.Empty)
    };

            var records = new Record[]
    {
        new Record("jane@foo.com", "JaneAtFoo"),
        new Record("jane@foo.com", "JaneAtHome"),
        new Record("john@foo.com", "John1980")
    };

            var query = people.Join(records, x => x.Email, y => y.Mail,
        (person, record) => new { Name = person.Name, SkypeId = record.SkypeId });

            Console.WriteLine(query);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} has skype ID {item.SkypeId}");
            }

            var groupJoin = people.GroupJoin(
              records,
              x => x.Email,
              y => y.Mail,
              (person, recs) => new
              {
                  Name = person.Name,
                  SkypeIds = recs.Select(r => r.SkypeId).ToArray()
              }
          );
        }
    }
    public class Person
    {
        public string Name, Email;

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
    public class Record
    {
        public string Mail, SkypeId;

        public Record(string mail, string skypeId)
        {
            Mail = mail;
            SkypeId = skypeId;
        }
    }
    public class People
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public class Class1
    {
        delegate void Printer();

        public static int MaximumWealth(int[][] accounts)
        {
            int global = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < accounts[0].Length; j++)
                {
                    count += accounts[i][j];
                }

                global = Math.Max(count, global);
            }
            return global;
        }

        public static string RemoveOuterParentheses(string S)
        {
            //1021
            string str = "";

            int opencount = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    opencount++;

                    if (opencount > 1)
                        str += "(";
                }
                else if (S[i] == ')')
                {
                    opencount--;

                    if (opencount > 0)
                    {
                        str += ")";
                    }
                }
            }

            return str;
        }

        public static int LongestOnes(int[] nums, int k)
        {
            int start = 0;
            int end = 0;

            int maxLength = 0;

            while (end < nums.Length)
            {
                // System.out.println("start: " + start + " end: " + end);

                int currentNumber = nums[end];

                if (currentNumber == 0)
                {
                    k--;
                }

                while (k < 0)
                {
                    int startNumber = nums[start];
                    if (startNumber == 0)
                    {
                        k++;
                    }
                    start++;
                }

                maxLength = Math.Max(maxLength, end - start + 1);
                // System.out.println("maxLength: " + maxLength);
                end++;
            }
            return maxLength;
        }
        public static int MaximumPopulation(int[][] logs)
        {
            if (logs == null || logs.Length == 0)
                return 0;

            // pop[i]: number of population changed at ith year
            int[] pop = new int[2051];
            foreach (var log in logs)
            {
                pop[log[0]]++;
                pop[log[1]]--;
            }

            int res = 0, max = 0, curr = 0;
            for (int i = 1050; i < pop.Length; i++)
            {
                // actual population at ith year
                pop[i] += pop[i - 1];

                if (pop[i] > max)
                {
                    res = i;
                    max = pop[i];
                }
            }
            return res;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] output = new int[nums.Length];

            output[0] = nums[0];

            for (int k = 1; k < nums.Length; k++)
            {
                output[k] = output[k - 1] * nums[k];

            }
            int target = nums[nums.Length - 1];

            output[nums.Length - 1] = output[nums.Length - 2];
            for (int j = nums.Length - 2; j > 0; j--)
            {
                output[j] = output[j - 1] * target;
                target *= nums[j];
            }

            output[0] = target;
            return output;
        }

        public static int DigaonalSum(int[][] mat)
        {
            anotherTest(mat);
            int x = mat.Length;
            bool iseven = false;

            if (mat.Length % 2 == 0)
            {
                iseven = true;
            }
            int ans = 0;

            int i = 0;

            for (int j = mat[i].Length - 1; i < mat.Length;)
            {
                if (i <= mat[i].Length / 2)
                {
                    if (i == mat[i].Length / 2 && !iseven)
                    {
                        ans += mat[i][i];
                    }
                    else
                    {
                        ans += mat[i][i] + mat[i][j];
                    }
                }
                else
                {

                    ans += mat[i][j] + mat[i][i];
                }
                i++;
                j--;
            }
            return ans;
        }

        static int test(int[][] mat)
        {
            int j = mat.Length - 1; int ans = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                if (i == j)
                {
                    ans += mat[i][j];
                    j--;
                    continue;
                }
                else
                {
                    ans += mat[i][i] + mat[i][j];
                }

                j--;
            }

            return ans;
        }

        public static string SortSentence(string s)
        {
            string[] str = s.Split(' ');

            string ans = "";

            for (int i = 0; i < str.Length; i++)
            {

                for (int j = 0; j < str.Length; j++)
                {
                    string temp = str[j];


                    if (temp[temp.Length - 1] - '0' == i + 1)
                    {
                        ans += temp.Substring(0, temp.Length - 1);
                        if (i < str.Length - 1) ;
                        ans += " ";
                    }
                }
            }
            return ans;
        }

        static int anotherTest(int[][] mat)
        {
            int j = mat.Length - 1; int ans = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                ans += mat[i][i] + mat[i][j--];
            }

            if (mat.Length % 2 == 1)
            {

                ans -= mat[mat.Length / 2][mat.Length / 2];
            }

            return ans;
        }

        public static int MinOperations(int[] nums)
        {

            if (nums.Length <= 1) return 0;
            int n = nums.Length;
            int track = 0; int temp = 0;
            for (int i = 1; i < n; i++)
            {

                temp = nums[i];

                nums[i] = Math.Max(nums[i - 1] + 1, nums[i]);

                track += nums[i] - temp;
            }
            return track;
        }
        public static bool IsLongPressedName(string name, string typed)
        {
            int i = 0; int s = 0;
            while (i < name.Length)
            {
                char t = name[i];
                int j = i + 1;
                int count = 0;
                while (j < name.Length && t == name[j])
                {
                    j++;
                    count++;
                }
                int k = s;
                while (k < typed.Length && t == typed[k])
                {
                    count--;
                    k++;
                }
                s = k;

                i = j;
                if (count >= 0) return false;
            }


            return s == typed.Length;
        }

        public static bool detectCapitalUse(string word)
        {

            int n = word.Length;
            int cap = 0;

            for (int i = 0; i < n; i++)
                if (word[i] <= 90)
                    cap++;

            if (cap == n) return true;
            else if (cap == 1 && word[0] <= 90) return true;
            else return false;
        }
        public static string ModifyString(string s)
        {

            int n = s.Length;

            char[] temp = s.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                if (temp[i] == '?')
                {
                    int j = i;
                    int c = 97;
                    while ((j > 0 && temp[j - 1] == c) || (j < n - 1 && temp[j + 1] == c))
                    {
                        c++;
                    }

                    temp[i] = (char)c;
                }

            }

            return new String(temp);
        }

        public static void swap(char[] ans, int i, int r)
        {
            while (i < r)
            {
                char t = ans[i];
                ans[i] = ans[r];
                ans[r] = t;
                i++;
                r--;
            }
        }

        
       

        public static string reverseK(string s, int k)
        {
            char[] ans = s.ToCharArray();
            int n = ans.Length - 1;
            int i = 0;
            int r = k - 1;

            while (i < n && r <= n)
            {
                swap(ans, i, r);
                i += k;
                r = i + k - 1;
            }

            return new string(ans);
        }
        public static int NumTeams(int[] rating)
        {
            if (rating == null || rating.Length < 3)
                return 0;

            int cnt = 0;
            for (int i = 0; i < rating.Length; i++)
            {
                int leftSmaller = 0, leftLarger = 0, rightSmaller = 0, rightLarger = 0;

                for (int j = 0; j < rating.Length; j++)
                {
                    if (j == i)
                        continue;

                    if (rating[j] < rating[i])
                    {
                        if (j < i)
                            leftSmaller++;
                        else
                            rightSmaller++;
                    }
                    else
                    {
                        if (j < i)
                            leftLarger++;
                        else
                            rightLarger++;
                    }
                }
                cnt += leftSmaller * rightLarger + leftLarger * rightSmaller;
            }
            return cnt;
        }
    
        public static void Main(string[] arg)
        {
           // ReorderLogFiles(new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" });
            //ModifyString("j?qg??b");
            int[][] arr = new int[1][];

            arr[0] = new int[] { 7 };
            // arr[1] = new int[] { 3, 4, 6 };
            //arr[2] = new int[] { 6, 9, 6 };
            // arr[3] = new int[] { 9, 5, 8, 5 };


            DigaonalSum(arr);
            //MaximumWealth(arr);
            MaximumPopulation(arr);
            LongestOnes(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 2);
            ProductExceptSelf(new int[] { 2, 3, 4, 5 });
            NumTeams(new int[] { 2, 5, 3, 4, 1 });

            List<Printer> printers = new List<Printer>();
            int i = 0;

            for (; i < 10; i++)
            {
                printers.Add(
                delegate
                {
                    Console.WriteLine(i);
                });
            }

            foreach (var printer in printers)
            {
                printer();
            }

            LinqExample.ElementOperation();
            Console.ReadKey();
        }
    }
}
