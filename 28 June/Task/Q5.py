# card_num = input("Enter your card number: ");
def shrink_to_single_digit(num):
    result = 0;
    num = list(str(num));
    for i in num:
        result = result + int(i);
    return result;


def check_valid_card(card_num):
    card_num = card_num.replace(' ','');
    odd = 0;
    even = 0;
    card_num = list(card_num);
    card_num.reverse();
    for i in range(len(card_num)):
        if(i%2 == 0):
            print(card_num[i])
            odd = odd + int(card_num[i]);
        else:
            value = int(card_num[i])*2;
            if(value>9):
                val= shrink_to_single_digit(value)
                even = even + val;
            else:
                even = even + value;
    sum = even+odd;
    print(even)
    print(odd)
    if(sum%10 == 0):
        print("Valid Credit Card");
    else:
        print("Invalid Credit Card");

check_valid_card("4847 3529 8926 3094");