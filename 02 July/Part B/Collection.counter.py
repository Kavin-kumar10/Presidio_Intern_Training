total_amount = 0
number_of_shoes = int(input(""))
shoes = input("")
list_of_shoes = shoes.split()
number_of_customer = int(input(""))
for i in range(number_of_customer):
    customer_data = input("")
    data = customer_data.split()
    if data[0] in list_of_shoes:
        total_amount = total_amount + int(data[1])
        list_of_shoes.remove(data[0])
print(total_amount)
    