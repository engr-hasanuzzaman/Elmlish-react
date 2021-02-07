module App

open Elmish
open Elmish.React
open Feliz
open AppState
open Reducer

let init() =
    { 
      Todos = [{ Title = "Initial Todo"; Status = false; Id = (AppState.TodoId (System.Guid.NewGuid()))}]
      NewTodoTitle = "" 
    }

let RenderTodo (todo: Todo) =
  Html.div [
    prop.classes ["rounded"; "border-blue-500"; "border-2"; "flex"; "h-10"; "items-center"; "pl-5";]
    prop.children [
      Html.text todo.Title
      Html.input [
        prop.type' "checkbox"
        prop.value todo.Status
        prop.classes ["ml-5"]
        // prop.onChange (fun (e: Browser.Types.HTMLInputElement) -> (MarkComplete li.Id) >> di)
      ]
    ]
  ]

let RenderPageTitle (title: string) = 
  Html.h1 [
    prop.classes []
    prop.text title
  ]

let RenderTodos (todos: Todo list) (state : State) =
  Html.div [
    prop.classes []
    prop.children [
       for todo in state.Todos -> RenderTodo todo         
      ]
    ]


let RenderTodoForm (state : State) (dispatch: Reducer.Actions -> unit) =
  Html.div [
    prop.classes []
    prop.children [
      Html.label [
        prop.text "Input Title"
      ]
      Html.input [
        prop.type' "text"
        prop.placeholder "input subject"
        prop.valueOrDefault state.NewTodoTitle
        prop.onTextChange (fun str ->  dispatch ( UpdateTitle str ))
      ]
      Html.button [
        prop.text "add new task"
        prop.onClick (fun _ -> dispatch (AddNew state.NewTodoTitle) )
      ]
    ]
  ]
    
let render (state: State) (dispatch: Reducer.Actions -> unit) =
  Html.div [
    RenderPageTitle "Todos"
    RenderTodos state.Todos state
    RenderTodoForm state dispatch
  ]

Program.mkSimple init Reducer.update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run