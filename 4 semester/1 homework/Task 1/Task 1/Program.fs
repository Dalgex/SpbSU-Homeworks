﻿let factorial n = List.fold(fun x acc -> x * acc) 1 [1..n]

let rec fibonacci n =
    if (n < 2)
    then n
    else fibonacci(n - 1) + fibonacci(n - 2)

let reverseList list = List.fold (fun acc listElement -> listElement::acc) [] list

let formList number = 
    let powersList n = 
        let powerOfTwo value = pown 2 value
        List.init n (fun index -> powerOfTwo (number + index))
    powersList 5
