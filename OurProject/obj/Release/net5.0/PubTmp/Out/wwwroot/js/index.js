
var table = document.getElementById("table"),rIndex;
            
for(var i = 1; i < table.rows.length; i++){
    table.rows[i].onclick = function(){
        rIndex = this.rowIndex;
        console.log(rIndex);

        document.getElementById("fname").value = this.cells[1].innerHTML;
        document.getElementById("lname").value = this.cells[2].innerHTML;
        document.getElementById("country").value = this.cells[3].innerHTML;
        document.getElementById("mNumber").value = this.cells[4].innerHTML;
    };
}
            
            
// edit the row
function editRow(){
    table.rows[rIndex].cells[1].innerHTML = document.getElementById("fname").value;
    table.rows[rIndex].cells[2].innerHTML = document.getElementById("lname").value;
    table.rows[rIndex].cells[3].innerHTML = document.getElementById("country").value;
    table.rows[rIndex].cells[4].innerHTML = document.getElementById("mNumber").value;
    document.querySelector('.editTable').setAttribute('style', 'display: none;')
  
  
}


// Data Update Table Here
function editTableDisplay() {
    document.querySelector('.editTable').setAttribute('style', 'display: block;')
    
    
}
function editRow1(){
  document.querySelector('.editTable').setAttribute('style', 'display: none;')


}

 // Dropdown Menu

var dropdown = document.querySelectorAll('.dropdown');
var dropdownArray = Array.prototype.slice.call(dropdown,0);
dropdownArray.forEach(function(el){
 var button = el.querySelector('a[data-toggle="dropdown"]'),
   menu = el.querySelector('.dropdown-menu'),
   arrow = button.querySelector('i.icon-arrow');

 button.onclick = function(event) {
  if(!menu.hasClass('show')) {
   menu.classList.add('show');
   menu.classList.remove('hide');
   arrow.classList.add('open');
   arrow.classList.remove('close');
   event.preventDefault();
  }
  else {
   menu.classList.remove('show');
   menu.classList.add('hide');
   arrow.classList.remove('open');
   arrow.classList.add('close');
   event.preventDefault();
  }
 };
})

Element.prototype.hasClass = function(className) {
    return this.className && new RegExp("(^|\\s)" + className + "(\\s|$)").test(this.className);
};
/*papers and terms*/
$.fn.commentCards = function(){

    return this.each(function(){
  
      var $this = $(this),
          $cards = $this.find('.card'),
          $current = $cards.filter('.card--current'),
          $next;
      
      $cards.on('click',function(){
        if ( !$current.is(this) ) {
          $cards.removeClass('card--current card--out card--next');
          $current.addClass('card--out');
          $current = $(this).addClass('card--current');
          $next = $current.next();
          $next = $next.length ? $next : $cards.first();
          $next.addClass('card--next');
        }
      });
  
      if ( !$current.length ) {
        $current = $cards.last();
        $cards.first().trigger('click');
      }
  
      $this.addClass('cards--active');
  
    })
  
  };



//const sr = ScrollReveal({
//    origin: 'top',
//    distance: '10px',
//    duration: 3000,
//    reset: true
//  });
  
//  sr.reveal('.container_1,.container_2,.btn ,.inputForm , .inn ,inn1', {
//    interval: 200
//  })

  /*login*/

