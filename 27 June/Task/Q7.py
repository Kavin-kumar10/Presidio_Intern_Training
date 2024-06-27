#Get 10 integer and consume the sum of prime numbers in the same

def isprime(number):
    if(number<=1):
        return False;
    if(number<=3):
        return True;
    if(number%2 == 0):
        return False;
    for num in range(3,int(number/2)):
        if(number%num == 0):
            return False;
    return True;

numbers = [];
Sum_of_Prime = 0;
for num in range(9):
    value = int(input(f"Enter number in {num} place : "));
    numbers.append(value)
for value in numbers:
    if(isprime(value)):
       Sum_of_Prime = Sum_of_Prime + int(value)

print("the sum of primes is : ",Sum_of_Prime);
