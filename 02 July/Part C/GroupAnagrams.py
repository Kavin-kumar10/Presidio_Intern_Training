class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        anagram_map = defaultdict(list)
        for word in strs:
            sorted_word = ''.join(sorted(word)) #sorted words like aet
            anagram_map[sorted_word].append(word) #forming dict {'aet':['eat','ate']}
        return list(anagram_map.values()) #getting values alone 
