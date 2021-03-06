#			[C# 7.0](https://github.com/sharpist/C_Sharp/tree/master/7.0#c-70) | [C# 7.1](https://github.com/sharpist/C_Sharp/tree/master/7.1#c-71) | [C# 7.2](https://github.com/sharpist/C_Sharp/tree/master/7.2#c-72) | C# 7.3
#### ����������: ####

��������� ������������������ ����������� ����:

[�������������� ����� fixed ��� �����������](https://github.com/sharpist/C_Sharp/tree/master/7.3#��������������-�����-fixed-���-�����������)

[��������� ���������� ref ����� ���� �������������](https://github.com/sharpist/C_Sharp/tree/master/7.3#���������-����������-ref-�����-����-�������������)

[������� stackalloc ������������ ��������������](https://github.com/sharpist/C_Sharp/tree/master/7.3#�������-stackalloc-������������-��������������)

[������ ����� ������������ ���������� fixed](https://github.com/sharpist/C_Sharp/tree/master/7.3#������-�����-������������-����������-fixed)

[����������� ������������� �����������](https://github.com/sharpist/C_Sharp/tree/master/7.3#�����������-�������������-�����������)

��������� ������������ �������:

[��������� == � != ��� ��������](https://github.com/sharpist/C_Sharp/tree/master/7.3#���������--�--���-��������)

[����������� ��������� � ��������� ����� ��� ������������� ����������� �������](https://github.com/sharpist/C_Sharp/tree/master/7.3#�����������-���������-�-���������-�����-���-�������������-�����������-�������)

[�������� ��� ���������� ���������� ������ in](https://github.com/sharpist/C_Sharp/tree/master/7.3#��������-���-����������-����������-������-in)

[���������� ���������� ��������� � ���������������](https://github.com/sharpist/C_Sharp/tree/master/7.3#����������-����������-���������-�-���������������)

[���������� ����� ������������� ����������](https://github.com/sharpist/C_Sharp/tree/master/7.3#����������-�����-�������������-����������)

����� ��������� �����������:

[�������� ����������� publicsign](https://github.com/sharpist/C_Sharp/tree/master/7.3#��������-�����������-publicsign)

[�������� ����������� pathmap](https://github.com/sharpist/C_Sharp/tree/master/7.3#��������-�����������-pathmap)

___________________________________________________________________
#### ��������� ������������������ ����������� ���� ####
```
����������� ����������� �������������� ����������� ���� � 
����������� ������������ ���������� �����������.
```

##			"�������������� ����� ```fixed``` ��� �����������"

������������ ��������� ��������� � �������� �������������� �������
([������ �������������� �������](https://github.com/sharpist/C_Sharp/tree/master/Fixed#������-��������������-�������)):
```c#
unsafe struct MyBuffer
{
    public fixed int fixedBuffer[10];
}
```
� ����� ������ ������� C# ���������� ���������� ���������, �����
�������� ������ � ����� ������, �������� � ```fixedBuffer```:
```c#
// �������� fixed ������������� ��������� �� ������ �������
unsafe void AccessMyBuffer()
{
    fixed (int* intPtr = myBuffer.fixedBuffer)
    {
        int p = intPtr[5];
    }
}
```
������ ����� ��� ������������� � ���������� ���������, �� ���������
��������� ������ ������������� ��������� ```int* intPtr``` �� ```fixedBuffer```.
�������� ```unsafe``` ��-�������� �������� ������������.

���������� ```p``` ���������� � ������ �������� � ```fixedBuffer```. ��� �����
�� ����� ��������� ��������� ���������� ```int*```.
```c#
class MyClass
{
    MyBuffer myBuffer = default;

    unsafe void AccessMyBuffer()
    {
        int p = myBuffer.fixedBuffer[5];
    }
}
```
___________________________________________________________________
##			"��������� ���������� ```ref``` ����� ���� �������������"

�� ������ C# 7.3 ��������� ��������� ���������� ([������������ ��������� ��������](https://github.com/sharpist/C_Sharp/tree/master/Ref%20returns#������������-���������-��������-�-���������-���������-����������)) �� ���������������
����� ������������� ���, ����� ��� ��������� �� ������ ���������.
������ ��������� ���������� ```ref``` ����� ������������� ������
����������� ����� �������������:
```c#
// �������������
ref VeryLargeStruct refLocal = ref veryLargeStruct;
// ��������������, refLocal ��������� �� ������ ���������
refLocal = ref anotherVeryLargeStruct;
```
___________________________________________________________________
##			"������� ```stackalloc``` ������������ ��������������"

��������� ������������� ��������� � ������� ��������������, ������
�������� � ��������, � ���������� ������� ���� ```stackalloc``` ([stackalloc](https://github.com/sharpist/C_Sharp/tree/master/Stackalloc#stackalloc)):
```c#
var arr = new int[3] {1, 2, 3};
var arr2 = new int[] {1, 2, 3};

int* pArr = stackalloc int[3] {1, 2, 3};
int* pArr2 = stackalloc int[] {1, 2, 3};
```
___________________________________________________________________
##			"������ ����� ������������ ���������� ```fixed```"

�������� ```fixed``` �������� � ��������������� ������, ������ ��������,
�����, ������� �������������� ������� � ������������� ����������,
����� ��������� ��� ```System.Span<T>``` � ��������� �����.

����� ���, ����������� ����� ```GetPinnableReference```, �������
���������� ```ref T``` ��� ```ref readonly T```, ����� �������������
(```GetPinnableReference``` ������ ��������������� ���������� ```ref``` �
������������� ���).
___________________________________________________________________
##			"����������� ������������� �����������"

����� ������� ��� ```System.Enum``` ��� ```System.Delegate``` � ��������
����������� �������� ������ ��� ��������� ����.

�������� ����� ����������� ```unmanaged```, ����� �������, ��� ��������
���� ������ ���� ������������� �����.

#### ```������������� ���``` � ��� ���, ������� �� �������� ��������� � �� ####
#### �������� �� ������ ���������� ���� �� ����� ������ ��������. ####
___________________________________________________________________
#### ��������� ������������ ������� ####

##			"��������� ```==``` � ```!=``` ��� ��������"

���� �������� � C# ������ ������������ ��������� ```==``` � ```!=``` ����������
���� ��������� ������� �������� ������ ��������� � ������
��������� ������� ��������� �� �������.

�������� ```==``` �������� ���������� ��������, ��� ������ �����
���������� �������� ����.
�������� ```!=``` �������� ���������� ��������, ��� ������ �����
���������� ������ ����.
```c#
var left  = (a: 5, b: 10);
var right = (a: 5, b: 10);
Console.WriteLine(left == right); // true
```

���� ���� �� �������� ��������� �������� ```NULL```, ������� ��������
�������� �� ��������� ��������� ������� ��������������:
```c#
var left = (a: 5, b: 10);
var right = (a: 5, b: 10);
(int a, int b)? nullableTuple = right;
Console.WriteLine(left == nullableTuple); // true
```
������������� ����������� ������� �������������� ������� ��������
����� �������� (�������������� ��� ������������� ����, �����������
�������� ```NULL```, ����������� �������������� � ������ �������
��������������):
```c#
var left = (a: 5, b: 10);
(int? a, int? b) nullableMembers = (5, 10);
Console.WriteLine(left == nullableMembers); // true

(long a, long b) longTuple = (5, 10);
Console.WriteLine(left == longTuple); // true

(long a, int b) longFirst = (5, 10);
(int a, long b) longSecond = (5, 10);
Console.WriteLine(longFirst == longSecond); // true
```
����� ��������� �������� �� ��������� � ������ �� ���������.
���� ���� �� ��������� �������� ��������� ������� � ������ �������,
���������� ���������� ��������������:
```c#
(int a, string b) pair    = (1, "Hello");
(int z, string y) another = (1, "Hello");

// ����� ��������� �� ���������
Console.WriteLine(pair == another); // true
// ������� �������� ��������� ����� ����������
Console.WriteLine(pair == (z: 1, y: "Hello")); // warning
```
������� ����� ��������� ��������� �������. ������� ��������
�������� �� ��������� ���������� "�����" ������� �������� ��
��������� ��������:
```c#
(int, (int, int)) nestedTuple = (1, (2, 3));
Console.WriteLine(nestedTuple == (1, (2, 3)) ); // true
```
___________________________________________________________________
##			"����������� ��������� � ��������� ����� ��� ������������� ����������� �������"

������� �������� ```field``` ������������� ������� ([��������](https://github.com/sharpist/C_Sharp/tree/master/Attributes#��������)) ��������� ����������
������������� ������������ ��������.
�������������� ��������� ���������:
```c#
[field: SomeThingAboutFieldAttribute]
public int SomeProperty { get; set; }
```
������� ```SomeThingAboutFieldAttribute``` ����������� � ���������� ����,
���������� ������������ ��� ```SomeProperty```.
___________________________________________________________________
##			"�������� ��� ���������� ���������� ������ ```in```"

��������� ��������������� ��� ���������� ������������ ��������� ```in``` ([C# 7.2](https://github.com/sharpist/C_Sharp/tree/master/7.2#�����������-in)):
```c#
static void M(S arg);
static void M(in S arg);
```
���������� �� �������� (������ � �������) ��������� �����, ���
���������� �� �������� "������ ��� ������".

��� ������ ������ �� ��������� ���������� "������ ��� ������",
���������� ��� ������ ������ ������� ����������� ```in```.
___________________________________________________________________
##			"���������� ���������� ��������� � ���������������"

���������, ����������� � ������ C# 7.0 ([C# 7.0](https://github.com/sharpist/C_Sharp/tree/master/7.0#����������-out)) ��������� ���������� ```out```,
������������ �������������� �����, �������������� �������,
�������������� ������������ � ����������� �������.
```c#
public class B
{
    // ����������� ����� �������� 'j'
    public B(int i, out int j)
        => j = i;
}

public class D : B
{
    // ���������� ������� �����������
    public D(int i) : base(i, out var j)
    {
        Console.WriteLine($"�������� 'j' ����� {j}");
    }
}
```
___________________________________________________________________
##			"���������� ����� ������������� ����������"

#### ��������� ��� ������� ���������� ����������: ####

1. ���� ������ ������� �������� �������� ���������� � �����������
��������:

* ���������� ��������� ��� �������� ���������� ��� ������
������ ��� ����������-���������� � ��� ��������� ����������.

* ���������� ��������� ����������� ��������, ���� ����� ��� ������ �
�����������-�����������.

���� ���������� �� ������, ���������� �������� � �����������
�������� ������ ����������� ��������, � � ��������� ������ � 
����������� �������� � �������� ����������.

���� ���������� ���������� ���������� ���������� ��� ��������� ���
���, ���������� �������� � ��, � ������ ��������.

����������� ��������, � ������� ������� ```this``` ���������-����������
������ ������������, ������� ���� ������, ��� ������� ```this``` ��
������, ��� �������� ����������� ��������, � ����� �������, ���
```this``` �� ����� ��������������, ����� ��� �������������� ����� �
�������������� �������������.

2. ���� ������ ������� �������� ��������� ������������� ������, �
������� ��������� ���� �� ������������� ������������, �����
�������� ��������� �� ������ ����������.

3. ��� �������������� ������ ������� �� ������ ���������
������-���������, � ������� ������������ ��� �� �������������
������������� ���� ��������.
___________________________________________________________________
#### ����� ��������� ����������� ####

##			"�������� ����������� ```publicsign```"

�������� ����������� ```-publicsign``` ���������, ��� ������ �����
��������� �������� ������, ���������� �� ���������� ������, ������
���������� ��� ����������� (����� � ������ ���, ������� ��������
����� ����������, ��� ���� ��������).

��������� ��������� ����������� ������ �� �������� � �������� �����
� ������� ��������� �����.

� ���������� ```-publicsign``` ���������� ������������ �������� ```-keyfile```
��� ```-keycontainer``` (������ ���������� �������� ����).
��������� ```-publicsign``` � ```-delaysign``` � �����������������.

��� ����� ������������ � ������ ����������� �������� ����,
��������������� ���� "���������", ���� ���������� ������ ��
������������� �������� ������.
����� ������ �������� "��������� �������������" ���
"������������� OSS", ����������� �� �������� � �������� ��������
�����.

��������� ��������� � ����� ���������� Visual Studio:

1. ������� �������� ������� �������.

2. �������� �������� ```Delay sign only```.
___________________________________________________________________
##			"�������� ����������� ```pathmap```"

�������� ����������� ```-pathmap``` ���������� ������ �������������
���������� ����� � ������� �������� �����, ���������� ������������,
��������� ��������� ������, ������� ���������� ���������� �
PDB-����� ��� ��� ```CallerFilePathAttribute```.
```c#
-pathmap:path1=sourcePath1,path2=sourcePath2
```
#### ���������: ####

* ```path1``` � ������ ���� � �������� ������ � ������� ���������.

* ```sourcePath1``` � �������� ���� ������������� ������ path1 � �����
�������� ������.

*��������� �������� ��� �������� ���������� �������������� ��������
�����


���������� ���������� �������� ���� � �������� ������ �� ���������
��������:

1. �������� ���� ������������� ������ ���������, �����
```CallerFilePathAttribute``` ����������� ��� �������������� ��������.

2. �������� ���� ���������� ��� PDB-����.

3. ���� � PDB-����� ���������� � PE-���� (����������� �����������
����).

���� �������� ������������ ������ ���������� ���� �� ����������,
��� ����������� ����������, � ��������������� �����, �������
������ ���� ������� � �������� �����.

#### ���������� ```t.cs``` � �������� ```C:\work\tests``` � ������������� ����� ####
#### �������� � ��������� ```\publish``` � �������� ������: ####
```c#
csc -pathmap:C:\work\tests=\publish t.cs
```
