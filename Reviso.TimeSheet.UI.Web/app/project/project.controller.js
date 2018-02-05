(function () {
    angular
    .module("app")
    .controller("projectController", projectController);

    projectController.$inject = ['$q', 'projectService', 'sharedService'];

    function projectController($q, projectService, sharedService) {
        var vm = this;

        // SCOPE VARIABLES //
        vm.projects = [];
        vm.newRecord = { name: "", description: "" };

        vm.sortValue = "name";
        vm.fieldName = null;
        vm.reverse = true;
        vm.crudMessage = null;
        vm.editMode = false;
        //END SCOPE VARIABLES //

        // FUNCTIONS //
        vm.changeMode = changeMode;
        vm.sortBy = sortBy;
        vm.updateRecord = updateRecord;
        vm.addNewRecord = addNewRecord;
        vm.deleteRecord = deleteRecord;
        // END FUNCTIONS //

        _ctor();
        
        function _ctor()
        {
            var promises = [projectService.getAllRecords()];

            $q.all(promises).then(function (values) {
                vm.projects = values[0].data;

                sharedService.setToggleSpinner(false);
            });
        }

        function updateRecord(item)
        {
            projectService.updateRecord(item).then(function (response) {
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function addNewRecord(item) {
            projectService.addNewRecord(item).then(function (response) {
                vm.projects.push(response.data.recordAdded);
                resetFields();
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function deleteRecord(item) {
            projectService.deleteRecord(item).then(function (response) {
                var index = vm.projects.indexOf(item);
                vm.projects.splice(index, 1);
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function changeMode() {
            vm.editMode = !vm.editMode;
        }

        function sortBy(fieldName) {
            vm.reverse = (vm.sortValue === fieldName) ? !vm.reverse : false;
            vm.sortValue = fieldName;
        }

        function resetFields() {
            vm.newRecord = {};
        }
    };

})()