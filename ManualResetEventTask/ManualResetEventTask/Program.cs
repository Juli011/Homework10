 ManualResetEvent manualResetEvent= new ManualResetEvent(false);

int[] arr = new int[100000];
long sum = 0;
bool check = true;

Random rnd = new Random();
for(int i=0; i<arr.Length; i++)
{
    arr[i]= rnd.Next(1,20);
}

Thread thread1 = new Thread(() =>
{
    manualResetEvent.WaitOne();
    for(int i=0; i<arr.Length/4; i++)
    {
        sum += arr[i];
    }
});

Thread thread2 = new Thread(() =>
{
    manualResetEvent.WaitOne();
    for (int i = arr.Length/4; i<2*arr.Length/4; i++)
    {
        sum += arr[i];
    }
});

Thread thread3 = new Thread(() =>
{
    manualResetEvent.WaitOne();
    for (int i = 2*arr.Length/4; i<3*arr.Length/4; i++)
    {
        sum += arr[i];
    }
});

Thread thread4 = new Thread(() =>
{
    manualResetEvent.WaitOne();
    for (int i = 3*arr.Length/4; i<4*arr.Length/4; i++)
    {
        sum += arr[i];
    }
});

Thread thread5 = new Thread(() =>
{
    for (int i = 0; i<arr.Length; i++)
    {
        if (arr[i]>0)
        {
            check = true;
        }
        else
        {
            check = false;
            break;
        }
    }
    manualResetEvent.Set();
});


thread1.Start();
thread2.Start();
thread3.Start();
thread4.Start();
thread5.Start();

thread1.Join();
thread2.Join();
thread3.Join();
thread4.Join();
thread5.Join();

Console.WriteLine(sum);
