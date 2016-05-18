type StringBuilder() = 
    member this.Bind(str, f) = 
        match System.Int32.TryParse(str) with
        | (true, int) -> f int
        | _ -> None
     member this.Return(x) = Some(x)

let strexpr = StringBuilder()

let test1 = 
    strexpr {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }

let test2 = 
    strexpr {
        let! x = "1"
        let! y = "b"
        let z = x + y
        return z
    }

printfn "%A" test1
printfn "%A" test2