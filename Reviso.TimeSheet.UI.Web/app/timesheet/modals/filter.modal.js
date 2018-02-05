(function () {
    'use strict';

    angular
        .module("app")
        .controller('FilterModal', FilterModal);

    FilterModal.$inject = ['$uibModalInstance', 'items', 'fieldName'];

    function FilterModal($uibModalInstance, items, fieldName) {

        var vm = this;

        vm.customerList = items;
        vm.projectList = items;
        vm.fieldName = fieldName;
        vm.selectedItem = null;

        //ACTIONS
        vm.ok = ok;
        vm.cancel = cancel;
        //FUNCTIONS
        vm.showSelect = showSelect;

        _ctor();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        function _ctor() {
        }

        function ok() {
            $uibModalInstance.close(vm.selectedItem ? vm.selectedItem : '');
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }

        function showSelect() {
            return vm.fieldName == 'customer' || vm.fieldName == 'project'
        }
    }

})();