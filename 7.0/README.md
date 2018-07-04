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

��������� is
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

���������� ��������� switch
