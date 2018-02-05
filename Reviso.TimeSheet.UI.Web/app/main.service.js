(function () {
    angular
    .module("app")
    .service("mainService", mainService)

    mainService.$inject = ["$http", "localStorageService"];

    function mainService($http, localStorageService) {
        var service = this;
    }

})()