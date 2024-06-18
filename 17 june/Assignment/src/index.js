const GetProductsData = async() =>{
    try{
        let response = await fetch('https://dummyjson.com/products');
        let result = await response.json();
        console.log(result);
        let products = result.products;
        let parentElement = document.getElementById("parent");
        
        products.forEach((elem)=>{
            let newelem = document.createElement('div');
            const template = `<div class="flex flex-col shadow-sm shadow-black h-fit">
                <img class="bg-white p-5 h-2/3 w-full" src=${elem.thumbnail} alt="thumbnail">
                <div class="p-4 flex justify-between items-start bg-secondary shadow-gray-800">
                  <div class="flex flex-col h-20">
                    <h1 class="font-bold text-lg">${elem.title}</h1>
                    <p class="opacity-50 text-sm">${elem.category}</p>
                  </div>
                  <h2 class="text-green-600 text-xl font-bold">$${elem.price}</h2>
                </div>
              </div>`
            newelem.innerHTML = template;
            newelem.addEventListener('click',()=>{
              let pop = `<div class="pop flex justify-center items-center fixed top-0 left-0 h-screen w-screen bg-white bg-opacity-50">
                            <div class="flex bg-white shadow-sm shadow-black p-3">
                              <div class="flex flex-col sm:flex-row">
                                <img src=${elem.thumbnail} alt="">
                                <div class="flex flex-col justify-center w-96">
                                  <h1 class="text-2xl">${elem.title}</h1>
                                  <p class="opacity-50 mb-2">${elem.category}</p>
                                  <h2 class="text-lg opacity-75 mb-2">${elem.description}</p>
                                  <p class="text-green-600">$12.52</p>
                                  <p>only ${elem.stock} Available</p>
                                  <p class="text-red-600">Hurry up</p>
                                  <button id="btn" class="px-5 py-2 my-2 bg-gray-200 text-black shadow-sm shadow-black rounded-md">Close</button>
                                </div>
                              </div>
                            </div>
                          </div>`
              let newpop = document.createElement('div');
              newpop.id = "pop";
              newpop.innerHTML = pop;
              parentElement.appendChild(newpop);
              let button = document.getElementById('btn');
              button.addEventListener('click',()=>{
                document.getElementById('pop').style.display = "none"
              })
            });
            parentElement.appendChild(newelem);
        })
        
    }
    catch(err){
        console.log(err);
    }
}


GetProductsData();