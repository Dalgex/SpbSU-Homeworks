type Contact = { Name : string; Phone : int; }

let searchPhoneByName listOfContacts name = List.filter (fun item -> item.Name = name) listOfContacts

let searchNameByPhone listOfContacts phone = List.filter (fun item -> item.Phone = phone) listOfContacts

let addContactData listOfContacts (contact : Contact) = contact :: listOfContacts

let createListOfContacts (contacts : List<string>) = 
    let rec buildListOfContacts (contacts : List<string>) listOfContacts = 
        match contacts with
        | head :: tail -> 
            let str = List.ofArray (head.Split(' '))
            buildListOfContacts tail ({Name = str.Head; Phone = System.Int32.Parse(str.Tail.Head)} :: listOfContacts)
        | [] -> listOfContacts
    buildListOfContacts contacts []

let contactsToString listOfContacts = List.map (fun item -> item.Name + " " + item.Phone.ToString()) listOfContacts

let saveToFile listOfContacts fileName = System.IO.File.WriteAllLines(fileName, contactsToString listOfContacts)

let readFromFile fileName =
    if  System.IO.File.Exists fileName then
        let contacts = System.IO.File.ReadLines(fileName) |> Seq.toList
        printfn "Данные из файла считаны"
        createListOfContacts contacts
    else 
        printfn "Файл не существует"
        []

let menu = 
    let rec phoneBook listOfContacts = 
        printfn "\nВведите команду:"
        printfn "0 - выйти"
        printfn "1 - добавить запись (имя и телефон)"
        printfn "2 - найти телефон по имени"
        printfn "3 - найти имя по телефону"
        printfn "4 - сохранить текущие данные в файл"
        printfn "5 - считать данные из файла\n"
        let n = System.Console.ReadLine()
        match n with
        | "0" -> printfn "Вы завершили работу"
        | "1" -> 
            printf "Введите имя: "
            let name = System.Console.ReadLine()
            printf "Введите телефон: "
            let phone = System.Int32.Parse(System.Console.ReadLine())
            let listOfRecords = addContactData listOfContacts {Name = name; Phone = phone}
            printfn "Данные успешно добавлены"
            phoneBook listOfRecords
        | "2" -> 
            printf "Введите имя: "
            let name = System.Console.ReadLine();
            if (List.exists (fun item -> item.Name = name) listOfContacts) then
                (searchPhoneByName listOfContacts name) |> List.iter(fun item -> printfn "Телефон: %d" item.Phone)
            else 
                printfn "Такого имени не существует"
            phoneBook listOfContacts
        | "3" -> 
            printf "Введите телефон: "
            let phone = System.Int32.Parse(System.Console.ReadLine());
            if (List.exists (fun item -> item.Phone = phone) listOfContacts)
            then (searchNameByPhone listOfContacts phone) |> List.iter(fun item -> printfn "Имя: %s" item.Name)
            else printfn "Такого телефона не существует"
            phoneBook listOfContacts
        | "4" -> 
            saveToFile listOfContacts "phone.txt"
            printfn "Данные успешно сохранены"
            phoneBook listOfContacts
        | "5" -> 
            phoneBook (readFromFile "phone.txt")
        | _ -> 
            printfn "Некорректный ввод"
            phoneBook listOfContacts
    phoneBook []