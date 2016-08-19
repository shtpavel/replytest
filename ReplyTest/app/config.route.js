(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/all',
                config: {
                    title: 'all apps',
                    templateUrl: 'app/listing/listing.html',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-lock"></i> Apps'
                    }
                }
            }, {
                url: '/search',
                config: {
                    title: 'search',
                    templateUrl: 'app/search/search.html',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-lock"></i> Search'
                    }
                }
            }, {
                url: '/app/:package',
                config: {
                    title: 'app',
                    templateUrl: 'app/application/application.html',
                }
            }
        ];
    }
})();