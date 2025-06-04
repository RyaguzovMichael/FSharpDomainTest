module Domain.Tasks

type MyTask = { Name: string; Description: string }

type ITaskStorage =
    abstract member SaveTask: MyTask -> unit
    abstract member GetTask: string -> option<MyTask>
    
let Save (storage: ITaskStorage) name desc =
    { Name = name; Description = desc } 
    |> storage.SaveTask
    
let Find (storage: ITaskStorage) name : option<MyTask> =
    name
    |> storage.GetTask