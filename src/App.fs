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

let render (state: State) (dispatch: Reducer.Actions -> unit) =
  Html.div [
    Html.h1 [
      prop.text "My Study topics"
    ]
    Html.ul [
      prop.children [
        Html.li [
          prop.text "foo"
        ]
      ]
    ]
    Html.div [
      Html.label [
        prop.text "Input Title"
      ]

      Html.input [
        prop.type' "text"
        prop.placeholder "input subject"
        prop.value state.NewTodoTitle
        // prop.onChange (fun e ->  dispatch UpdateTitle)
      ]
    ]
  ]

Program.mkSimple init Reducer.update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run