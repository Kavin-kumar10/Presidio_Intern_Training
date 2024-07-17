export const WORDS = [
    'APPLE',
    'BERRY',
    'MAGIC',
  ];
  
  export const getRandomWord = (words) => {
    return words[Math.floor(Math.random() * words.length)];
  };
  