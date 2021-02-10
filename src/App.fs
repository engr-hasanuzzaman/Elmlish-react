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
    prop.classes ["h-screen w-full flex items-center justify-center bg-teal-lightest font-sans";]
    prop.children [
      Html.div [
        prop.classes ["bg-white rounded shadow p-6 m-4 w-full lg:w-3/4 lg:max-w-lg";]
        prop.children [
          Html.div [
            prop.classes ["mb-4"]
            prop.children [
              RenderPageTitle "Todos"
              RenderTodoForm state dispatch
            ]
          ]

          Html.div [
            prop.children [
              RenderTodos state.Todos state dispatch
            ]
          ]
        ]
      ]
    ]
  ]

Program.mkSimple init Reducer.update render
|> Program.withReactSynchronous "app"
|> Program.run