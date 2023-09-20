


class Figure:
    def __init__(self, color):
        self.color = color
    
    # пример переопределения метода (переопределяется метод object)
    # __str__ отвечает за строковое представление метода
    def __str__(self): 
        print("Figure")
        print("Color: " + self.__color)


class Rectangle(Figure): 
    def __init__(self, width, height, color):
        super().__init__(color) # вызов базового конструктора
        self.width = width
        self.height = height

    def area(self):
        return self.width * self.height

    # пример переопределения метода (переопределяется метод object)
    def __str__(self):
        print("Rectangle")
        print("Color: " + self.color)
        print("Width: " + str(self.width))
        print("Height: " + str(self.height))
        print("Area: " + str(self.area()))

    