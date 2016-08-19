(function () {
    'use strict';
    var controllerId = 'listing';
    angular.module('app').controller(controllerId, ['common', 'datacontext', listing]);

    function listing(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Listing';
        vm.apps = [];
        vm.getAll = getAll;
        vm.nextDisabled = function() {
            return vm.currentPage >= vm.totalPages;
        };

        vm.prevDisabled = function() {
            return vm.currentPage <= 0;
        };

        activate();

        function getAll(page) {
            return datacontext.getApps(page).then(function (data) {
                var result = data.data;
                vm.apps = result.data;
                vm.totalPages = result.total_pages;
                vm.currentPage = result.current_page;
            });
        }

        function activate() {
            var promises = [getAll(0)];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Listing View'); });
        }
    }
})();