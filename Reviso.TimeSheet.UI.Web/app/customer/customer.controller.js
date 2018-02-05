(function () {
    angular
    .module("app")
    .controller("customerController", customerController);

    customerController.$inject = ['customerService', 'sharedService'];

    function customerController(customerService, sharedService) {
        var vm = this;

        // SCOPE VARIABLES //
        vm.customers = [];
        vm.newRecord = {};
        
        vm.sortValue = "lastName";
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
            customerService.getAllRecords().then(function (response) {
                vm.customers = response.data;
                sharedService.setToggleSpinner(false);
            });
        }
        
        function resetField()
        {
            vm.newRecord = {};
        }

        function updateRecord(item)
        {
            customerService.updateRecord(item).then(function (response) {
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function addNewRecord(item) {
            customerService.addNewRecord(item).then(function (response) {
                vm.customers.push(response.data.customerAdded);
                resetField();
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function deleteRecord(item) {
            customerService.deleteRecord(item).then(function (response) {
                var index = vm.customers.indexOf(item);
                vm.customers.splice(index, 1);
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