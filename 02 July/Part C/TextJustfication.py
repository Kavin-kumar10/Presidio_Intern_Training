class Solution:
    def fullJustify(self, words: List[str], maxWidth: int) -> List[str]:
        result = []
        curr_words = [], 
        curr_len = 0

        for word in words:
            if curr_len + len(word) + len(curr_words) > maxWidth:
                total_spaces = maxWidth - curr_len
                gaps = len(curr_words) - 1
                if gaps == 0:
                    result.append(curr_words[0] + ' ' * total_spaces)
                else:
                    space_per_gap = total_spaces // gaps
                    extra_spaces = total_spaces % gaps
                    line = ''
                    for i, w in enumerate(curr_words):
                        line += w
                        if i < gaps:
                            line += ' ' * space_per_gap
                            if i < extra_spaces:
                                line += ' '
                    result.append(line)
                curr_words, curr_len = [], 0
            curr_words.append(word)
            curr_len += len(word)

        last_line = ' '.join(curr_words)
        remaining_spaces = maxWidth - len(last_line)
        result.append(last_line + ' ' * remaining_spaces)

        return result