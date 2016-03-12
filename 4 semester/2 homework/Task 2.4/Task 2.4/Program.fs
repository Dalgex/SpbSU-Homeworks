let areDifferentAllElements list = 
    let containsNumber list number = List.exists (fun elem -> elem = number) list
    let rec areUniqueAllElements list =
        match list with
        | head :: tail when tail <> [] -> if (containsNumber tail head)
                                          then false
                                          else areUniqueAllElements tail
        | _ -> true
    areUniqueAllElements list

let list1 = [7; 4; 6; 10; 3; 2; 5; 1]
let list2 = [8; 2; 4; 3; 0; 1; 2; 5]
printfn "Все элементы в списке %A различны - %b" list1 (areDifferentAllElements list1)
printfn "Все элементы в списке %A различны - %b" list2 (areDifferentAllElements list2)