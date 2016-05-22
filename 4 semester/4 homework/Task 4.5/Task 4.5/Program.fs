type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec treeMap tree func = 
    match tree with
    | Tip a -> Tip (func a)
    | Tree(a, left, right) -> Tree(func a, treeMap left func, treeMap right func)

let rec treeToString tree =
    match tree with
    | Tip a -> a.ToString() + " "
    | Tree(a, left, right) -> (treeToString left).ToString() + a.ToString() + " " + (treeToString right).ToString()

let myTree = Tree(1, Tree(2, Tip(3), Tip(4)), Tree(5, Tip(6), Tip(7)))
let testMap = fun x -> x + 1

printfn "Начальное дерево: %s" (treeToString myTree)
printfn "Дерево после применения функции к каждому элементу: %s" (treeToString (treeMap myTree testMap))