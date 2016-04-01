let seqOfOnes = Seq.initInfinite (fun index -> if (index % 2) = 1 then -1 else 1)

let seqOfNaturalNumbers = Seq.initInfinite (fun index -> index + 1)

let seqOfPairs = Seq.zip seqOfOnes seqOfNaturalNumbers

let resultSeq = Seq.map (fun (x, y) -> x * y) seqOfPairs

printfn "Последовательность натуральных чисел, где каждое второе умножено на -1:\n%A" resultSeq