import random

def convert_to_list(prediction):
    list_str = list(str(prediction));
    list_num = [int(num) for num in list_str]
    return list_num;

random_value = random.randint(1000,9999);
random_int_value = convert_to_list(random_value);
print(random_int_value);

def get_bulls_count(prediction):
    count = 0;
    list_value = convert_to_list(prediction);
    for i in range(len(random_int_value)):
        if(random_int_value[i] == list_value[i]):
            count = count + 1;
    return count;

def get_cows_count(prediction):
    count = 0;
    list_value = convert_to_list(prediction);
    for i in range(len(list_value)):
        for j in range(len(random_int_value)):
            if(i != j):
                if(list_value[i] == random_int_value[j]):
                    count = count + 1;
                    break;
    return count;


def CowbullGame():
    while True:
        prediction = int(input("Enter your prediction: "))
        bulls = get_bulls_count(prediction);
        cows = get_cows_count(prediction);
        if(bulls == len(random_int_value)):
            print("You won")
            return;
        print(f"The bulls of {bulls} and with cows of {cows}")
CowbullGame();
