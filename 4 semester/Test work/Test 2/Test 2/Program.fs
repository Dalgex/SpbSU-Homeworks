let isPalindrome (number : int) =
    let list = List.ofArray (number.ToString().ToCharArray())
    let reverseList = List.rev list
    list = reverseList

let findMaxPalindrome number1 number2 =
    let rec findMax1 num1 num2 maximum =
        let rec findMax2 num1 num2 maximum =
            if ((num1 * num2 > maximum) && isPalindrome (num1 * num2)) then
                num1 * num2
            elif (num1 > 99) then
                findMax2 (num1 - 1) num2 maximum
            else
                maximum
        let localMax = max maximum (findMax2 num1 num2 maximum)
        if (num2 > 99) then
            findMax1 num1 (num2 - 1) localMax
        else
            localMax
    findMax1 number1 number2 -1

let maxPalindromeMultiplicationOfThreeDigitNumbers = findMaxPalindrome 999 999
printfn "%d" maxPalindromeMultiplicationOfThreeDigitNumbers