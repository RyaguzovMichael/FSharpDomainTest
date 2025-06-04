using Microsoft.FSharp.Core;
using static Domain.Tasks;

namespace Infrastructure;

public sealed class TaskStorage : ITaskStorage
{
    private readonly Dictionary<string, MyTask> _tasks = [];

    public void Save(MyTask task)
    {
        _tasks.Add(task.Name, task);
    }

    public FSharpOption<MyTask> Get(string name)
    {
        return _tasks.TryGetValue(name, out var task)
            ? FSharpOption<MyTask>.Some(task)
            : FSharpOption<MyTask>.None;
    }
}