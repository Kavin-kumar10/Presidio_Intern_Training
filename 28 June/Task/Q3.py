Player_data = [
  (85, "Raju"),
  (99, "Kavin"),
  (78, "Rohith"),
  (94, "Azagar"),
  (95, "Jack"),
  (82, "Rack"),
  (65, "Bob"),
  (90, "Ramesh"),
  (70, "Rohan"),
  (88, "Ram"),
  (65,"Bablu"),
  (98,"Kumar"),
  (99,"Dp")
]

sorted_data = sorted(Player_data,reverse=True) #Sort in reverse Order
print("the top ten players were: ")
print(sorted_data[0:10]) #print top ten players
for num in range(10):
    print(f"The player {sorted_data[num][1]} scored {sorted_data[num][0]}") #print top ten players with score