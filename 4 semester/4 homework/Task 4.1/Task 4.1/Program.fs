let isCloseBracket symbol = symbol = ')' || symbol = '}' || symbol = ']'

let reverseBracket bracket =
    match bracket with
    | ')' -> '('
    | ']' -> '['
    | '}' -> '{'
    | _ -> '_'

let isStringCorrect string =
    let rec check string stack =
        match string with
        | head :: tail when head = '(' || head = '[' || head = '{' -> check tail (head::stack)
        | head :: tail -> 
            if (isCloseBracket head)
            then if (stack.IsEmpty) then false
                 elif (reverseBracket head <> List.head stack) then false
                 else check tail stack.Tail
            else check tail stack
        | [] -> true
    check string []

printfn "Введите строку: "
let list = List.ofArray (System.Console.ReadLine().ToCharArray())
printfn "Скобочная последовательность корректна - %b" (isStringCorrect list)