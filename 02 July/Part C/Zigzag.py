class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows == 1:
            return s

        rows = [""] * numRows
        
        add = 0
        increment = 1
        for i in s:
            rows[add] += i
            if add == 0:
                increment = 1
            elif add == numRows - 1:
                increment = -1

            add += increment
            
        return "".join(rows)