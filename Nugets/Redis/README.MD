# Redis
https://github.com/MicrosoftArchive/redis
윈도우에서 사용하기 위해서 redis server 다운받아서 실행 해야함.

커스텀 클래스는 시리얼 라이즈 해서 넣어야함.
```csharp
var testEntity = new TestEntity
{
    Id = i,
    TestName = $"Test {i}"
};

var valueExists = cache.StringGet($"TestEntity:{i}");
if (valueExists.IsNull)
{
    var serializedObject = JsonConvert.SerializeObject(testEntity);
    cache.StringSet($"TestEntity:{i}", serializedObject);
}
```

다시 읽을때도 디 시리얼 라이즈 해야함.
```csharp
var value = cache.StringGet($"TestEntity:{i}");
if (value.IsNull == false)
{
    var serializedObject = JsonConvert.DeserializeObject<TestEntity>(value);
    Console.WriteLine($"Id : {serializedObject.Id} Name : {serializedObject.TestName}");
}
else
{
    Console.WriteLine($"Key : TestEntity:{i} not found");
}
```