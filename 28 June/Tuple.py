#tuple
value = (1,2);

#single element requires trailing comma
value = (1,)

#slice datas
details = ("fname","lname","dob");
name = details[0:2];
print(name)


#slice datas
data = ("kavin","presidio",("theni","bit"));
name = data[0];
company = data[1];
district,college = data[2];
print(name+" "+company+" "+district+" "+college);