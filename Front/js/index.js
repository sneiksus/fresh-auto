var header = $('.header'),
	scrollPrev = 0;

$(window).scroll(function() {
	var scrolled = $(window).scrollTop();
 
	if ( scrolled > 100 && scrolled > scrollPrev ) {
		header.addClass('out');
	} else {
		header.removeClass('out');
	}
	scrollPrev = scrolled;
});

$(function(){
	$(".car-img").click(function(event) {
	  var i_path = $(this).attr('src');
	  console.log(i_path);
	  console.log(this);
	  $('body').append('<div id="overlay"></div><div id="magnify"><img src="'+i_path+'"><div id="close-popup"><i></i></div></div>');
	  $('#magnify').css({
		  left: ($(document).width() - $('#magnify').outerWidth())/2,
		  // top: ($(document).height() - $('#magnify').outerHeight())/2 upd: 24.10.2016
			  top: ($(window).height() - $('#magnify').outerHeight())/2
		});
	  $('#overlay, #magnify').fadeIn('fast');
	});
	
	$('body').on('click', '#close-popup, #overlay', function(event) {
	  event.preventDefault();
   
	  $('#overlay, #magnify').fadeOut('fast', function() {
		$('#close-popup, #magnify, #overlay').remove();
	  });
	});
  });

  $('.max-km').on('input', function () {
	$(".max-km-view").text("Макс. пробіг: "+e.value);
});
	


