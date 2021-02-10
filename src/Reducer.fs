module Reducer

// type AddNew = AddNew of Title : string
// type MarkComplete = MarkComplete of Id : AppState.TodoId

type Actions = 
    | AddNew of Title : string
    | MarkComplete of Id : AppState.TodoId
    | UpdateTitle of title : string

   
let update (action: Actions) (state: AppState.State): AppState.State =
    match action with
    | AddNew title ->
        Fable.Core.JS.console.log("AddNew has been called with ", title)
        { state with Todos = state.Todos @ [{ Title = title; Status = false; Id = (AppState.TodoId (System.Guid.NewGuid( )) ) }]; NewTodoTitle = "" }
    | MarkComplete Id ->
        { state with Todos = List.map (fun (todo: AppState.Todo) -> if todo.Id = Id then ({todo with Status = true}) else todo) state.Todos }
    | UpdateTitle title -> { state with NewTodoTitle = title }