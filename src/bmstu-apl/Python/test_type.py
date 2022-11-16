

name = "John" # type: str
print(name)
name = 10
print(name)

# python -m pip install mypy - установка пакета аннотаций
# python -m mypy test_type.py

# test_type.py:3: error: Incompatible types in assignment (expression has type “int”, variable has type “str”)

