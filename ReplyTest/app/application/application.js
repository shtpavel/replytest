(function () {
    'use strict';
    var controllerId = 'application';
    angular.module('app').controller(controllerId, ['common', 'datacontext','$routeParams', application]);

    function application(common, datacontext, $routeParams) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Application';
        vm.app = {};
        vm.package = $routeParams.package;

        activate();

        function getApp() {
            console.log(vm.package);
            return datacontext.getApp(vm.package).then(function (data) {
                return vm.app = data.data;
            });
        }

        function activate() {
            var promises = [getApp()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Search View'); });
        }
    }
})();