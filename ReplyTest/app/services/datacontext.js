(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;
        var itemsPerPage = 25;

        var service = {
            getTopApps: getTopApps,
            search: search,
            getApp: getApp,
            getApps: getApps
        };

        return service;

        function getTopApps() {
            return $http.get("/api/apps/top");
        }

        function search(pattern) {
            return $http.get("/api/apps/search?searchPattern=" + pattern);
        }

        function getApp(packageId) {
            return $http.get("/api/apps?packageId=" + packageId);
        }

        function getApps(page) {
            return $http.get("/api/apps?page=" + page + "&itemsCount=" + itemsPerPage);
        }
    }
})();