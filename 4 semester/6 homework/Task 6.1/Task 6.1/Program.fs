type RoundingBuilder(precision : int) =
    member this.Bind(x : float, f : float -> float) =
        f (System.Math.Round(x, precision))
    member this.Return(x : float) =
        System.Math.Round(x, precision)

let rounding precision = RoundingBuilder(precision)

let test =
    rounding 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }

printfn "%A" test
    
