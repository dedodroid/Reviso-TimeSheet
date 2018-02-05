(function () {
    angular
    .module("app")
    .service("customerService", customerService)

    customerService.$inject = ["$http"];

    function customerService($http) {
        var service = this;
        service.customers = [];
        service.getAllRecords = getAllRecords;
        service.updateRecord = updateRecord;
        service.addNewRecord = addNewRecord;
        service.deleteRecord = deleteRecord;

        function getAllRecords()
        {
            return $http.get("http://localhost:39106/api/customer/getrecords").then(function (response) {
                service.customers = response;
                return response;
            });
        }

        function updateRecord(item) {
            return $http.post("http://localhost:39106/api/customer/updaterecord", item).then(function (response) {
                return response;
            });
        }

        function addNewRecord(item) {
            return $http.post("http://localhost:39106/api/customer/addrecord", item).then(function (response) {
                return response;
            });
        }

        function deleteRecord(item) {
            return $http.post("http://localhost:39106/api/customer/deleterecord", item).then(function (response) {
                return response;
            });
        }
    }

})()