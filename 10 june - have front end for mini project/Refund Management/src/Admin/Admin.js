$(document).ready(function(){
    let templateDiv = $("#accepted")
    let parentDiv = $("#parent")
    let storage = JSON.parse(localStorage.getItem('RefundApp'));
    let memberId = storage.memberID;
    
    // Api calls

    const fetchAcceptedData = async() =>{
        try{
            let response = await fetch("http://localhost:5018/api/Order/GetAcceptedRefund",{
                method:"GET",
                headers:{
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${storage.token}`
                }
            })
            let result = await response.json();
            console.log(result);
            createComponents(result);
        }   
        catch(err){
            console.log(err);
        }
    }

    const handlePaymentSubmission = async (orderId,refundId) =>{
        try{
            let transactionId = $("#Transaction").val();
            console.log(transactionId);
            const data = {
                adminId: memberId,
                refundId: refundId,
                transactionId: transactionId
              }
            let response = await fetch("http://localhost:5018/api/Payment",{
                method:"POST",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${storage.token}`
                },
                body: JSON.stringify(data),
            })
            let result = await response.json();
            console.log(result);
        }
        catch(err){
            console.log(err);
        }
        
    }
    
    
    //utilitis
    function generateGUID() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
          var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
          return v.toString(16);
        });
      }
    
    $("#Transaction").val(generateGUID());
    
    const createComponents = (elements) =>{
        $.each(elements,(index,elem)=>{
            var cloneDiv = templateDiv.clone();
            cloneDiv.find('h1').text(`Order Id : ${elem.orderId}`);
            cloneDiv.find('#pId').text(`Product Id : ${elem.productId}`)
            cloneDiv.find('#mId').text(`Member Id : ${elem.memberID}`)
            cloneDiv.find('#Price').text(`Total Price : ${elem.totalPrice}`)
            cloneDiv.find('#rId').text(`${elem.refundId}`)
            cloneDiv.find("#Btn").click(()=>handlePaymentPop(elem.orderId,elem.refundId))
            cloneDiv.appendTo(parentDiv);
        })
    }




    //#region Pophandlers

    const handlePaymentPop = (orderId,refundId) =>{
        let pop = document.getElementById('PaymentPop');
        pop.style.display = "flex";
        pop.querySelector('p').textContent = `Order Id : ${orderId}`;
        pop.querySelector('#cancel').addEventListener('click',()=>handleHidePop());
        pop.querySelector('#submission').addEventListener('click',()=>handlePaymentSubmission(orderId,refundId))
    }

    const handleHidePop = () =>{
        let pop = document.getElementById('PaymentPop');
        pop.querySelector('input').textContent = "";
        pop.style.display = "none";
    }

    //#endregion

    fetchAcceptedData();
})

