let searchPhoneByName listOfNames listOfPhones name =
    let listOfPairs =  List.zip listOfNames listOfPhones
    let searchPairsByName = List.filter (fun (x, y) -> x = name) listOfPairs
    List.map (fun (x, y) -> y) searchPairsByName

let searchNameByPhone listOfNames listOfPhones phone =
    let listOfPairs =  List.zip listOfNames listOfPhones 
    let searchPairByPhone = List.filter (fun (x, y) -> y = phone) listOfPairs
    List.map (fun (x, y) -> x) searchPairByPhone

let addRecordName listOfNames =
   let name = System.Console.ReadLine()
   name :: listOfNames

let addRecordPhone listOfPhones =
   let number = System.Console.ReadLine()
   number :: listOfPhones

let createListOfNames listOfNamesAndPhones = 
    let rec buildListOfNames listOfNamesAndPhones listOfNames = 
        match (listOfNamesAndPhones : List<string>) with
        | head :: tail -> 
            let str = List.ofArray (head.Split(' '))
            buildListOfNames tail (str.Head :: listOfNames)
        | [] -> listOfNames
    buildListOfNames listOfNamesAndPhones []

let createListOfPhones listOfNamesAndPhones = 
    let rec buildListOfPhones listOfNamesAndPhones listOfPhones = 
        match (listOfNamesAndPhones : List<string>) with
        | head :: tail -> 
            let str = List.ofArray (head.Split(' '))
            buildListOfPhones tail (str.Tail.Head :: listOfPhones)
        | [] -> listOfPhones
    buildListOfPhones listOfNamesAndPhones []

let listToString listOfPairsNamesAndPhones = List.map (fun (x, y) -> x + " " + y) listOfPairsNamesAndPhones

let menu = 
    let rec phoneBook listOfNames listOfPhones = 
        printfn "\nВведите команду:"
        printfn "0 - выйти"
        printfn "1 - добавить запись (имя и телефон)"
        printfn "2 - найти телефон по имени"
        printfn "3 - найти имя по телефону"
        printfn "4 - сохранить текущие данные в файл"
        printfn "5 - считать данные из файла\n"
        let n = System.Int32.Parse(System.Console.ReadLine())
        match n with
        | 0 -> printfn "Вы завершили работу"
        | 1 -> 
            printf "Введите имя: "
            let listNames = addRecordName listOfNames
            printf "Введите телефон: "
            let listPhones = addRecordPhone listOfPhones
            printfn "Данные успешно добавлены"
            phoneBook listNames listPhones
        | 2 -> 
            printf "Введите имя: "
            let name = System.Console.ReadLine();
            if (List.exists (fun x -> x = name) listOfNames)
            then (searchPhoneByName listOfNames listOfPhones name) |> List.iter(fun x -> printfn "%s" x)
            else printfn "Такого имени не существует"
            phoneBook listOfNames listOfPhones
        | 3 -> 
            printf "Введите телефон: "
            let phone = System.Console.ReadLine();
            if (List.exists (fun x -> x = phone) listOfPhones)
            then (searchNameByPhone listOfNames listOfPhones phone) |> List.iter(fun x -> printfn "%s" x)
            else printfn "Такого телефона не существует"
            phoneBook listOfNames listOfPhones
        | 4 -> 
            System.IO.File.AppendAllLines("phone.txt", listToString (List.zip listOfNames listOfPhones))
            printfn "Данные успешно сохранены"
            phoneBook listOfNames listOfPhones
        | 5 -> 
            try 
               let listOfNamesAndPhones = System.IO.File.ReadLines(@"phone.txt") |> Seq.toList
               printfn "Данные были считаны"
               phoneBook (createListOfNames listOfNamesAndPhones) (createListOfPhones listOfNamesAndPhones)
            with 
               | :? System.IO.FileNotFoundException -> printfn "File not found!"
        | _ -> 
            printfn "Некорректный ввод"
            phoneBook listOfNames listOfPhones
    phoneBook [] []