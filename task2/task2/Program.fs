open System

//Чтение числа
let rec read_natural message =
    printf "%s" message
    match Int32.TryParse(Console.ReadLine()) with
    | true, value when value > 0 -> value
    | _ ->
        printfn "Ошибка: введите целое положительное число (x>0)"
        read_natural message

//Создание списка
let create_list number =
    [
        for i in 1..number do
            yield read_natural (sprintf "Введите элемент %d: " i)
    ]

//Поиск цифры в числе
let rec containsDigit number digit =
    if number = 0 then 
        false
    else
        let last = number % 10
        if last = digit then 
            true
        else 
            containsDigit (number / 10) digit

[<EntryPoint>]
let main argv =
    printf "Введите количество элементов списка: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, count when count >= 0 ->

        let list = create_list count
        printfn "Исходный список: %A" list

        printf "Введите цифру для поиска (0-9): "
        match Int32.TryParse(Console.ReadLine()) with
        | true, digit when digit >= 0 && digit <= 9 ->
            let count = List.fold (fun acc x -> if containsDigit x digit then acc + 1 else acc) 0 list
            printfn "Количество элементов, содержащих цифру %d: %d" digit count
        | _ ->
            printfn "Ошибка: нужно ввести одну цифру от 0 до 9."


    | _ ->
        printfn "Ошибка: количество элементов списка не может быть отрицательным"
    0