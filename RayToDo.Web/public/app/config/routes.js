
(function () {
    angular.module('app').config(routes);
    
    function routes($routeProvider, $locationProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'partials/home.html',
            controller: 'HomeCtrl'
        })
        .when('/login', {
            templateUrl: 'partials/login.html',
        })
        .when('/lists', {
            templateUrl: 'partials/lists/index.html',
            controller: 'ListsIndexCtrl',
            resolve: {
                auth: authResolver
            }
        })
        .otherwise({
            redirectTo: '/'
        });
        
        $locationProvider.html5Mode(false);
    }
    
    routes.$inject = ['$routeProvider', '$locationProvider'];
    
    function authResolver($location, AuthService) {
        if (!AuthService.authentication.isAuth) {
            $location.path('/login');
        }
    }
    
    authResolver.$inject = ['$location', 'AuthService'];
})();