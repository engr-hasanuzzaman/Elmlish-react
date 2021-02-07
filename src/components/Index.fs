module Component

open Feliz
open Reducer
open AppState

let RenderTodo (todo: Todo) =
  Html.div [
    prop.classes ["flex"; "mb-4"; "items-center"]
    prop.children [
      Html.p [
        prop.classes ["w-full"; "text-grey-darkest"]
        prop.text todo.Title
      ]
      if not todo.Status then
          Html.button [
            prop.classes ["flex-no-shrink p-2 ml-4 mr-2 border-2 rounded hover:text-white text-green border-green hover:bg-green"]
            prop.text "Done"
            // prop.onChange (fun (e: Browser.Types.HTMLInputElement) -> (MarkComplete li.Id) >> di)
          ]
      else
          Html.button [
            prop.classes ["flex-no-shrink p-2 ml-4 mr-2 border-2 rounded hover:text-white text-grey border-grey hover:bg-grey"]
            prop.text "Not Done"
            // prop.onChange (fun (e: Browser.Types.HTMLInputElement) -> (MarkComplete li.Id) >> di)
          ]
    ]
  ]


let RenderPageTitle (title: string) = 
  Html.h1 [
    prop.classes ["text-grey-darkest"]
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
    prop.classes ["flex mt-4"]
    prop.children [
      Html.label [
        prop.text "Input Title"
      ]
      Html.input [
        prop.classes ["shadow"; "appearance-none"; "border"; "rounded"; "w-full"; "py-2"; "px-3"; "mr-4"; "text-grey-darker"]
        prop.type' "text"
        prop.placeholder "input subject"
        prop.valueOrDefault state.NewTodoTitle
        prop.onTextChange (fun str ->  dispatch ( UpdateTitle str ))
      ]
      Html.button [
        prop.classes ["flex-no-shrink"; "p-2 border-2"; "rounded"; "text-teal"; "border-teal"; "hover:text-white"; "hover:bg-teal"]
        prop.text "add new task"
        prop.onClick (fun _ -> dispatch (AddNew state.NewTodoTitle) )
      ]
    ]
  ]