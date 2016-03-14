let isPrime number = 
    let rec checkPrime number counter = 
        counter > number / 2 || (number % counter <> 0 && checkPrime number (counter + 1))
    checkPrime number 2

let seqAllPrimes = 
    Seq.filter (fun elem -> isPrime elem) (Seq.initInfinite (fun index -> if (index = 0) then 2 else index * 2 + 1))

printfn "Последовательность простых чисел: %A" seqAllPrimes