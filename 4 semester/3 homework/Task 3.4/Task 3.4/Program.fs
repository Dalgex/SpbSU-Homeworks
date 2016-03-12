type Expression =
    | Number of int
    | Addition of Expression * Expression
    | Subtraction of Expression * Expression
    | Multiplication of Expression * Expression
    | Division of Expression * Expression

let rec calculate expression = 
    match expression with
    | Number value -> value
    | Addition(x, y) -> (calculate x) + (calculate y)
    | Subtraction(x, y) -> (calculate x) - (calculate y)
    | Multiplication(x, y) -> calculate x * calculate y
    | Division(x, y) -> if (calculate y = 0) then 0
                        else calculate x / calculate y

let expression = Division(Addition(Number 19, Number 9), Multiplication(Number 2, Subtraction(Number 10, Number 3)))
printfn "(19 + 9) / (2 * (10 - 3)) = %d" (calculate expression)