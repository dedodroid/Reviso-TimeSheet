(function () {
    angular
    .module("app")
    .service("sharedService", sharedService)

    sharedService.$inject = ["$filter", '$window'];

    function sharedService($filter, $window) {
        var service = this;
        service.showSpinner = false;

        service.getShortDate = getShortDate;
        service.getCurrentMonth = getCurrentMonth;
        service.getCurrentYear = getCurrentYear;
        service.getCurrentShortDate = getCurrentShortDate;
        service.spinnerVisibility = false;
        service.setToggleSpinner = setToggleSpinner;
        service.getToggleSpinner = getToggleSpinner;
        service.showAlertMessage = showAlertMessage;

        function getShortDate(date) {
            return $filter('date')(new Date(date), 'yyyy-MM-dd');
        }
        function getCurrentShortDate() {
            return $filter('date')(new Date(), 'yyyy-MM-dd');
        }

        function getCurrentMonth() {
            return $filter('date')(new Date(), 'MM');
        }

        function getCurrentYear() {
            return $filter('date')(new Date(), 'yyyy');
        }

        function setToggleSpinner(state) {
            service.spinnerVisibility = state;
        }

        function getToggleSpinner() {
            return service.spinnerVisibility;
        }

        function showAlertMessage(message) {
            $window.alert(message);
        }
    }

})()