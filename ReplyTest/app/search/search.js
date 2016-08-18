(function () {
    'use strict';
    var controllerId = 'search';
    angular.module('app').controller(controllerId, ['common', 'datacontext', search]);

    function search(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Search';
        vm.searchResults = [];
        vm.pattern = '';
        vm.search = search;

        activate();

        function search() {
//            console.log(vm.pattern);
            return datacontext.search(vm.pattern).then(function(data) {
                return vm.searchResults = data.data.results;
            });
        }

        function activate() {
            var promises = [];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Search View'); });
        }
    }
})();