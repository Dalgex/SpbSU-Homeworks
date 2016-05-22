let func1 x l = List.map (fun y -> y * x) l

let func2 x : List<int> -> List<int> = List.map (fun y -> y * x)

let func3 x : List<int> -> List<int> = List.map (fun y -> (*) x y)

let func4 : int -> List<int> -> List<int> = (fun y -> (*) y) >> List.map

let func5 : int -> List<int> -> List<int> = (*) >> List.map 