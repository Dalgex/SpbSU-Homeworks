type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec treeHeight tree = 
    match tree with
    | Tip _ -> 1
    | Tree(_, left, right) -> 1 + max (treeHeight left) (treeHeight right)

let myTree = Tree(1, Tree(2, Tip(3), Tree(4, Tip(5), Tip(6))), Tree(7, Tip(8), Tip(9)))
printfn "Высота дерева равна: %d" (treeHeight myTree)