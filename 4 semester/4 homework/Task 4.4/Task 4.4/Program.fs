type Operation = char

type Expression =
| Variable of char
| Constant of float
| MathExpression of Expression * Operation * Expression

let rec derivative expression = 
    match expression with
    | Constant _ -> Constant 0.0
    | Variable _ -> Constant 1.0
    | MathExpression (expr1, operation, expr2) ->
        match operation with
        | '+' | '-' -> MathExpression(derivative expr1, operation, derivative expr2)
        | '*' -> MathExpression(MathExpression(derivative expr1, '*', expr2), '+', MathExpression(expr1, '*', derivative expr2))
        | '/' -> MathExpression(MathExpression(MathExpression(derivative expr1, '*', expr2), '-', MathExpression(expr1, '*', derivative expr2)), '/', MathExpression(expr2, '*', expr2))
        | _ -> Constant 0.0

let rec simplification expression =
    match expression with
    | Constant _ -> expression
    | Variable _ -> expression
    | MathExpression(expr1, operation, expr2) ->
        
        let left = simplification expr1
        let right = simplification expr2

        match operation with
        | '+' -> 
            match (left, right) with
            | (Constant 0.0, right) -> right
            | (left, Constant 0.0) -> left
            | (Constant a, Constant b) -> Constant (a + b)
            | _ -> MathExpression(left, '+', right)
        
        | '-' ->
            match (left, right) with
            | (Constant 0.0, right) -> simplification (MathExpression(Constant -1.0, '*', right))
            | (left, Constant 0.0) -> left
            | (Constant a, Constant b) -> Constant (a - b)
            | _ -> MathExpression(left, '-', right)
        
        | '*' ->
            match (left, right) with
            | (Constant 0.0, expr2) -> Constant 0.0
            | (expr1, Constant 0.0) -> Constant 0.0
            | (Constant 1.0, right) -> right
            | (left, Constant 1.0) -> left
            | (Constant a, Constant b) -> Constant (a * b)
            | _ -> MathExpression(left, '*', right)

        | '/' ->
            match (left, right) with
            | (Constant 0.0, right) -> Constant 0.0
            | (left, Constant 0.0) -> failwith "Невозможно деление на ноль"
            | (left, Constant 1.0) -> expr1
            | (Constant a, Constant b) -> Constant (a / b)
            | _ -> MathExpression(left, '/', right)

        | _ -> MathExpression(left, operation, right)

let rec expressionToString expression = 
    match expression with
    | Constant a -> a.ToString()
    | Variable x -> x.ToString()
    | MathExpression(expr1, operation, expr2) -> "(" + (expressionToString expr1) + operation.ToString() + (expressionToString expr2) + ")"

let expr = MathExpression(MathExpression(Constant 0.0, '-', MathExpression(Variable 'x', '*', MathExpression(Constant 5.0, '/', Constant 2.0))), '-', MathExpression(Constant 1.0, '/', Variable 'x'))
printfn "Выражение:"
printfn "%s" (expressionToString expr)
printfn "Упрощение выражения:"
printfn "%s" (expressionToString (simplification expr))
printfn "Взятие производной:"
printfn "%s" (expressionToString (derivative expr))
printfn "Упрощение выражение после взятия производной"
printfn "%s" (expressionToString (simplification (derivative expr)))