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


number = 37;
if(isprime(number)):
    print("Yes he is prime")
else:
    print("No he is not prime.")