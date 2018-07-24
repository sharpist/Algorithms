#			[C# 7.0](https://github.com/sharpist/C_Sharp/tree/master/7.0#c-70) | [C# 7.1](https://github.com/sharpist/C_Sharp/tree/master/7.1#c-71) | [C# 7.2](https://github.com/sharpist/C_Sharp/tree/master/7.2#c-72) | C# 7.3
#### ����������: ####

��������� ������������������ ����������� ����:

[�������������� ����� ```fixed``` ��� �����������](https://github.com/sharpist/C_Sharp/tree/master/7.3#��������������-�����-fixed-���-�����������)

[��������� ���������� ```ref``` ����� ���� �������������](https://github.com/sharpist/C_Sharp/tree/master/7.3#���������-����������-ref-�����-����-�������������)

[...](https://github.com/)

[...](https://github.com/)

[...](https://github.com/)

[...](https://github.com/)

��������� ������������ �������:

[...](https://github.com/)

[...](https://github.com/)

___________________________________________________________________
```
����������� ����������� �������������� ����������� ���� � 
����������� ������������ ���������� �����������.
```
##			"�������������� ����� ```fixed``` ��� �����������"

������������ ��������� ��������� � �������� �������������� �������
([������ �������������� �������](https://github.com/sharpist/C_Sharp/tree/master/Fixed#������-��������������-�������)):
```
unsafe struct MyBuffer
{
    public fixed int fixedBuffer[10];
}
```
� ����� ������ ������� C# ���������� ���������� ���������, �����
�������� ������ � ����� ������, �������� � ```fixedBuffer```:
```
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
```
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

