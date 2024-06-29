# input in python
name = input("Enter your name: ");
print(name);

# input typcasted
age = int(input("Enter your age : "));
print(age);

# input multiple
name,age,dob = input("Enter your name, age and dob (seperated by space) :").split(" ");
print(name+" "+age+" "+dob);

# input from File
with open("file.text",'r') as file:
    for line in file:
        print(line.strip())

