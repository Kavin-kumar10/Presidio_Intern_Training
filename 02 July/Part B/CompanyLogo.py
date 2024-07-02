#!/bin/python3

import math
import os
import random
import re
import sys
from collections import Counter



if __name__ == '__main__':
    s = input()
    char_counts = Counter(s)
    sorted_chars = sorted(char_counts.items(), key=lambda item: (-item[1], item[0].lower()))
    num = 0
    for char,count in sorted_chars:
        if(num<3):
            print(char,count)
            num += 1
