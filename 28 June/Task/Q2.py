num = int(input("Enter the number: "))
def is_prime(value):
    if(value <= 1):
        return False;
    if(value <=3):
        return True;
    if(value%2 == 0):
        return False;
    for i in range(4,int(value/2)):
        if(value%i == 0):
            return False;
    return True;

def generate_prime(num):
    list_prime = [];
    for elem in range(0,num):
        if(is_prime(elem)):
            list_prime.append(elem)
    return list_prime;
    
result = generate_prime(num);
print(result)
