module Domain.Tasks

type MyTask = { Name: string; Description: string }

type ITaskStorage =
    abstract member SaveTask: MyTask -> unit
    abstract member GetTask: string -> MyTask

let Task name desc =
    { Name = name; Description = desc }

let Save (storage: ITaskStorage) name desc =
    Task name desc 
    |> storage.SaveTask
    
let Find (storage: ITaskStorage) name =
    name
    |> storage.GetTask