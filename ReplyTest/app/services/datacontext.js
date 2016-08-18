(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;

        var service = {
            getTopApps: getTopApps,
        };

        return service;

        function getTopApps() {
            return $http.get("/api/top");
        }
    }
})();