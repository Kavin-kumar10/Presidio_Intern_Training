with open('file.txt',"a") as file:
    file.write("heh..! its working")
file.closed

with open('file.txt',"r") as file:
    print(file.read());