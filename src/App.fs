module App

open Elmish
open Elmish.React
open Feliz
open AppState
open Reducer
open Component

let init() =
    { 
      Todos = [{ Title = "Initial Todo"; Status = false; Id = (AppState.TodoId (System.Guid.NewGuid()))}]
      NewTodoTitle = "" 
    }
    
let render (state: State) (dispatch: Actions -> unit) =
  Html.div [
    RenderPageTitle "Todos"
    RenderTodos state.Todos state
    RenderTodoForm state dispatch
  ]

Program.mkSimple init Reducer.update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run