angular.module('app').factory('AuthInterceptor', ['$q', '$location', '$window', 'localStorageService', 'api', function ($q, $location, $window, localStorageService, api) {
        
        var authInterceptorFactory = {};
        
        var _request = function (config) {
            config.headers = config.headers || {};
            
            var authData = localStorageService.get('authData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }
            
            return config;
        }
        
        var _responseError = function (rejection) {
            if (rejection.status === 401) {
                $location.path('/login');
            }
            return $q.reject(rejection);
        }
        
        authInterceptorFactory.request = _request;
        authInterceptorFactory.responseError = _responseError;
        
        return authInterceptorFactory;
    }]);