// ===================================
// Created for Codepad.co
// https://codepad.co/snippet/hNg85isU
// ===================================

$( document ).ready(function() {
  $('.trigger').on('click', function() {
    
      $('.page-wrapper').toggleClass('blur-it');
      $('.modal-wrapper').toggleClass('open');
     
     return false;
  });
});