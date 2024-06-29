def GetAge():
    while True:
        try:
            age = int(input("Enter your age : "))
            if(age<5 or age>150):
                print("Age limit is between 5 to 150")
            else:
                return age;
        except ValueError as e:
            print(e);

def GetDob():
    while True:
        try:
            dob = input("Enter your DOB in the format (YYYY-MM-DD)")
            (year,month,date) = dob.split('-');
            if(int(month) not in range(1,13)):
                print("Invalid Entry of month")
            elif(int(date) not in range(1,31)):
                print("Invalid entry of date")
            else:
                return dob;
        except ValueError as e:
            print(e)


name = input("Enter your name : ")
age = GetAge();
dob = GetDob();
print(f"I am {name} of age {age} with dob of {dob}")