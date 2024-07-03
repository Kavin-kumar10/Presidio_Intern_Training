class Solution:
    def canJump(self, nums: List[int]) -> bool:
        flag = 0
        for n in nums:
            if flag < 0:
                return False
            elif n > flag:
                flag = n
            flag -= 1
            
        return True
