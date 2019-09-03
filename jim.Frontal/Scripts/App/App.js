//Namespaces
var App = App || {};
App.Comun = App.Comun || {}



App.Comun = (function(){


    function cargarConfiguracionFechasMomentjs () {
        
        $.validator.methods.date = function (value, element) {
            return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid();
        }
    }


    function init(){
        //cargarConfiguracionFechasMomentjs();
    }

        return {
            init: init
        };

})();