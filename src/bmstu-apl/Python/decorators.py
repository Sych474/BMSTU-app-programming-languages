l = [1, 2, 3, 4, 5, 6, 7]
f = lambda x: x**3
print(list(map(f, l)))

## [1, 8, 27, 64, 125, 216, 343]

# пример функции которая возвращает функцию (замыкание) умножения на переданный параметр a
def mul(a):
    def helper(b):
        return a * b
    return helper

two_mul = mul(2)
print(two_mul(5)) # 10


# декоратор для функции с одной переменной
def print_fn_info(fn):
   def wrapper(arg):
       print("Run function: " + str(fn.__name__) + "(), with param: " + str(arg))
       return fn(arg)
   return wrapper


def pow2(x):
    return x * x

print(pow2(2))

weapped_pow2 = print_fn_info(pow2)
pow2 = weapped_pow2 

print(weapped_pow2(2)) # Run function: pow2(), with param: 2
print(pow2(2)) # Run function: pow2(), with param: 2

# чтобы не писать постоянно 

# weapped_pow2 = print_fn_info(pow2)
# pow2 = weapped_pow2 

# используется следующий синтаксис: 

@print_fn_info
def pow2(x):
    return x * x


# декоратор для метода класса 
def method_decor(fn):
   def wrapper(self):
       print("Run method: " + str(fn.__name__))
       fn(self)
   return wrapper

class Vector():
   def __init__(self, px = 0, py = 0):
       self.px = px
       self.py = py

   @method_decor
   def norm(self):
       print((self.px**2 + self.py**2)**0.5)

vc = Vector(px=10, py=5)
print(vc.norm())
# Run method: norm
# 11.180339887498949

