
class useless_class: 
    pass

class class_name: 

    static_field = 42 # аналог static из .NET/C++ доступно без создания класса
    __private_static_field = 42 # "приватне" поле, но доступ все равно можно получить 
    #  _class_name__private_static_field

    @staticmethod # декоратор обозначающий что метод статический
    def static_method(): # статический метод
        print("static method")
    
    def __init__(self): # конструктор объекта
        # self - аналог this, должен быть в каждом методе класса 
        self.class_field = "some str" # публичное поле класса
        self.__private_field = "secret" # приватное поле класса

    def method(self, param): # метод класса
        return self.__private_field + " " + param


print(class_name.static_field) # печать статического поля
class_name.static_method() # вызов статического метода 

obj = class_name() # создание класса 
print(obj.class_field) # доступ к полю класса
obj.method("some value") # вызов метода 



# пример применения свойств:
class Rectangle:

    def __init__(self, width, height):
        self.__width = width
        self.__height = height

    @property
    def width(self):
        return self.__width

    @width.setter
    def width(self, w):
        if w > 0:
            self.__width = w
        else:
            raise ValueError

    @property
    def height(self):
        return self.__height

    @height.setter
    def height(self, h):
        if h > 0:
            self.__height = h
        else:
            raise ValueError

    def area(self):
        return self.__width * self.__height

rect = Rectangle(10, 20)
print(rect.width)
print(rect.height)

