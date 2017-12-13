var App = (function () {
  'use strict';
  
  App.masks = function( ){

      $("[data-mask='cep']").mask("99999-999");
      $("[data-mask='data']").mask("99/99/9999");
      $("[data-mask='tel']").mask("(99) 9 9999-9999");
    
  };

  return App;
})(App || {});
