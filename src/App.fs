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
    Html.div [
      prop.children [
        for li in state.Todos do
          Html.div [
            prop.children [
              Html.text li.Title
              Html.input [
                prop.type' "checkbox"
                prop.value li.Status
              ]
            ]
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
        prop.valueOrDefault state.NewTodoTitle
        prop.onTextChange (fun str ->  dispatch ( UpdateTitle str ))
      ] 
    ]
    Html.button [
      prop.text "add new task"
      prop.onClick (fun _ -> dispatch (AddNew state.NewTodoTitle) )
    ]
  ]

Program.mkSimple init Reducer.update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run