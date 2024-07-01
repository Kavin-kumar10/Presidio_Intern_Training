from dataclasses import dataclass

@dataclass
class Employee:
    name: str
    email: str
    id : int

Kavin = Employee('kavin','kavinkumar.prof@gmail.com',123);
print(Kavin)