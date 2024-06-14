const handlesubmit = (e) =>{
    e.preventDefault();

    //Get element values
    const tablebody = document.getElementById('tablebody');
    const idValue = document.getElementById('Id').value;
    const nameValue = document.getElementById('Name').value;
    const priceValue = document.getElementById('Price').value;
    const quantityValue = document.getElementById('Quantity').value;
    console.log(idValue+' '+nameValue+" "+priceValue+' '+quantityValue);

    let flag = true;
    if(!idValue){
        document.getElementById('Id').style.border = "2px solid red";
        document.getElementById('errorId').style.display = "block";
        flag = false;
    }
    if (!nameValue){
        document.getElementById('Name').style.border = "2px solid red";
        document.getElementById('errorName').style.display = "block";
        flag = false;
    }
    if (!priceValue){
        document.getElementById('Price').style.border = "2px solid red";
        document.getElementById('errorPrice').style.display = "block";
        flag = false;
    }
    if (!quantityValue){
        document.getElementById('Quantity').style.border = "2px solid red";
        document.getElementById('errorQuantity').style.display = "block";
        flag = false;
    }
    if(!flag) return;

    //Create elements
    const newRow = document.createElement('tr');
    const newId = document.createElement('td');
    const newName = document.createElement('td');
    const newPrice = document.createElement('td');
    const newQuantity = document.createElement('td');

    //Assign values
    newId.textContent = idValue;
    newName.textContent = nameValue;
    newPrice.textContent = priceValue;
    newQuantity.textContent = quantityValue;

    //Append childs
    newRow.appendChild(newId);
    newRow.appendChild(newName);
    newRow.appendChild(newPrice);
    newRow.appendChild(newQuantity);
    tablebody.appendChild(newRow);
}

const form = document.getElementById('form');
form.addEventListener('submit',handlesubmit);

const idInput = document.getElementById('Id');
const nameInput = document.getElementById('Name');
const priceInput = document.getElementById('Price');
const quantityInput = document.getElementById('Quantity');

idInput.addEventListener('click',()=>{
    idInput.style.border = "none";
    document.getElementById('errorId').style.display = "none";
})
nameInput.addEventListener('click',()=>{
    nameInput.style.border = "none";
    document.getElementById('errorName').style.display = "none";
})
priceInput.addEventListener('click',()=>{
    priceInput.style.border = "none";
    document.getElementById('errorPrice').style.display = "none";
})
quantityInput.addEventListener('click',()=>{
    quantityInput.style.border = "none";
    document.getElementById('errorQuantity').style.display = "none";
})
