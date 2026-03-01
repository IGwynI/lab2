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

//Поиск минимальной цифры числа
let rec min_digit number mini =
    if number > 0 then
        if number % 10 < mini 
        then
            min_digit (number/10) (number%10)
        else
            min_digit (number/10) (mini)
    else mini

[<EntryPoint>]
let main argv =
    printf "Введите количество элементов списка: "
    match Int32.TryParse(Console.ReadLine()) with
    | true, count when count >= 0 ->

        let list = create_list count
        printfn "Исходный список: %A" list

        let minDigits = List.map (fun x -> min_digit x 9) list
        printfn "Список минимальных цифр элементов исходного списка: %A" minDigits


    | _ ->
        printfn "Ошибка: количество элементов списка не может быть отрицательным"
    0