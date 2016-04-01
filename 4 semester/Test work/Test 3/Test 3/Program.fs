exception ErrorEmpty of string

type Stack<'a>() =
    let mutable list = []

    member s.Push item = list <- item :: list

    member s.Count = list.Length
    
    member s.IsEmpty = list = []

    member s.Contains(item) = List.exists (fun elem -> elem = item) list

    member s.Peek = 
        match list with
        | head :: tail -> list.Head
        | [] -> raise (ErrorEmpty("Стек пуст"))

    member s.Pop =
        match list with
        | head :: tail ->
            let result = list.Head
            list <- list.Tail
            result
        | [] -> raise (ErrorEmpty("Стек пуст"))


let stack = new Stack<int>();
stack.Push 5
stack.Push 0
stack.Push 10
stack.Push 3

printfn "Количество элементов в стеке - %d" stack.Count
printfn "Верхний элемент - %d" stack.Peek
printfn "Стек содержит 3 - %b" (stack.Contains 3)
printfn "Верхний элемент %d удален" stack.Pop
printfn "Стек содержит 3 - %b" (stack.Contains 3)
printfn "Верхний элемент - %d" stack.Peek
printfn "Верхний элемент %d удален" stack.Pop
printfn "Верхний элемент %d удален" stack.Pop
printfn "Количество элементов в стеке - %d" stack.Count
printfn "Стек пуст - %b" stack.IsEmpty
printfn "Верхний элемент %d удален" stack.Pop
printfn "Стек пуст - %b" stack.IsEmpty

try
    printfn "Верхний элемент %d удален" stack.Pop
with
    | ErrorEmpty(message) -> printfn "Ошибка! %s" message