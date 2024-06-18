

const getOrders = async () =>{
    try{
        let storage = JSON.parse(localStorage.getItem('RefundApp'));
        let memberId = storage.memberID;
        const response = await fetch(`http://localhost:5018/api/Order/GetOrdersByMemberId?memberId=${memberId}`,{
            headers:{
                "Content-Type": "application/json",
                "Authorization": `Bearer ${storage.token}`
            }
        })
        let result = await response.json();
        console.log(result);
        let parent = document.getElementById('OrderedContainer');
        result.forEach(elem => {
            let item = document.getElementById('OrderedItem');
            item.querySelector('h1').textContent = "its changed by me";
            item.querySelector('p').innerHTML = `Returnable upto ${elem.product.returnable} Days <span class="text-green-900 font-bold">(${elem.product.returnableForPrime} days exclusive for prime)</span> from ${elem.createdDate} - Purchase Date`;
        });
    }
    catch(err){
        console.log(err);
    }
}

getOrders();

//Popup handlers

const handleReasonPop = () =>{
    let pop = document.getElementById('ReasonPop');
    pop.style.display = "flex";
    pop.querySelector('p').textContent = "Title given";
    console.log(pop);
}

const handleHidePop = () =>{
    let pop = document.getElementById('ReasonPop');
    pop.style.display = "none";
}