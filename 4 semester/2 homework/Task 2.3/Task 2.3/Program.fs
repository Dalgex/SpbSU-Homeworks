let isPalindrome (str : string) =
    let list = List.ofArray (str.ToCharArray())
    let reverseList = List.rev list
    list = reverseList

printfn "Введите слово:"
let str = System.Console.ReadLine()
printfn "Это слово является палиндромом - %b" (isPalindrome str)