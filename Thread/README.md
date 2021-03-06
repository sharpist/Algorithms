## Что такое потоки в *C#*

____

**Поток *(Thread)* – это некая независимая последовательность инструкций для выполнения
того или иного действия в программе. В одном конкретном потоке выполняется одна
конкретная последовательность действий. Совокупность таких потоков, выполняемых в
программе параллельно называется многопоточностью.**

УСТАРЕЛО--->
*В действительности потоки выполняются всё-таки не совсем параллельно, по причине того,
что процессор физически не может обрабатывать параллельно несколько инструкций или
процессов. Однако, его вычислительной мощи хватает настолько, что он может выполнять
операции по небольшому фрагменту по очереди, отводя на каждый такой фрагмент по очень
маленькому отрезку времени, настолько, что кажется, будто все процессы выполняются
параллельно.*
<---УСТАРЕЛО

Подобная ситуация происходит и с потоками. Если в программе имеется 3 потока, то сперва
выполняется кусочек кода из одного потока, потом кусочек кода из другого, затем – из
третьего, после чего процессор снова переходит к какому-либо из двух других потоков.
Выбор, какой поток необходимо назначить для выполнения в данный момент остаётся за
процессором. Происходит это в доли миллисекунд и воспринимается как параллельная работа
потоков.

Чем больше потоков, тем выше вероятность, что они будут мешать друг другу выполнять
свою работу. Например, если заставить работать огромное количество потоков с одними и
теми же данными, потокам придётся выстраиваться в очередь для их обработки.

>В среде *.NET* существует два вида потоков: **основной и фоновый (вспомогательный).**

Главное отличие между ними одно – если первым завершится основной поток, тогда фоновые
потоки в его процессе будут также принудительно остановлены, если же первым завершится
фоновый поток, то это не повлияет на остановку основного потока – тот будет продолжать
функционировать до тех пор, пока не выполнит всю работу и самостоятельно не остановится.
**Обычно при создании потока ему по-умолчанию присваивается основной тип.**


## Как создавать потоки в *C#*

____

Для работы с потоками в *C#* необходимо подключить директиву:

```csharp
using System.Threading;
```

> Любой поток в *C#* должен обязательно происходить в каком-либо методе или функции.

Поэтому, для работы с новым потоком необходимо создать для него, например, метод,
который и будет являться точкой входа для этого потока.

Потоки начинают выполняться не сразу после их инициализации. **Каждый из созданных
потоков необходимо сначала запустить.**

```csharp
public static void Main(string[] args)
{
    var main = Thread.CurrentThread;
    main.Name = "Main";
    // Running
    Console.WriteLine($"Статус потока {main.Name}:\t{main.ThreadState}");


    // создаём новый поток
    var myThread = new Thread(new ThreadStart(() => {
        Thread.Sleep(1000); // имитируем работу
    }));
    myThread.Name = "MyThread";
    myThread.IsBackground = true;
    ///myThread.Priority = ThreadPriority.Highest;

    // Background, Unstarted
    Console.WriteLine($"Статус потока {myThread.Name}:\t{myThread.ThreadState}");
    // запускаем новый поток
    myThread.Start();

    // Background
    Console.WriteLine($"Статус потока {myThread.Name}:\t{myThread.ThreadState}");
    Thread.Sleep(1500);
    // Stopped
    Console.WriteLine($"Статус потока {myThread.Name}:\t{myThread.ThreadState}");

    /* Output:
        Статус потока Main:     Running
        Статус потока MyThread: Background, Unstarted
        Статус потока MyThread: Background
        Статус потока MyThread: Stopped
    */
}
```

Если один из потоков выполнит работу раньше другого, то первый будет ожидать окончания
выполнения работы последнего, по причине, описанной выше:  
*Так как оба потока являются основными, то завершение какого-либо одного потока не
влияет на завершение другого, в ином случае, когда один из потоков фоновый, то при его
“задержке” и окончании работы основного потока, принудительно завершится и он.*

____


