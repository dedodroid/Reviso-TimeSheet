(function () {
    angular
    .module("app")
    .service("timeSheetService", timeSheetService)

    timeSheetService.$inject = ["$http", "sharedService"];

    function timeSheetService($http, sharedService) {
        var service = this;
        service.timeSheet = [];
        service.getAllRecords = getAllRecords;
        service.updateRecord = updateRecord;
        service.addNewRecord = addNewRecord;
        service.deleteRecord = deleteRecord;

        function getAllRecords()
        {
            return $http.get("http://localhost:39106/api/timesheet/getrecords").then(function (response) {
                service.timeSheet = response;
                return response;
            });
        }

        function updateRecord(item) {
            return $http.post("http://localhost:39106/api/timesheet/updaterecord", item).then(function (response) {
                return response;
            });
        }

        function addNewRecord(item) {
            return $http.post("http://localhost:39106/api/timesheet/addrecord", item).then(function (response) {
                return response;
            });
        }

        function deleteRecord(item) {
            return $http.post("http://localhost:39106/api/timesheet/deleterecord", item).then(function (response) {
                return response;
            });
        }
    }

})()