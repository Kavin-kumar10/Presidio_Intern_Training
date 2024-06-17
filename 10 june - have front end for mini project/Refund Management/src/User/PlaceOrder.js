const handleOrderPlacement = async (event) =>{
    event.preventDefault();
    console.log("Order placed");
}

const orderingform = document.getElementById('productDetail');
console.log(orderingform);
orderingform.addEventListener('submit',handleOrderPlacement);