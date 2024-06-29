# 1) Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.
# 2) Print the list of prime numbers up to a given number
# 3) Sort sore and name of players print the top 10
# 4) Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times
# 5) Credit card validation - Luhn check algorithm

def check_no_repeating(string):
    for i in range(len(string)):
        for j in range(len(string)):
            if(i != j):
                if(string[i] == string[j]):
                    return False;
    return True


def longest_substring(string):
    high_count = 0;
    high_string = "";
    start_ind = 0;
    end_ind = 0;
    while(start_ind!=len(string)):
        if(end_ind == len(string)):
            start_ind = start_ind+1;
            end_ind = start_ind;
        if(check_no_repeating(string[start_ind:end_ind])):
            req_string = string[start_ind:end_ind];
            if(len(req_string)>high_count):
                high_count = len(req_string);
                high_string = req_string;
        end_ind = end_ind + 1;
    return high_string

string = "abcsadda";
result = longest_substring(string)
print(result);