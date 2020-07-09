$(document).ready(function() { 
	$("#menubtn").click(function() { 
		if($('#menu').is(":hidden"))
		$("#menu").show(1000); 
		else
		$("#menu").hide(1000);
	}); 
	$("#X").click(function(){
		$("#menu").hide(1000);
	})
}); 

var cars=null,carsReserve=null,skip=0;
function skipCars(){
    if(cars.length==0)
       return [];
    else
    {
        var res=cars.slice(skip, skip+6);
        skip+=res.length;
        console.log(skip);
        if(skip>=cars.length)
           $('#load-else').hide();
           return res;
    }
}

document.getElementById("load-else").addEventListener("click", e => {

    e.preventDefault();
    show(skipCars());
});

document.getElementById("select").addEventListener("click", e => {

    e.preventDefault();
    var min_pw=$('#min-pw').val();
    var max_price=$('#max-price').val();
    var max_km=$('#max-km').val();
    var trans = $('#trans option:selected').text();
    var fuel = $('#fuel option:selected').text();
    var mark = $('#mark option:selected').text();
    carsReserve = cars;
    
});
window.onload = function(){  
	$.ajax({
			   url: "https://localhost:44369/User/GetCarsCatalog",
			   type: "GET",
			   crossDomain: true,
			   success: function (response) {
                   cars=response;
				   show(skipCars());
			   }
	});}
	function show(cars) {  
   cars.forEach(function(element, index) {
       if(index%2!=0)
       return;
       var first =  `<div id="" class="row catalog justify-content-end">
       <div class="col-lg-4 car-item ">
       <img class="car-img " src="data:image/png;base64,${element.picture}" alt="car">
       <h3 class="car-header">${element.mark} ${element.model}</h3>
       <ul class=properties">
           <li class="prop-val">
               <i class="fa fa-calendar" aria-hidden="true"></i> ${element.year}
           </li>
                   <li class="prop-val">
                       <i class="fa fa-cogs" aria-hidden="true"></i> ${element.transmission}
                   </li>
           <li class="prop-val">
               <i class="fa fa-bolt" aria-hidden="true"></i> ${element.power} кВт
           </li>
       </ul>
           <ul class=properties">
           <li class="prop-val">
               <i class='fa fa-tint'></i> ${element.fuel}
           </li>
           <li class="prop-val">
               <i class="fa fa-usd" aria-hidden="true"></i> ${element.price}
           </li>
           <li class="prop-val">
               <i class="fa fa-road" aria-hidden="true""></i> ${element.price} km
           </li>
       </ul>
       <a href="index.html" class="details">
           Деталі
           <i class="fa fa-long-arrow-right" aria-hidden="true"></i>
       </a>
   </div>`;
   var second;
   if(index < cars.length - 1)
      second =`<div id="" class="row catalog justify-content-end">
      <div class="col-lg-4 car-item ">
      <img class="car-img " src="data:image/png;base64,${cars[index + 1].picture}" alt="car">
      <h3 class="car-header">${cars[index + 1].mark} ${cars[index + 1].model}</h3>
      <ul class=properties">
          <li class="prop-val">
              <i class="fa fa-calendar" aria-hidden="true"></i> ${cars[index + 1].year}
          </li>
                  <li class="prop-val">
                      <i class="fa fa-cogs" aria-hidden="true"></i> ${cars[index + 1].transmission}
                  </li>
          <li class="prop-val">
              <i class="fa fa-bolt" aria-hidden="true"></i> ${cars[index + 1].power} кВт
          </li>
      </ul>
          <ul class=properties">
          <li class="prop-val">
              <i class='fa fa-tint'></i> ${cars[index + 1].fuel}
          </li>
          <li class="prop-val">
              <i class="fa fa-usd" aria-hidden="true"></i> ${cars[index + 1].price}
          </li>
          <li class="prop-val">
              <i class="fa fa-road" aria-hidden="true""></i> ${cars[index + 1].price} km
          </li>
      </ul>
      <a href="index.html" class="details">
          Деталі
          <i class="fa fa-long-arrow-right" aria-hidden="true"></i>
      </a>
   </div>
   </div>`;
   else
   second = "</div>";
	  $('#list-car-catalog').append(first+second)});
	}