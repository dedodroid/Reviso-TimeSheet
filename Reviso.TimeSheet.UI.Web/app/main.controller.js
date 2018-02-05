(function () {

    'use strict';

    angular
    .module('app')
    .controller('mainController', mainController);

    mainController.$inject = ['mainService', 'sharedService'];
    
    function mainController(mainService, sharedService) {
        var vm = this;
        
        vm.getToggleSpinner = getToggleSpinner;

        _ctor();

        function _ctor() {
            sharedService.setToggleSpinner(true);
        }

        function getToggleSpinner() {
            return sharedService.getToggleSpinner();
        }

    }

})()