exception ErrorEmpty of string

type PriorityQueue<'a>() =
    let mutable queue : list<(list<'a> * int)> = []

    let getFirst (x, y) = x
    let getSecond (x, y) = y

    member q.Enqueue value (priority : int) =
        let rec add count prefix (queueList : list<(list<'a> * int)>) = 
            if (count = queue.Length) then
                queue <- queue @ [[value], (priority)]
            elif (getSecond queueList.Head < priority) then
                queue <- List.rev prefix @ [[value], (priority)] @ queueList
            else
                add (count + 1) (queueList.Head :: prefix) queueList.Tail
        add 0 [] queue

    member q.Dequeue = 
        match queue with
        | head :: tail ->
            let result = getFirst queue.Head
            queue <- queue.Tail
            result
        | [] -> raise (ErrorEmpty("Очередь пуста"))

    member q.IsEmpty = queue.Length = 0

let queue = new PriorityQueue<int>()
queue.Enqueue 5 6
queue.Enqueue 8 3
queue.Enqueue 0 9
queue.Enqueue 5 1
queue.Enqueue 7 10
queue.Enqueue 10 9
queue.Enqueue 3 4
queue.Enqueue 2 7

while not queue.IsEmpty do
    printfn "%A" queue.Dequeue

try
    printfn "%A" queue.Dequeue
with
    | ErrorEmpty(message) -> printfn "Ошибка! %s" message