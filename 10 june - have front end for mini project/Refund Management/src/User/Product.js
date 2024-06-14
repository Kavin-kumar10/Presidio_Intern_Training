const getProductDetails = async() =>{
    console.log('working');
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const data = urlParams.get('data');
    console.log(data);
    await fetch(`http://localhost:5018/api/Product/GetProductsById?ProductId=${data}`)
    .then((response)=>{
        const data = response.json();
        console.log(data);
    })
    .catch((err)=>console.log(err));
}

getProductDetails();