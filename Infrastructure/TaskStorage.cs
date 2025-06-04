using Domain;

namespace Infrastructure;

public sealed class TaskStorage : Tasks.ITaskStorage
{
    private readonly List<Tasks.MyTask> _tasks = [];
    
    public void SaveTask(Tasks.MyTask task)
    {
        _tasks.Add(task);
    }

    public Tasks.MyTask GetTask(string name)
    {
        return _tasks.First(t => t.Name == name);
    }
}