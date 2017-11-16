var App = (function () {
  'use strict';
  
  App.masks = function( ){

      $("[data-mask='cep']").mask("99999-999");
      $("[data-mask='data']").mask("99/99/9999");
      $("[data-mask='tel']").mask("99999999999");
    
  };

  return App;
})(App || {});
