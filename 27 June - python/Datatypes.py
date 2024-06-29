# import this

#int
num_1 = 10
num_2 = 20

#float 
float_1 = 2.44
float_2 = -2.5321

#Strings
name = "kavin"

#bool
Is_connected = True;
Is_error = False;

#List
names = ["kavin","pravin","Ragu"];
numbers = [1,2,3.42,4];
print(numbers[-1]); #gives last element
print(numbers[1:2]); #gives 2nd element to 5th

#Tuple
axis = (120,180);
x_coordiate = axis[0];
y_coordinate = axis[1];



#Set
numbers = {1,2,3,4,5,2}; #will remove the duplicate
#operations
numbers.add(8);
numbers.remove(8);
#Special operations
set1 = {1,2,3,6,7};
set2 = {1,2,4,5,6};
Union_set = set1 | set2; #uniorn
intersection_set = set1 & set2; #interseciton
subraction = set1 - set2 #subtract
Dynamicsubtract = set1 ^ set2
print(subraction)
print(Dynamicsubtract)



#Dictionary
dict = {"name":"kavin","age":20,"hobby":"anime"};
print(dict["name"]); #accsssing
dict["name"] = "kavin kumar M" #updating

#Delete a key value pair
del dict["hobby"]
#or
# professional = dict.pop('hobby')

for key in dict:
    print(key+" value is "+str(dict[key]));


