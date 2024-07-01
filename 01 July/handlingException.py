while True:
    try:
        num = int(input("Enter your mark: "));
        print(num)
        break;
    except ValueError:
        print("Yooo .. ! your input is not valid.")