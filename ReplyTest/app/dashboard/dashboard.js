(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', dashboard]);

    function dashboard(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Dashboard';
        vm.topApps = [];

        activate();

        function activate() {
            var promises = [getTopApps()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getTopApps() {
            return datacontext.getTopApps().then(function (data) {
                return vm.topApps = data.data.results;
            });
        }
    }
})();