#output 
print("hello world");

#output with variables
name = "world";
print("hello " + name);

#output with input
name = input("Enter world : ");
print("hello "+ name);
print("hello",name);


# functional print
name = "kavin"
age = 20
greeting = f"I am {name} and I am {age} years old";
print(greeting);

#template based
template = "hey {}! I am {}";
convo = template.format("pravin","kavin");
print(convo);

#Write to a file
with open("file.text","w") as file:
    file.write("Hey it is for output learning \n");
print("updation successfull")

#Append to a file
with open("file.text","a") as file:
    file.write("This too for the same");
print("Append successfull")

