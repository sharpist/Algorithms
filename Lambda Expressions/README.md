___________________________________________________________________________________________

# "������-���������" � 
#### ��������� �������, � ������� ������� ����� ��������� ���� ��������� ��� �������� ���������. ####
___________________________________________________________________________________________

������� ������-���������:
```c#
delegate int del(int i);
static void Main()
{
    del myDelegate = x => x * x;
    int j = myDelegate(5); // j = 25
}
```

������� ��� ������ ���������:
```c#
using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        Expression<del> myET = x => x * x;
    }
}
```
___________________________________________________________________________________________

# "����������� ������-���������" � 
#### (���������� ����������� ���������) ����� ����� ��������� � ������� �������� ���� ```async``` � ```await```. ####
___________________________________________________________________________________________

��������, ��������� ��� �������� ���������� �������, ���������� � ��������� �����������
����� ```methodAsync```:
```c#
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button_Click(object sender, EventArgs e)
    {
        // methodAsync returns a Task
        await methodAsync();
        textBox.Text += "\r\nControl returned to Click event handler.\n";
    }

    private async Task methodAsync()
    {
        // the following line simulates a task-returning asynchronous process
        await Task.Delay(1000);
    }
}
```

����� �� ���������� ������� ����� �������� � ������� ������������ ������-���������:
```c#
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button.Click += async (sender, e) =>
        {
            // methodAsync returns a Task
            await methodAsync();
            textBox.Text += "\nControl returned to Click event handler.\n";
        };
    }

    private async Task methodAsync()
    {
        // The following line simulates a task-returning asynchronous process
        await Task.Delay(1000);
    }
}
```
*����������� ```async``` ����� ������� ���������� ������-���������
___________________________________________________________________________________________
# "������ � ����������� ���������� ��������" � 
#### ����� ��� ����� ```Count```, ������� ������� �������� ���� ```Func<T,TResult>``` ������������� �������. ####
___________________________________________________________________________________________

�������� ```Func``` ������� ��� ������������ ���������������� ���������:
```c#
Func<int, bool> myFunc = x => x == 5;
bool result = myFunc(4); // returns false of course
```
��������� ����� ����������� � ������� �������� � ������ �������� ������:
```c#
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
int oddNumbers = numbers.Count(n => n % 2 == 1); // 5, 1, 3, 9, 7
```

```c#
var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6); // all numbers up to 6
```
