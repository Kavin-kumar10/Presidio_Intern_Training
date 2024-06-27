num = int(input("Enter the number : "));
for row in range(num):
    for space in range(3**num - 3**row):
        print("",end=" ")
    for col in range(3**row):
        print('* ',end="")
    print("\n")