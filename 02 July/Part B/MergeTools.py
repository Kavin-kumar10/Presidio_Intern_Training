def merge_the_tools(string, k):
    result = []
    for i in range(0,len(string),k):
        myset = set()
        temp = i
        for j in range(k):
            myset.add(string[temp])
            temp += 1
        result.append(myset)
    for elem in result:
        print(''.join(elem))
        
if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)