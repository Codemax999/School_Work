// set title animation
$('h1').fadeColors();

// set button event listeners
$('#alert').on('click', () => $(this).showModal('alert'));
$('#success').on('click', () => $(this).showModal('success'));
$('#error').on('click', () => $(this).showModal('error'));
$('#warning').on('click', () => $(this).showModal('warning'));