#String
string = "Hey there";

#Multiline string
multiline = """hey there !! I am kavin
kumar from Presidio ... !"""

#accessing characters
string = "Hey there";
first_letter = string[0]; #H
last_letter = string[-1]; #e
print(first_letter+" "+last_letter)

#Slicing 
string = "Hey you there!"
sliced = string[1:5]; #ey y
sliced = string[0:-1]; #Hey you there
print(sliced)

#f-string
name = "kavin"
age = 21
message = f"Hey I am {name} and I am {age} years old."; #Hey I am kavin and I am 21 years old.
print(message)

#Formating
name = "Kavin"
formated = "Hello, I am {}".format(name); #Hello, I am Kavin
print(formated) 

#Methods in String
name = "  Kavin kumar"

#Captialize
print(name.capitalize()); #   kavin kumar
print("kavin".capitalize()) #Kavin
#upper
print(name.upper())#  KAVIN KUMAR
#lower
print(name.lower())#  kavin kumar
#strip
print(name.strip())#Kavin kumar
#replace
print(name.replace('K','Pr')); #Pravin kumar
#split
print(name.split(' ')) #['', '', 'Kavin', 'kumar']
#Join
print(", ".join(["Apple","Orange","Mango"]))


#Encoded
encoded_text = name.encode("utf-8");
print(encoded_text);
decoded_text = encoded_text.decode("utf-8");
print(decoded_text)

#endswith 
file_name = "index.js"
print(file_name.endswith(".js")) #true

string = "abcd123";
print(string.isalnum()); #need to be alpha or number
print(string.isalpha()); #need to be alphabet