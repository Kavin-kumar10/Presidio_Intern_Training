const fetchProductsData = async() =>{
    try{
        const response = await fetch('http://localhost:5018/api/Product')
        const result = await response.json();
        console.log(result)
        let products_container= document.getElementById('products_container');
        const product_template = `
        <img class="w-full h-full mb-2" src="[[productImage]]" alt="Product">
        <h1 class="text-3xl mb-2">[[productTitle]]</h1>
        <h2 class="text-white w-fit px-2 py-1 my-2 rounded-md bg-red-800">Limited time deal</h2>
        <h2 class="text-md text-green-500 mb-2">
            <b class="text-lg">$[[currentPrice]]</b>
            <s class="text-red-800 opacity-50 text-sm">$[[actualPrice]]</s>
        </h2>
        <p class="opacity-70">Lorem ipsum dolor sit amet consectetur adipisicing elit. Quibusdam tempore ad aspernatur.</p>
        `;
        result.forEach((elem)=>{
            console.log(elem.title);
            const productHTML = product_template.replace(/\[\[productImage\]\]/,elem.image ? elem.image : '../Assets/Product.jpg') // Assuming you have an "image" property
            .replace(/\[\[productTitle\]\]/, elem.title)
            .replace(/\[\[currentPrice\]\]/, elem.curr_price)
            .replace(/\[\[actualPrice\]\]/, elem.act_price);
            let tag = document.createElement('a');
            tag.setAttribute('id', 'product');
            tag.setAttribute('data-aos', 'fade-up');
            tag.setAttribute('data-aos-duration', '1000');
            tag.setAttribute('href', `Product.html?data=${elem.productId}`);
            tag.setAttribute('class', 'flex flex-col w-full p-5 shadow-md shadow-secondary cursor-pointer hover:shadow-lg hover:shadow-secondary');
            tag.innerHTML = productHTML;
            products_container.appendChild(tag);  
        })
    }
    catch(err){
        console.log(err);
    }
}

//Product page

// {
//     "productId": 101,
//     "title": "Soccor Football Nivia",
//     "description": "Sportsman Products",
//     "act_price": 1200,
//     "curr_price": 1000,
//     "returnable": 7,
//     "returnableForPrime": 14,
//     "count": 7
// }

const getProductDetails = async() =>{
    try{
        console.log('working');
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        const params = urlParams.get('data');
        let response = await fetch(`http://localhost:5018/api/Product/GetProductsById?ProductId=${params}`)
        const data = await response.json();
        let info = document.getElementById('productinfo');
        const template = `<div class="image h-1/2 w-full lg:w-1/2 lg:h-full lg:p-20 flex items-center justify-center">
            <img id="productImg" class="w-auto h-full lg:w-full lg:h-auto" src="../Assets/Product.jpg" alt="image">
        </div>
        <form action="/" id="productDetail" class="h-1/2 w-full lg:w-1/2 lg:h-full flex justify-center flex-col">
            <h1 class="hidden" id="productId">${data.productId?data.productId:"None"}</h1>
            <h1 class="text-3xl mb-2">${data.title?data.title:"Boat Boomset"}</h1>
            <h2 class="text-white w-fit px-2 py-1 my-2 rounded-md bg-red-800">Limited time deal</h2>
            <h2 class="text-md text-green-500 mb-2"><b class="text-lg">$${data.curr_price?data.curr_price:"200"}</b> <s class="text-red-800 opacity-50 text-sm">$${data.act_price?data.act_price:"450"}</s></h2>
            <p class="opacity-50 mb-3">${data.description?data.description:"Lorem ipsum dolor sit amet consectetur adipisicing elit. Quibusdam tempore ad aspernatur."}</p>
            <p class="text-secondary">Returnable upto $${data.returnable?data.returnable:"7"} Days <span class="text-green-900 font-bold">($${data.returnableForPrime?data.returnableForPrime:"14"} days exclusive for prime)</span></p>
            <button type="submit" class="flex self-start mt-5 rounded-sm px-5 py-2 shadow-sm shadow-secondary bg-secondary text-tertiary">Place Order</button>
        </form>`
        info.innerHTML = template;
        console.log(data);
    }
    catch(err){
        console.log(err);
    };
}