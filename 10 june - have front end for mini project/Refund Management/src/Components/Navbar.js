const fetchNavbar = async () => {
  try{
    var NavTemplate = ` <nav class="flex items-center justify-between px-5 sm:px-10 md:px-20 lg:px-28 py-10 h-20 fixed top-0 left-0 w-full z-50 bg-primary">
        <img class="h-5 md:h-7 lg:h-10 w-auto" src="../Assets/Logo.png" alt="Logo">
        <ul class="flex justify-between items-center">
            <li class="text-secondary opacity-70 hover:opacity-100 text-lg mr-4 md:mr-7 lg:mr-10 hidden md:block">
                <a href="./index.html">Home</a>
            </li>
            <li class="text-secondary opacity-70 hover:opacity-100 text-sm mr-4 md:mr-7 lg:mr-10 block md:hidden">
                <a href="./index.html"><i class="fa-solid fa-house"></i></a>
            </li>
            <li class="text-secondary opacity-70 hover:opacity-100 text-lg mr-4 md:mr-7 lg:mr-10 hidden md:block">
                <a href="./Ordered.html">Ordered</a>
            </li>
            <li class="text-secondary opacity-70 hover:opacity-100 text-sm mr-4 md:mr-7 lg:mr-10 block md:hidden">
                <a href="./Ordered.html"><i class="fa-solid fa-cart-shopping"></i></a>
            </li>
            <li class="text-secondary opacity-70 hover:opacity-100 text-lg mr-4 md:mr-7 lg:mr-10 hidden md:block">
                <a href="./Refund.html">Refund</a>
            </li>
            <li class="text-secondary opacity-70 hover:opacity-100 text-sm mr-4 md:mr-7 lg:mr-10 block md:hidden">
                <a href="./Refund.html"><i class="fa-solid fa-right-left"></i></a>
            </li>
            <li class="text-primary border-2 bg-secondary rounded-md border-secondary px-4 py-2 hover:opacity-70 opacity-100 text-lg hidden md:block">
                <a href="/">Kavin Kumar M</a>
            </li>
        </ul>
        
    </nav>`
      const body = document.body;
      const navbarElement = document.createElement('nav');
      navbarElement.innerHTML = NavTemplate;
      body.insertBefore(navbarElement, body.firstChild); // Insert before the first child element
  }
  catch(err){
    console.log(err);
  }
};
  
  fetchNavbar();
  