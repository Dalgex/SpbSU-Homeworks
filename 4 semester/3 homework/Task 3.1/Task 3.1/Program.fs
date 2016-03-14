let maxSumPosition1 (list : int list) = 
    let length = list.Length
    let rec findMaxSumPosition (list : int list) maxSum maxSumIndex = 
        match list.Length with
        | 1 | 0 -> maxSumIndex
        | _ -> if (maxSum < list.Head + list.Tail.Head) 
               then findMaxSumPosition list.Tail (list.Head + list.Tail.Head) (length - list.Length + 1)
               else findMaxSumPosition list.Tail maxSum maxSumIndex
    findMaxSumPosition list -1 -1

let maxSumPosition2 list = 
    let listOfSumCurrentAndNextElements = List.zip (0 :: list) (List.append list [0]) |> List.map (fun (x, y) -> x + y)
    let maxElement = List.max listOfSumCurrentAndNextElements
    List.findIndex (fun elem -> elem = maxElement) listOfSumCurrentAndNextElements

let testList = [5; 3; 1; 6; 9; 7; 2]
printfn "Исходный список: %A" testList
printfn "Позиция в списке, на которой сумма текущего и следующего элементов максимальна:"
printfn "Рекурсивная функция: %d" (maxSumPosition1 testList)
printfn "С помощью List.zip: %d" (maxSumPosition2 testList)