___________________________________________________________________
##			"���������� out"

���������� out ����� ��������� � ������ ���������� � ������ ������,
�� ��������� ��������� �������� ����������:
```
if (int.TryParse(input, out int result))
    WriteLine(result);
else
    WriteLine("Could not parse input");
```
*��������� ������������� ������ �������������� ��������� ����������


����� ��� ����������� ������������ � ������� Try. ����� ����������
bool ��������, ����������� �� ����� ��� �������, � ���������� out,
���������� ���������:
```
if (!int.TryParse(input, out int result))
{    
    return null;
}

return result;
```
___________________________________________________________________
##			"�������"

����� ������� ������ � ������� Item1 � Item2, ��������� ��������
������� ��������:
```
var letters = ("a", "b");
```
����� ������� ������, ������ ���� �������� ����� ������������� ���,
�������� Alpha � Beta:
```
(string Alpha, string Beta) letters = ("a", "b");
```
```
var letters = (Alpha: "a", Beta: "b");
```
```
(string First, string Second) letters = (Alpha: "a", Beta: "b");
```
*����� � ������ ����� ����������, Alpha � Beta, ������������


���������� ������ ������������� �������� � ����� �������:
```
public (int NUM, string ABC) Function()
{
    var num = 7;
    var abc = "days";

    return (num, abc);
}
```
��� ���������� (�������������) ��������� ������������� �������
������� ��� ��������� �������� � ������� ����������� ����������:
```
(int num, string abc) = Function();
```
������������� ����� ���������� ��� ������ ����. ��� �����
�������� ����� Deconstruct ��� ������� ������, ���������������
����� ���������� out ���� ����������� ���������:
```
public class Point
{
    public Point(double x, double y)
    {
        this.X = x; this.Y = y;
    }
    public double X { get; }
    public double Y { get; }

    public void Deconstruct(out double x, out double y)
    {
        x = this.X;
        y = this.Y;
    }
}
```
��������� ���� ����� ���������, �������� ������� ����� Point:
```
var p = new Point(3.14, 2.71);
(double X, double Y) = p;
```
___________________________________________________________________
##			"������ ����������"

���������� � ������ "_" ��������� ������ ��� ������ ��������,
������� �� ����������� � ���������� (���������� ��������).
�����������:
* ��� ������������� �������� ��� ���������������� �����.
* ��� ������ ������� � ����������� out.
* � �������� ������������� �������� � ����������� is � switch.
* � �������� ����������� ��������������, ����� ��������� ����
���������������� �������� ������������ ��� ������ ����������.
```
using static System.Console;

class Example
{
    public static void Main()
    {
        // � ������ ������ ����������� 3 ������������ ��������,
        // ������� ��� ������������� ������� ���������� ��������
        // �������������� ��� ������ ����������
        var (species, _, family, population) = Function("����");

        WriteLine("{0}: ��������� {1}, ����������� {2}",
            species, family, population);
    }

    private static (string, string, string, int)
        // ����� ���������� ������ �� 4 ���������
        Function(string species)
    {
        if (species == "����")
        {
            var genus  = "�������";
            var family = "�������";
            var population = 4000;

            return (species, genus, family, population);
        }
        if (species == "�������")
        {
            var genus  = "�������";
            var family = "�����������";
            var population = 50000;

            return (species, genus, family, population);
        }

        return ("", "", "", 0);
    }
}
// ����: ��������� �������, ����������� 4000
```
___________________________________________________________________
##			"���������� ���������"

������������� �������� ��������� ���������� ����� ��� ����� �
��������� ������, �� ��������� ��������� ������������.
�������������� ��������� is � switch, � ����� ��� ����������
������ � ������ ����� when.

��������� ������� is
�������� ����� ����� ����� ����� ������ ��������� �������� ��
������� ������������������ ���������� ����� ��������� ����������:
```
using System.Collections.Generic;

class Example
{
    public static void Main()
    {
        var sum  = DiceSum(new List<object> { 5, 1, 3 });
        // sum of values = 9

        var sum2 = DiceSum(new List<object> {
            new List<object> { 5, 1, 3 },
            new List<object> { 5, 1, 3 }
        });
        // sum of values (in all sublists) = 18
    }

    public static int DiceSum(IEnumerable<object> list)
    {
        var sum = 0;
        foreach (var item in list)
        {
            if (item is int val)
                sum += val;

            else if (item is IEnumerable<object> subList)
                sum += DiceSum(subList);
        }
        return sum;
    }
}
```

��������� ������������� �������� switch ��������� ��������
�������� ��� ���� ������������.
������� ��������� case ����� ��������, ������� ��� ��������
IEnumerable ������ ������������ ������ ������ ������, ������
������� ������������������:
```
using System;
using System.Linq;
using System.Collections.Generic;

class Example
{
    public static void Main()
    {
        var sum  = DiceSum(new List<object> { 5, 1, 3 });
        // sum of values = 9

        var sum2 = DiceSum(new List<object> {
            new PercentDigits(20, 1),
            new List<object> { 5, 1, 3 }
        });
        // sum of values (in all sublists) = 30
    }

    public static int DiceSum(IEnumerable<object> list)
    {
        var sum = 0;
        foreach (var item in list)
        {
            switch (item) {
                case int val:
                    sum += val; break;

                case PercentDigits digits:
                    // ������������ ������� ���� PercentDigits
                    sum += (digits.Tens + digits.Ones); break;

                case IEnumerable<object> subList when
                    subList.Any(): // ���� ������������������
                                   // �������� ��������
                    sum += DiceSum(subList); break;

                case IEnumerable<object> subList:
                    // ����� ������: �������� ����/�����������
                    break;


                case null: break;

                default: // ������ ����������� ���������
                    throw new InvalidOperationException
                        ("unknown item type");
            }
        }
        return sum;
    }
}

struct PercentDigits
{
    public int Ones { get; }
    public int Tens { get; }
    // (0, 1...9) + (0, 10...90) = 0...99
    public PercentDigits(int ones, int tens)
    {
        this.Ones = ones; this.Tens = tens;
    }
}
```
___________________________________________________________________
##			"��������� ���������� � ������������ �������� Ref"

������� ���������� ������ �� ���������� - ������� �������, �������
����� ��������, ������ �������� �� ���� �������:
```
using System;
using static System.Console;

class MatrixSearch
{
    public static void Main()
    {
        var matrix = new int[5, 10];
        for ((int i, int k) = (0, 0); i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = k++;

        // ref var ��������� ����������� ������� ��� �
        // ���� ������������ �������� �������� �������,
        // ���������� ���������� �������
        ref var item = ref MatrixSearch.Find(matrix,
                                             (val) => val == 42);
        WriteLine(item); // 42
        item = 24;
        WriteLine(matrix[4, 2]); // 24
        // ������������� ��������� � ������� ��������
    }

    // ����� ���������� ������ �� ���������� ��������� (�������� � �������)
    public static ref int Find(int[,] matrix,
                               Func<int, bool> predicate)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (predicate(matrix[i, j]))
                    return ref matrix[i, j];
            }
        }
        throw new InvalidOperationException("Not found");
    }
}
```
�����������:

1. ���������� ref ���������� ���������������� ��� ����������.
��������� �������� ���������� �� �������������.

2. ��������� ��������� ���������� ref ����������� ������������
�������� ������ ������.
��������� ������������ ��������� ����:
```
ref int i = sequence.Count();
```

3. ���������� ref ������ ���������� ������ ����������, �������
���������� ������������ ���� ����� ����, ��� ����� ����� ��������.
���������� ���������� ������ �� ��������� ���������� ���
���������� � ����������� ��������.

4. ������������ �������� � ��������� ���������� ref �� �����
�������������� � ������������ ��������.
�� ������, ����� ����������� ����� ���������� ��������,
����������� ����������, ��������� �� ����������, �� �������
��������� ������, ������������� ��������.
___________________________________________________________________
##			"��������� �������"

��������� ��������� ������ � ��������� ������� ������. ���������,
��� ��������� ����� ���������� ������ �� ���� ���������, � �������
�� ��� ��������:
```
using System;
using System.Collections.Generic;
using static System.Console;

class Example
{
    public static void Main()
    {
        // �������� ���������
        var resultSet = AlphabetSubset('c', 'a');
        WriteLine("iterator created");
        // ��������
        foreach (var thing in resultSet)
            Write($"{thing}, ");
    }

    // �������� ����� �� �������� ������� ���������,
    // ����� ���������� ���� (�������� ����������)
    // ���� �� ��������
    public static IEnumerable<char> AlphabetSubset(char start,
                                                   char end)
    {
        if (start < 'a' || start > 'z')
            throw new ArgumentOutOfRangeException(paramName:
                nameof(start), message: "start must be a letter");
        if (end < 'a' || end > 'z')
            throw new ArgumentOutOfRangeException(paramName:
                nameof(end), message: "end must be a letter");
        if (end <= start)
            throw new ArgumentException(
                $"{nameof(end)} must be greater than {nameof(start)}");

        // ���������� ��������� �������
        return alphabetSubsetImplementation();

        // ��������� ������� ������ ������������
        IEnumerable<char> alphabetSubsetImplementation()
        {
            for (var c = start; c < end; c++)
                yield return c;
        }
    }
}
```

� ����������� ������, ����������� ������ ����������, ������������
��� �������� ����������, �� ������ ����������� ������:
```
public Task<string> LongRunningWork(string address, int index,
                                    string name)
{
    if (string.IsNullOrWhiteSpace(address))
        throw new ArgumentException(message:
            "An address is required", paramName: nameof(address));
    if (index < 0)
        throw new ArgumentOutOfRangeException(paramName:
            nameof(index), message: "The index must be non-negative");
    if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException(message:
            "You must supply a name", paramName: nameof(name));

    return longRunningWorkImplementation();

    async Task<string> longRunningWorkImplementation()
    {
        var result1 = await FirstWork(address);
        var result2 = await SecondWork(index, name);
        return $"The results are {result1} and {result2}";
    }
}
```
___________________________________________________________________
##			"������ ��������, ����������� ���������"

