(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;

        var service = {
            getTopApps: getTopApps,
            search: search,
        };

        return service;

        function getTopApps() {
            return $http.get("/api/top");
        }

        function search(pattern) {
            return $http.get("/api/search?searchPattern=" + pattern);
        }
    }
})();