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
        { state with Todos = state.Todos @ [{ Title = title; Status = false; Id = (AppState.TodoId (System.Guid.NewGuid( )) ) }] }
    | MarkComplete Id ->
        { state with Todos = List.filter (fun todo -> todo.Id <> Id) state.Todos}
    | UpdateTitle title -> { state with NewTodoTitle = title }