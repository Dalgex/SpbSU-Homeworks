let countEvenNumbers1 list = 
    let newList = list |> List.map (fun x -> (x + 1) % 2)
    List.sum newList

let countEvenNumbers2 list =
    let evenList = list |> List.filter (fun x -> x % 2 = 0)
    evenList.Length

let countEvenNumbers3 list = List.fold (fun acc x -> acc + (x + 1) % 2) 0 list

let testList = [6; 3; 1; 0; 4; 2; 3; 8; 10; 7]
printfn "Количество четных чисел в списке %A: " testList
printfn "map: %d" (countEvenNumbers1 testList)
printfn "filter: %d" (countEvenNumbers2 testList)
printfn "fold: %d" (countEvenNumbers3 testList)