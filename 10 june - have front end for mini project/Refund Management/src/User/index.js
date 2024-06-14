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

fetchProductsData();