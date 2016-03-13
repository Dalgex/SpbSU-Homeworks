let rec multiplicationDigits number = 
    if (number < 10)
    then number
    else (number % 10) * multiplicationDigits (number / 10)

printfn "Произведение цифр в числе 8326 равно %d" (multiplicationDigits 8326)
printfn "Произведение цифр в числе 160347 равно %d" (multiplicationDigits 160347)