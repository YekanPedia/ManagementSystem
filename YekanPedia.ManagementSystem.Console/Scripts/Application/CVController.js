$(document).ready(function() {
     
      $('.button-collapse').sideNav();
      $(".determinate").each(function(){
          var width = $(this).text();
          $(this).css("width", width)
            .empty()
            .append('<i class="zmdi zmdi-circle"></i>');                
      });
     
    
    var height = $('.caption').height();
        if($(window).width()){
          $('#featured').css('height', height);   
          $('#featured img').css('height', height);   
        }
    var wow = new WOW({ mobile: false });
    wow.init();
});
  
