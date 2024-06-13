const dateDisplay=()=>{
    document.getElementById('demo').innerHTML=Date()
}


//changing the style of an element
const changeStyle=()=>{
  document.getElementById('demo').style.color='pink'
}


//creating and adding element
// let element=document.createElement('div')
// element.innerHTML='<h4>hey we are still learning</h4>'
// document.body.appendChild(element)


//adding element ot existing element
let existingDiv=document.getElementById('divId')
let element=document.createElement('div')
element.innerHTML='<h4>hey we are still learning</h4>'
existingDiv.appendChild(element)


//removing the element

const removeElement=()=>{
  let existingDivWithId=document.getElementById('divId')
  document.body.removeChild(existingDivWithId)
}