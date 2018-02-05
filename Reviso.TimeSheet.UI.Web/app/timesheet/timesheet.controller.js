(function () {
    angular
    .module("app")
    .controller("timeSheetController", timeSheetController);

    timeSheetController.$inject = ['$q', '$uibModal', '$document', '$window', 'filterFilter', 'sharedService', 'timeSheetService', 'customerService', 'projectService'];

    function timeSheetController($q, $uibModal, $document, $window, filterFilter, sharedService, timeSheetService, customerService, projectService) {
        var vm = this;

        // SCOPE VARIABLES //
        vm.timeSheet = [];
        vm.customerList = [];
        vm.projectList = [];
        vm.newRecord = {date : sharedService.getCurrentShortDate()};
        vm.sortValue = "date";
        vm.filterValue = {};
        vm.filtersSelected = [{customer : false}, {project : false}, {date : false}];
        vm.fieldName = null;
        vm.reverse = true;
        vm.modalInstance = null;
        vm.crudMessage = null;
        vm.editMode = false;
        //END SCOPE VARIABLES //

        // FUNCTIONS //
        vm.changeMode = changeMode;
        vm.sortBy = sortBy;
        vm.updateRecord = updateRecord;
        vm.addNewRecord = addNewRecord;
        vm.deleteRecord = deleteRecord;
        vm.exportRecords = exportRecords;
        vm.getTotalRegularHours = getTotalRegularHours;
        vm.getTotalOverTimeHours = getTotalOverTimeHours;
        vm.openModal = openModal;
        //END FUNCTIONS //

        _ctor();

        function _ctor() {

            var promises = [customerService.getAllRecords(),
                projectService.getAllRecords(),
                timeSheetService.getAllRecords()];

            $q.all(promises).then(function (values) {
                vm.customerList = values[0].data;
                vm.projectList = values[1].data;

                for (var i = 0; i < values[2].data.length; i++) {
                    values[2].data[i].date = sharedService.getShortDate(values[2].data[i].date);
                }

                vm.timeSheet = values[2].data;

                sharedService.setToggleSpinner(false);

            });
        }

        function updateRecord(item) {
            timeSheetService.updateRecord(item).then(function (response) {
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function addNewRecord(item) {
            timeSheetService.addNewRecord(item).then(function (response) {
                if (response.data.recordAdded) {
                    //Convert date to shortdate
                    response.data.recordAdded.date = sharedService.getShortDate(response.data.recordAdded.date);
                    vm.timeSheet.push(response.data.recordAdded);
                    resetFields();
                }
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function deleteRecord(item) {
            timeSheetService.deleteRecord(item).then(function (response) {
                var index = vm.timeSheet.indexOf(item);
                vm.timeSheet.splice(index, 1);
                sharedService.showAlertMessage(response.data.message);
            }, function (reason) {
                // rejection
                sharedService.showAlertMessage(reason.data.message);
            });
        }

        function exportRecords() {
            $window.alert("//TODO: Create Invoice//");
        }

        function changeMode() {
            vm.editMode = !vm.editMode;
        }

        function sortBy(fieldName) {
            vm.reverse = (vm.sortValue === fieldName) ? !vm.reverse : false;
            vm.sortValue = fieldName;
        }

        function filterByCustomer(lastName) {                
            vm.filterValue.customer = {};
            vm.filterValue.customer.lastName = lastName;

            vm.filtersSelected.customer = vm.filterValue.customer.lastName != '' ? true : false;
        }

        function filterByProject(name) {
            vm.filterValue.project = {};
            vm.filterValue.project.name = name;

            vm.filtersSelected.project = vm.filterValue.project.name != '' ? true : false;
        }

        function filterByDate(date) {

            var filterDate;

            switch(date)
            {
                case 'currentYear':
                    filterDate = sharedService.getCurrentYear();
                break;
                case 'currentMonth':
                    filterDate = '-' + sharedService.getCurrentMonth() + '-';
                    break;
                case 'reset':
                    filterDate = '';
                    break;
            }

            vm.filterValue.date = {};
            vm.filterValue.date = filterDate;
            vm.filtersSelected.date = vm.filterValue.date ? true : false;
        }

        function resetFields() {
            vm.newRecord.taskDescription = null;
            vm.newRecord.regularHours = null;
            vm.newRecord.overTimeHours = null;
        }

        function openModal(size, fieldName) {

            var parentElem = angular.element($document[0].querySelector('.modal-dialog'));
            vm.fieldName = fieldName;

            modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'app/timesheet/modals/filter-modal.html',
                controller: 'FilterModal',
                controllerAs: 'modal',
                size: size,
                appendTo: parentElem,
                resolve: {
                    items: function () {
                        //return vm.customerList;
                        switch (vm.fieldName) {
                            case "customer":
                                return vm.customerList;
                                break;
                            case "project":
                                return vm.projectList;
                                break;
                            }
                    }, fieldName: function () {
                        return vm.fieldName;
                    }
                }
            });
        
            modalInstance.result.then(function (result) {
                // Ok clicked
                modalInstance.dismiss('cancel');
                modalInstance = null;

                switch (vm.fieldName) {
                    case "customer":
                        filterByCustomer(result)
                        break;
                    case "project":
                        filterByProject(result)
                        break;
                    case "date":
                        filterByDate(result)
                        break;
                }

            }, function () {
                modalInstance.dismiss('cancel');
                modalInstance = null;
            });

        }

        function getTotalRegularHours() {
            var count = 0;
            var filteredItems = filterFilter(vm.timeSheet, vm.filterValue);
            for (var i = 0; i < filteredItems.length; i++) {
                count = count + (filteredItems[i].regularHours ? filteredItems[i].regularHours : 0);
            }
            return count;
        }

        function getTotalOverTimeHours() {
            var count = 0;
            var filteredItems = filterFilter(vm.timeSheet, vm.filterValue);
            for (var i = 0; i < filteredItems.length; i++) {
                count = count + (filteredItems[i].overTimeHours ? filteredItems[i].regularHours : 0);
            }
            return count;
        }
    }
})()