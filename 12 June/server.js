let numbers = [1,2,3,4];
const evens = numbers.filter((number)=>number%2 == 0);
console.log(evens.toString());

function checkingEvenNumbers(num)
{
    return num%2==0//boolean
}


function filteringEvenNumbers(numbers,callbackFunc)
{
    let numberArray=[]
    for(let value of numbers)
    {
        if(callbackFunc(value))
            numberArray.push(value)
    }
    return numberArray
}

let arrayOfNumbers=[22,45,99,3,8,44]
console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))
let result = arrayOfNumbers.reduce((sum,number)=>{
    return sum=number;
})
console.log(result);

//reduce
let arrayOfNumbersfirst=[1,2,3,4,5]
let sumOfArrayElements=arrayOfNumbersfirst.reduce((sum,value)=>{
return sum+value
})
console.log(sumOfArrayElements)

//foreach
let arrayOfNumberssecond=[22,45,99,3,8,44]
arrayOfNumberssecond.forEach(num=>{console.log(num)})

//sort
let arrayOfNumbersthird=[22,45,99,3,8,44]
arrayOfNumbersthird.sort((numOne,numTwo)=>numOne-numTwo)
console.log(arrayOfNumbers)