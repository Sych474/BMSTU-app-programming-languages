
a = "str"
match a:
    case "шаблон_1":
        print("действие_1")
    case "шаблон_2":
        print("действие_2")

    #................

    case "шаблон_N":
        print("действие_N")
    case _:
        print("действие_по_умолчанию")

def print_hello(language):
    match language:
        case "russian":
            print("Привет")
        case "american english" | "british english" | "english":
            print("Hello")
        case _:
            print("Undefined")



            