module Domain.Tasks

type MyTask = { Name: string; Description: string }

type ITaskStorage =
    abstract member Save: MyTask -> unit
    abstract member Get: string -> option<MyTask>

type TaskService(storage: ITaskStorage) =
    member s.Save name desc =
        { Name = name; Description = desc }
        |> storage.Save
    member s.Find name =
        name
        |> storage.Get
