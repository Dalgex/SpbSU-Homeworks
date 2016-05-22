open System.ComponentModel

let sumThreads = 
    let flags = Array.create 100 false
    let array = Array.create 1000000 1

    let mutable result = 0
    let number = 10000

    for i in 0..99 do
        let worker = new BackgroundWorker()
        worker.DoWork.Add(fun args -> 
                let rec sumElements arr =
                    match arr with
                    | head :: tail -> array.[head] + sumElements tail
                    | [] -> 0
                let startIndex = number * i
                let partialSum = sumElements [startIndex..startIndex + number - 1]
                args.Result <- box <| partialSum)

        worker.RunWorkerCompleted.Add(fun args -> 
                result <- result + (args.Result :?> int)
                flags.[i] <- true)
        
        worker.RunWorkerAsync()

    while (Array.exists(fun item -> not item) flags) do()
    result

printfn "%d" sumThreads
