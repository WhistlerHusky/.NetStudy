# Task

```csharp
public async void Biz() // async void 이기 때문에 이 함수를 부르는 쪽에서 이 함수 호출이 언제 끝날지 알수가 없다.
    {
        await Foo();
    }
    public Task Foo()
    {
        return Task.Factory.StartNew(() =>
        {
            Task.Delay(2000); // 여기서 딜레이 되는동안 혹은 그 위쪽에서든 혹은 아래 콘솔 출력중 언제든지 Biz를 부른 함수 호출이 끝나면서 이 코드들은 절대 실행되지 않음)
            Console.WriteLine("Done!");
        });
    }
```