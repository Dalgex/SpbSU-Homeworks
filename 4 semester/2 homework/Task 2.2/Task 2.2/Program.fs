let findNumberPosition list number = 
    let rec findIndex list counter =
        if (counter < List.length list)
        then if (List.head list = number)
             then counter
             else findIndex (List.tail list) (counter + 1)
        else -1
    findIndex list 0

let myList = [3; 7; 4; 5; 2; 6; 5; 4]
printfn "Начальный список: %A" myList
printfn "Первая позиция вхождения 5 - %d" (findNumberPosition myList 5)