(function () {
    angular
    .module("app")
    .service("projectService", projectService)

    projectService.$inject = ["$http"];

    function projectService($http) {
        var service = this;
        service.projects = [];
        service.getAllRecords = getAllRecords;
        service.updateRecord = updateRecord;
        service.addNewRecord = addNewRecord;
        service.deleteRecord = deleteRecord;

        function getAllRecords()
        {
            return $http.get("http://localhost:39106/api/project/getrecords").then(function (response) {
                service.projects = response;
                return response;
            });
        }

        function updateRecord(item) {
            return $http.post("http://localhost:39106/api/project/updaterecord", item).then(function (response) {
                return response;
            });
        }

        function addNewRecord(item) {
            return $http.post("http://localhost:39106/api/project/addrecord", item).then(function (response) {
                return response;
            });
        }

        function deleteRecord(item) {
            return $http.post("http://localhost:39106/api/project/deleterecord", item).then(function (response) {
                return response;
            });
        }
    }

})()