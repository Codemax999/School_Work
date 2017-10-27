
// --- Title Animation ---
$.fn.fadeColors = function() {
  let count = 0;
  const colors = ['#4CAF50', '#F44336', '#FFC107', '#607D8B'];
  setInterval(() => {
    this.css('color', colors[count]);
    this.animate({opacity: 0.8}, 2500, () => this.animate({opacity: 0.6}, 2500));
    if (count === 3) count = 0;
    else count++;
  }, 5000);
}


// --- Dialog Animation ---
// fade out 
let timeout = setTimeout(() => {
  $('.modal').animate({opacity: 0}, 250);
}, 1500);

// show modal
$.fn.showModal = function(type) {

  // reset modal
  clearTimeout(timeout);
  $('.icon').css('display', 'none');
  $('.modal-msg').text('');

  // determine type
  let index = 0;
  index += type === 'alert' ? 0 : 0;
  index += type === 'success' ? 1 : 0;
  index += type === 'error' ? 2 : 0;
  index += type === 'warning' ? 3 : 0;

  // colors
  let colors = ['#607D8B', '#4CAF50', '#F44336', '#FFC107'];

  // determine message
  let modalMsg = [
    'Attention Alert',
    'Sweet Success',
    'Hold Up Error',
    'Uh Oh Warning'
  ];

  // set modal styles
  $('.modal').css({
    'display': 'flex',
    'border': `1px solid ${colors[index]}`
  }).animate({ opacity: 1 }, 250);

  // set modal icon
  $(`.${type}`).css('display', 'flex');

  // set modal message
  $('.modal-msg').css('color', `${colors[index]}`).text(modalMsg[index]);

  // fade in 
  $('.modal').show();

  // fade out after 3s
  timeout = setTimeout(() => {
    $('.modal').animate({ opacity: 0 }, 250);
  }, 1500);
}