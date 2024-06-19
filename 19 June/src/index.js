$(document).ready(function(){
    var parentDiv = $('#container');
    var templateDiv = $('#template')
    var elements;

    const itemsPerPage = 5; // Adjust as needed
    var currentPage = 1;
  
    const createComponents = (elements) => {
      parentDiv.empty();
      elements.slice((currentPage - 1) * itemsPerPage, currentPage * itemsPerPage)
        .forEach((elem) => {
          var cloneDiv = templateDiv.clone();
          cloneDiv.find('h2').text(elem.quote);
          cloneDiv.find('p').text(elem.author);
          cloneDiv.css('display','flex');
          cloneDiv.appendTo(parentDiv);
        });
    };
    
    const handlePage = (page) =>{
        console.log(page);
        currentPage = page;
        createComponents(elements);
    }
    
    
    const fetchData = async()=>{
        try {
            const response = await fetch(`https://dummyjson.com/quotes`,{
                headers:{
                    "Content-Type": "application/json",
                }
            })
            const jsonData = await response.json();
            elements = jsonData.quotes;
            console.log(jsonData.quotes);
            createComponents(elements);
        } catch (err) {
            console.error("Error fetching data:", err);
        }
    }
    fetchData();

    const searchInput = $('#searchinput');
    searchInput.keyup(function() {
        const searchTerm = $(this).val().toLowerCase();
        console.log(searchTerm);
        var filtered = elements.filter((elem) => {
            const authorLower = elem.author?.toLowerCase(); 
            return authorLower?.includes(searchTerm); 
        });
        console.log(filtered);
        createComponents(filtered);
    });
      
    $('#asc').click(function(){
          elements.sort((a, b) => {
            if (a.author < b.author) {
              return -1; // a comes before b
            } else if (a.author > b.author) {
              return 1; // b comes before a
            }
            return 0; // names are equal, keep order
          });
          createComponents(elements);
    })
    $("#desc").click(function(){
        elements.sort((a, b) => {
            if (a.author > b.author) {
              return -1; // a comes before b
            } else if (a.author < b.author) {
              return 1; // b comes before a
            }
            return 0; // names are equal, keep order
          });
          createComponents(elements);
    })

    $('li').click(function () {  
     const pageNumber = parseInt($(this).text());
     console.log(pageNumber);
     handlePage(pageNumber);
    });

})