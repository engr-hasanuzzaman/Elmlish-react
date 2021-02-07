module AppState

type TodoId = TodoId of System.Guid

type Todo =
    { 
        Id : TodoId
        Title : string 
        Status : bool
    }

type State =
    {
        Todos : Todo list
        NewTodoTitle : string
    }
